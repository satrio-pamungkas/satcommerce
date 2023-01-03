using System.ComponentModel.DataAnnotations;

namespace PaymentCommandAPI.Schemas;

public class MakePaymentRequest
{
    [Required]
    public String? CartId { get; set; }
    [Required]
    public String? PaymentId { get; set; }
}