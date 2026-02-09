using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Net;
using System.Globalization;
using FormatVnShop.Models;

namespace FormatVnShop.Services;

public interface IVnpayService
{
    string CreatePaymentUrl(HttpContext context, Order order);
    bool ValidateSignature(IQueryCollection collections);
}

public class VnpayService : IVnpayService
{
    private readonly IConfiguration _configuration;

    public VnpayService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreatePaymentUrl(HttpContext context, Order order)
    {
        var settings = _configuration.GetSection("VnpaySettings");
        var tick = DateTime.Now.Ticks.ToString();

        var vnpay = new VnpLib();
        vnpay.AddRequestData("vnp_Version", settings["Version"]!);
        vnpay.AddRequestData("vnp_Command", settings["Command"]!);
        vnpay.AddRequestData("vnp_TmnCode", settings["TmnCode"]!);
        vnpay.AddRequestData("vnp_Amount", ((long)(order.TotalAmount * 100)).ToString());
        vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", settings["CurrCode"]!);
        vnpay.AddRequestData("vnp_IpAddr", context.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
        vnpay.AddRequestData("vnp_Locale", settings["Locale"]!);
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang: " + order.OrderNumber);
        vnpay.AddRequestData("vnp_OrderType", "other");
        vnpay.AddRequestData("vnp_ReturnUrl", settings["ReturnUrl"]!);
        vnpay.AddRequestData("vnp_TxnRef", order.Id.ToString());

        string paymentUrl = vnpay.CreateRequestUrl(settings["BaseUrl"]!, settings["HashSecret"]!);
        return paymentUrl;
    }

    public bool ValidateSignature(IQueryCollection collections)
    {
        var vnpay = new VnpLib();
        var hashSecret = _configuration["VnpaySettings:HashSecret"]!;

        foreach (var (key, value) in collections)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value!);
            }
        }

        var vnpayHash = collections["vnp_SecureHash"];
        bool checkSignature = vnpay.ValidateSignature(vnpayHash!, hashSecret);

        return checkSignature;
    }
}

public class VnpLib
{
    private readonly SortedList<string, string> _requestData = new SortedList<string, string>(new VnpayCompare());
    private readonly SortedList<string, string> _responseData = new SortedList<string, string>(new VnpayCompare());

    public void AddRequestData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _requestData.Add(key, value);
        }
    }

    public void AddResponseData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _responseData.Add(key, value);
        }
    }

    public string CreateRequestUrl(string baseUrl, string hashSecret)
    {
        var data = new StringBuilder();
        foreach (var kv in _requestData)
        {
            data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
        }

        string queryString = data.ToString();
        baseUrl += "?" + queryString;
        string signData = queryString.Remove(data.Length - 1);
        string vnpSecureHash = HmacSha512(hashSecret, signData);
        baseUrl += "vnp_SecureHash=" + vnpSecureHash;

        return baseUrl;
    }

    public bool ValidateSignature(string inputHash, string secretKey)
    {
        string rspRaw = GetResponseData();
        string myChecksum = HmacSha512(secretKey, rspRaw);
        return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
    }

    private string HmacSha512(string key, string inputData)
    {
        var hash = new StringBuilder();
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
        using (var hmac = new HMACSHA512(keyBytes))
        {
            byte[] hashValue = hmac.ComputeHash(inputBytes);
            foreach (var theByte in hashValue)
            {
                hash.Append(theByte.ToString("x2"));
            }
        }

        return hash.ToString();
    }

    private string GetResponseData()
    {
        var data = new StringBuilder();
        if (_responseData.ContainsKey("vnp_SecureHashType"))
        {
            _responseData.Remove("vnp_SecureHashType");
        }

        if (_responseData.ContainsKey("vnp_SecureHash"))
        {
            _responseData.Remove("vnp_SecureHash");
        }

        foreach (var kv in _responseData)
        {
            data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
        }

        //remove last '&'
        if (data.Length > 0)
        {
            data.Remove(data.Length - 1, 1);
        }

        return data.ToString();
    }
}

public class VnpayCompare : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == y) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        var vnpCompare = CompareInfo.GetCompareInfo("en-US");
        return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
    }
}
