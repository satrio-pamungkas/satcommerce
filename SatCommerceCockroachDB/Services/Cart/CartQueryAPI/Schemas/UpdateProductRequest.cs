namespace CartQueryAPI.Schemas;

public class UpdateProductRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}