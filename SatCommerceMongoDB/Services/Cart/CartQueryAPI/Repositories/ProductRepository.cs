using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CartQueryAPI.Models;
using CartQueryAPI.Configurations;

namespace CartQueryAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);
        this._productCollection = mongoDatabase.GetCollection<Product>("Products");
    }

    public void Create(List<Product> data)
    {
        this._productCollection.InsertMany(data);
    }

    public void UpdateQuantity(string id, int quantity, bool isUndo)
    {
        var data = this._productCollection
            .Find(x => x.Id == id).FirstOrDefault();
        int newQuantity ;
        if (isUndo)
        {
            newQuantity = data.Quantity + quantity;
        }
        else
        {
            newQuantity = data.Quantity - quantity;
        }
        
        var filter = Builders<Product>.Filter.Where(x => x.Id == id);
        var update = Builders<Product>.Update.Set(x => x.Quantity, newQuantity);
        var options = new FindOneAndUpdateOptions<Product>();
        
        this._productCollection.FindOneAndUpdate(filter, update, options);
    }
    
    public void UpdateSold(string id, int quantity)
    {
        var data = this._productCollection
            .Find(x => x.Id == id).FirstOrDefault();
        var previousSold = data.Sold;
        var newSold = previousSold + quantity;
        
        var filter = Builders<Product>.Filter.Where(x => x.Id == id);
        var update = Builders<Product>.Update.Set(x => x.Sold, newSold);
        var options = new FindOneAndUpdateOptions<Product>();
        
        this._productCollection.FindOneAndUpdate(filter, update, options);
    }

    public void Delete(string id)
    {
        this._productCollection.DeleteOne(x => x.Id == id);
    }

    public Product GetById(string id)
    {
        return this._productCollection.Find(x => x.Id == id).FirstOrDefault();
    }

    public IEnumerable<Product> GetAll()
    {
        return this._productCollection.Find(_ => true).ToList();
    }
}