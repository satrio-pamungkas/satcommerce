using System.ComponentModel.DataAnnotations;

namespace ProductCommandAPI.Schemas;

public class ProductRequest
{
    [Required]
    public String? Name { get; set; }
    [Required]
    public String? Description { get; set; }
    [Required]
    public String? ImageUrl { get; set; }
    [Required]
    public String? Brand { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Weight { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Sold { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Rating { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Price { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number is allowed")]
    public int Quantity { get; set; }
}