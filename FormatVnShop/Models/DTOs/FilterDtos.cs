namespace FormatVnShop.Models.DTOs;

public class FilterOptionsDto
{
    public List<string> Colors { get; set; } = new();
    public List<string> Materials { get; set; } = new();
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public List<FilterCategoryDto> Categories { get; set; } = new();
}

public class FilterCategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
