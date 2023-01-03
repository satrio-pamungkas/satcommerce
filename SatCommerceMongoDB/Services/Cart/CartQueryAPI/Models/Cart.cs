using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CartQueryAPI.Models;

public class Cart
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String? Id { get; set; }
    public String? CartId { get; set; }
    public String? ProductId { get; set; }
    public String? ProductName { get; set; }
    public String? ImageUrl { get; set; }
    public String? Brand { get; set; }
    public String? Slug { get; set; }
    public int? Price { get; set; }
    public int Quantity { get; set; }
    public int? TotalPrice { get; set; }
}