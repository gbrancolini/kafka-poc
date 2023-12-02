namespace kafka_publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ProduceMessage produceMessage = new ProduceMessage();
            _ = produceMessage.CreateMessage("Testing");
            Console.ReadLine();
        }
    }
}
