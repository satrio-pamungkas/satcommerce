namespace PaymentCommandAPI.Schemas;

public class MakePaymentRequest
{
    public Guid CartId { get; set; }
    public Guid PaymentId { get; set; }
}