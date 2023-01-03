using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentQueryAPI.Models;
using PaymentQueryAPI.Configurations;

namespace PaymentQueryAPI.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IMongoCollection<Payment> _paymentCollection;

    public PaymentRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);
        this._paymentCollection = mongoDatabase.GetCollection<Payment>(
            databaseSettings.Value.CollectionName);
    }
    
    public void Create(List<Payment> data)
    {
        this._paymentCollection.InsertMany(data);
    }

    public void DeleteSpecific(String id)
    {
        this._paymentCollection.DeleteOne(x => x.Id == id);
    }

    public void DeleteAll()
    {
        var filter = Builders<Payment>.Filter.Empty;
        this._paymentCollection.DeleteMany(filter);
    }
    public IEnumerable<Payment> GetAll()
    {
        return this._paymentCollection.Find(_ => true).ToList();
    }
    
}