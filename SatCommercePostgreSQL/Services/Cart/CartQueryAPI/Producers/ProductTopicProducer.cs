using Confluent.Kafka;

namespace CartQueryAPI.Producers;

public class ProductTopicProducer
{
    private readonly IProducer<Null, string> _producer;
    
    public ProductTopicProducer(IConfiguration configuration)
    {
        var producerConfig = new ProducerConfig();
        configuration.GetSection("Kafka:ProducerSettings").Bind(producerConfig);
        this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }
    
    public void UpdateProductQuantity(string topic, string payload)
    {
        var headers = new Headers();
        headers.Add("ProductQuantityUpdateCancelled", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, string>
        {
            Headers = headers,
            Value = payload
        });
    }

    public void UpdateProductSold(string topic, string payload)
    {
        var headers = new Headers();
        headers.Add("ProductSoldUpdated", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, string>
        {
            Headers = headers,
            Value = payload
        });
    }
}