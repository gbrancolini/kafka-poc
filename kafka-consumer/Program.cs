namespace kafka_consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Consumer!");
            ConsumerMessage message = new ConsumerMessage();
            message.ReadMessage();
            Console.ReadLine();
        }
    }
}
