namespace ProductQueryAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}