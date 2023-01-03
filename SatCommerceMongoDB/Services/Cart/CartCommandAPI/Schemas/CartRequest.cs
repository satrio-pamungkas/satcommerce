using System.ComponentModel.DataAnnotations;

namespace CartCommandAPI.Schemas;

public class CartRequest
{
    [Required]
    public String? ProductId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Quantity { get; set; }
}