namespace PaymentCommandAPI.Schemas;

public class PaymentRequest
{
    public String? IdNumber { get; set; }
    public String? ImageUrl { get; set; }
    public String? Name { get; set; }
    public String? Type { get; set; }
}