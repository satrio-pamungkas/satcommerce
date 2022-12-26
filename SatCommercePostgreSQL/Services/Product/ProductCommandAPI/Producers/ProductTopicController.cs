using Confluent.Kafka;
using ProductCommandAPI.Models;
using ProductCommandAPI.Utils;

namespace ProductCommandAPI.Producers;

public class ProductTopicProducer
{
    private readonly IProducer<Null, Product> _producer;
    
    public ProductTopicProducer(IConfiguration configuration)
    {
        var producerConfig = new ProducerConfig();
        configuration.GetSection("Kafka:ProducerSettings").Bind(producerConfig);
        this._producer = new ProducerBuilder<Null, Product>(producerConfig)
            .SetValueSerializer(new PayloadSerializer<Product>())
            .Build();
    }
    
    public void EmitMessage(string topic, Product payload)
    {
        var headers = new Headers();
        headers.Add("ProductCreated", new byte[] { 100 });
        this._producer.ProduceAsync(topic, new Message<Null, Product>
        {
            Value = payload
        });
    }
}