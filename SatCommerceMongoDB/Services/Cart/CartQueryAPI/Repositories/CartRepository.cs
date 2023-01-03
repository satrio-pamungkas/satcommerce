using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CartQueryAPI.Models;
using CartQueryAPI.Configurations;

namespace CartQueryAPI.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IMongoCollection<Cart> _cartCollection;

    public CartRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);
        this._cartCollection = mongoDatabase.GetCollection<Cart>("Carts");
    }

    public void Create(List<Cart> data)
    {
        this._cartCollection.InsertMany(data);
    }

    public void DeleteSpecific(string id)
    {
        var filter = Builders<Cart>.Filter.Where(x => x.CartId == id);
        this._cartCollection.DeleteMany(filter);
    }

    public IEnumerable<Cart> GetAll()
    {
        return this._cartCollection.Find(_ => true).ToList();
    }

    public IEnumerable<Cart> GetAllSpecific(string id)
    {
        return this._cartCollection.Find(x => x.CartId == id).ToList();
    }
}