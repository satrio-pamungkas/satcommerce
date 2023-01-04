namespace PaymentCommandAPI.Schemas;

public class SuccessResponse
{
    public Guid CartId { get; set; }
    public string Description { get; set; }
    public bool Valid { get; set; }
}