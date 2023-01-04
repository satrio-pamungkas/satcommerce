using Confluent.Kafka;

namespace PaymentCommandAPI.Producers;

public class CartTopicProducer
{
    private readonly IProducer<Null, string> _producer;
    
    public CartTopicProducer(IConfiguration configuration)
    {
        var producerConfig = new ProducerConfig();
        configuration.GetSection("Kafka:ProducerSettings").Bind(producerConfig);
        this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }
    
    public void DeleteCart(string topic, string payload)
    {
        var headers = new Headers();
        headers.Add("CartDeleted", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, string>
        {
            Headers = headers,
            Value = payload
        });
    }
}