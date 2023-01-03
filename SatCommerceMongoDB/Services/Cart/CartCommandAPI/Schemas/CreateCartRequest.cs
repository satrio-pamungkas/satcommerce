namespace CartCommandAPI.Schemas;

public class CreateCartRequest
{
    public String? CartId { get; set; }
    public String? ProductId { get; set; }
    public int Quantity { get; set; }
}