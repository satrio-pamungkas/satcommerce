namespace PaymentCommandAPI.Schemas;

public class SuccessResponse
{
    public String? CartId { get; set; }
    public String Description { get; set; }
    public bool Valid { get; set; }
}