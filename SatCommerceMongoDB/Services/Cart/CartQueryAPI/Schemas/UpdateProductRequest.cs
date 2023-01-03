namespace CartQueryAPI.Schemas;

public class UpdateProductRequest
{
    public String? ProductId { get; set; }
    public int Quantity { get; set; }
}