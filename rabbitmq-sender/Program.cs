using RabbitMQ.Client;
using System;
using System.Text;

ConnectionFactory factory = new()
{
  ClientProvidedName = "RabbitMQ Sender App",
  HostName = "localhost",
  Port = 5672,
};

using IConnection cnn = await factory.CreateConnectionAsync();

using IChannel channel = await cnn.CreateChannelAsync();

string exchangeName = "DemoExchangeName";
string routingKey = "DemoRoutingKey";
string queueName = "DemoQueueName";

await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct, true);
await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routingKey);

string message = "Hello, RabbitMQ";
for (int i = 1; i < 61; i++)
{
  Console.WriteLine($"Sending message: {message} #{i}!");
  byte[] messageBody = Encoding.UTF8.GetBytes(message + $" #{i}!");
  await channel.BasicPublishAsync(exchange: exchangeName, routingKey: routingKey, body: messageBody);
  Console.WriteLine($" [x] Sent: {message}");
  // Simulate some delay 
  Thread.Sleep(1000); // 1 second delay
}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();