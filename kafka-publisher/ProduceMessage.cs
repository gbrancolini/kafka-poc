using Confluent.Kafka;

namespace kafka_publisher
{
    public class ProduceMessage
    {
        public async Task CreateMessage(string message)
        {
            string clientId = "my-poc";

            var config = new ProducerConfig
            {
                BootstrapServers = "127.0.0.1:9092,127.0.0.1:9093",
                ClientId = clientId,
                BrokerAddressFamily = BrokerAddressFamily.V4
            };
            


            using 
                var producer = new ProducerBuilder<Null, string>(config).Build();
            var messageQu = new Message<Null, string> { Value = message };
            var deliveryReport = await producer.ProduceAsync(clientId, messageQu);
            Console.WriteLine($"Message delivered to {deliveryReport.TopicPartitionOffset}");
        }

    }
}
