using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace FormatVnShop.Services;

public interface IGhtkService
{
    Task<decimal> CalculateFeeAsync(string province, string district, string ward, string address, int totalWeight, decimal orderValue);
}

public class GhtkService : IGhtkService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GhtkService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<decimal> CalculateFeeAsync(string province, string district, string ward, string address, int totalWeight, decimal orderValue)
    {
        var token = _configuration["GhtkSettings:ApiToken"];
        var baseUrl = _configuration["GhtkSettings:BaseUrl"] ?? "https://services.giaohangtietkiem.vn";
        
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["pick_province"] = _configuration["GhtkSettings:PickProvince"] ?? "Hà Nội";
        query["pick_district"] = _configuration["GhtkSettings:PickDistrict"] ?? "Quận Ba Đình";
        query["province"] = province;
        query["district"] = district;
        query["ward"] = ward;
        query["address"] = address;
        query["weight"] = totalWeight.ToString();
        query["value"] = ((int)orderValue).ToString();
        query["transport"] = "road";

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Token", token);
        
        var url = $"{baseUrl}/services/shipment/fee?{query}";
        
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error calling GHTK API: " + response.ReasonPhrase);
        }

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GhtkFeeResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result == null || !result.Success)
        {
            throw new Exception("GHTK API error: " + result?.Message);
        }

        return result.Fee.Fee;
    }
}

public class GhtkFeeResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public GhtkFeeDetail? Fee { get; set; }
}

public class GhtkFeeDetail
{
    public string? Name { get; set; }
    public decimal Fee { get; set; }
    public decimal InsuranceFee { get; set; }
    public bool Delivery { get; set; }
}
