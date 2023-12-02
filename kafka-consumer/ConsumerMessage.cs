using Confluent.Kafka;

namespace kafka_consumer
{
    public class ConsumerMessage
    {
        private readonly string clientId = "my-poc";
        private readonly string groupId = "my-group";

        public void ReadMessage()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "127.0.0.1:29092,127.0.0.1:29093",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                ClientId = clientId,
                GroupId = groupId,
                BrokerAddressFamily = BrokerAddressFamily.V4
            };

            using
                var consumer = new ConsumerBuilder<Ignore, String>(config).Build();
            consumer.Subscribe(clientId);
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Message recieved from {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("The consumer was stopped via cancellation token");
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
