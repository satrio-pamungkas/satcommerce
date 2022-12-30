namespace CartQueryAPI.Models;

public class Cart
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public String? ProductName { get; set; }
    public String? ImageUrl { get; set; }
    public String? Brand { get; set; }
    public String? Slug { get; set; }
    public int? Price { get; set; }
    public int Quantity { get; set; }
    public int? TotalPrice { get; set; }
}