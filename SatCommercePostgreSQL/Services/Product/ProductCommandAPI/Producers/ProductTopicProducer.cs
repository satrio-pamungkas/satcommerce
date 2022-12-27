using Confluent.Kafka;

namespace ProductCommandAPI.Producers;

public class ProductTopicProducer
{
    private readonly IProducer<Null, string> _producer;
    
    public ProductTopicProducer(IConfiguration configuration)
    {
        var producerConfig = new ProducerConfig();
        configuration.GetSection("Kafka:ProducerSettings").Bind(producerConfig);
        this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }
    
    public void CreateProduct(string topic, string payload)
    {
        var headers = new Headers();
        headers.Add("ProductCreated", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, string>
        {
            Headers = headers,
            Value = payload
        });
    }
}