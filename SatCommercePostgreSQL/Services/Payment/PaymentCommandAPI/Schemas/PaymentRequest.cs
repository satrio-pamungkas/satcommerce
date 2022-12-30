using System.ComponentModel.DataAnnotations;

namespace PaymentCommandAPI.Schemas;

public class PaymentRequest
{
    [Required]
    public String? IdNumber { get; set; }
    [Required]
    public String? ImageUrl { get; set; }
    [Required]
    public String? Name { get; set; }
    [Required]
    public String? Type { get; set; }
}