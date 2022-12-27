using Confluent.Kafka;

namespace PaymentCommandAPI.Producers;

public class PaymentTopicProducer
{
    private readonly IProducer<Null, string> _producer;
    
    public PaymentTopicProducer(IConfiguration configuration)
    {
        var producerConfig = new ProducerConfig();
        configuration.GetSection("Kafka:ProducerSettings").Bind(producerConfig);
        this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }
    
    public void CreatePayment(string topic, string payload)
    {
        var headers = new Headers();
        headers.Add("PaymentCreated", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, string>
        {
            Headers = headers,
            Value = payload
        });
    }
}