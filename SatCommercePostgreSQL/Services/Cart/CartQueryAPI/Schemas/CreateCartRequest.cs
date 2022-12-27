namespace CartQueryAPI.Schemas;

public class CreateCartRequest
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}