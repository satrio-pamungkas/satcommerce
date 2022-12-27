namespace ProductQueryAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public String? Description { get; set; }
    public String? ImageUrl { get; set; }
    public String? Brand { get; set; }
    public String? Slug { get; set; }
    public int? Weight { get; set; }
    public int? Sold { get; set; }
    public int? Rating { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}