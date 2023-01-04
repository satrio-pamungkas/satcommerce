namespace PaymentCommandAPI.Models;

public class Payment
{
    public Guid Id { get; set; }
    public String? IdNumber { get; set; }
    public String? ImageUrl { get; set; }
    public String? Name { get; set; }
    public String? Type { get; set; }
}