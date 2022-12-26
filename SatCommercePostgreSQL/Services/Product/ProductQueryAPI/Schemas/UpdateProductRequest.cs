namespace ProductQueryAPI.Schemas;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}