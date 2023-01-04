using System.ComponentModel.DataAnnotations;

namespace PaymentCommandAPI.Schemas;

public class MakePaymentRequest
{
    [Required]
    public Guid CartId { get; set; }
    [Required]
    public Guid PaymentId { get; set; }
}