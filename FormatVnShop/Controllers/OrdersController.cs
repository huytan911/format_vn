using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FormatVnShop.Data;
using FormatVnShop.Models;
using FormatVnShop.Services;

namespace FormatVnShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IVnpayService _vnpayService;
    private readonly IConfiguration _configuration;

    public OrdersController(ApplicationDbContext context, IVnpayService vnpayService, IConfiguration configuration)
    {
        _context = context;
        _vnpayService = vnpayService;
        _configuration = configuration;
    }

    // GET: api/orders
    [HttpGet]
    [Authorize(Roles = "SuperAdmin,Manager,Staff")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    // GET: api/orders/5
    [HttpGet("{id}")]
    [Authorize(Roles = "SuperAdmin,Manager,Staff")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // GET: api/orders/my
    [HttpGet("my")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Order>>> GetMyOrders()
    {
        var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(userEmail))
        {
            return Unauthorized("Invalid token: Email claim missing.");
        }

        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == userEmail);

        if (customer == null)
        {
            return BadRequest("Customer account not found for this user.");
        }

        return await _context.Orders
            .Where(o => o.CustomerId == customer.Id)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    // POST: api/orders
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        // Security: Override CustomerId from logged-in user to prevent spoofing or invalid 0 IDs
        // Use ClaimTypes.Email to find the user, as Identity.Name maps to ClaimTypes.Name (the user's name, not email)
        var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        
        if (string.IsNullOrEmpty(userEmail))
        {
             return Unauthorized("Invalid token: Email claim missing.");
        }

        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == userEmail);
        
        if (customer == null)
        {
            return BadRequest("Customer account not found for this user.");
        }
        
        order.CustomerId = customer.Id;
        order.Customer = null; // Ensure no nested object causes EF issues

        order.OrderDate = DateTime.Now;
        
        // Generate order number if not provided
        if (string.IsNullOrEmpty(order.OrderNumber))
        {
            var lastOrder = await _context.Orders
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();
            
            var nextNumber = (lastOrder?.Id ?? 0) + 1;
            order.OrderNumber = $"ORD-{DateTime.Now:yyyy}-{nextNumber:D4}";
        }
        
        // Clear circular references or unnecessary child object data if any
        foreach (var item in order.OrderItems)
        {
            item.Order = null;
            item.Product = null;
            item.ProductVariant = null;
        }

        _context.Orders.Add(order);
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Log the error (console for now)
            Console.WriteLine($"Error creating order: {ex.InnerException?.Message ?? ex.Message}");
            return BadRequest($"Unable to create order: {ex.InnerException?.Message ?? ex.Message}");
        }

        if (order.PaymentMethod == "VNPAY")
        {
            var paymentUrl = _vnpayService.CreatePaymentUrl(HttpContext, order);
            return Ok(new { success = true, paymentUrl, orderId = order.Id });
        }

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    // GET: api/orders/payment-callback
    [HttpGet("payment-callback")]
    public async Task<IActionResult> PaymentCallback()
    {
        if (Request.Query.Count > 0)
        {
            bool checkSignature = _vnpayService.ValidateSignature(Request.Query);
            if (checkSignature)
            {
                var vnp_ResponseCode = Request.Query["vnp_ResponseCode"];
                var vnp_TransactionStatus = Request.Query["vnp_TransactionStatus"];
                var vnp_TxnRef = Request.Query["vnp_TxnRef"];
                var vnp_TransactionNo = Request.Query["vnp_TransactionNo"];

                if (int.TryParse(vnp_TxnRef, out int orderId))
                {
                    var order = await _context.Orders.FindAsync(orderId);
                    if (order != null)
                    {
                        if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                        {
                            order.PaymentStatus = "Paid";
                            order.VnpayTransactionId = vnp_TransactionNo;
                            order.Status = "Processing"; // Move to processing after payment
                        }
                        else
                        {
                            order.PaymentStatus = "Failed";
                        }
                        await _context.SaveChangesAsync();
                        
                        // Redirect to frontend result page
                        var frontendUrl = _configuration["FrontendUrl"] ?? "http://localhost:5173";
                        return Redirect($"{frontendUrl}/checkout/result?orderId={orderId}&status={(order.PaymentStatus == "Paid" ? "success" : "failed")}");
                    }
                }
            }
        }
        return BadRequest("Invalid signature or transaction data");
    }

    // PUT: api/orders/5
    [HttpPut("{id}")]
    [Authorize(Roles = "SuperAdmin,Manager")]
    public async Task<IActionResult> UpdateOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/orders/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);
            
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }
}
