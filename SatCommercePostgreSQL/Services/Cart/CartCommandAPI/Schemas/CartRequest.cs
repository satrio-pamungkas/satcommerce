namespace CartCommandAPI.Schemas;

public class CartRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}