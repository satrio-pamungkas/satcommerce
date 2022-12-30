using System.ComponentModel.DataAnnotations;

namespace CartCommandAPI.Schemas;

public class CreateCartRequest
{
    [Required]
    public Guid CartId { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Quantity { get; set; }
}