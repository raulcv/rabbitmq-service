using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new()
{
  Uri = new("amqp://guest:guest@localhost:5672"),
  ClientProvidedName = "RMQ Receiver App One",
};

using IConnection cnn = await factory.CreateConnectionAsync();

using IChannel channel = await cnn.CreateChannelAsync();

string exchangeName = "DemoExchangeName";
string routingKey = "DemoRoutingKey";
string queueName = "DemoQueueName";

await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct, true);
await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routingKey);
await channel.BasicQosAsync(prefetchCount: 1, prefetchSize: 0, global: false);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received: {message}");

    // Simulate some work for 5 seconds
    Console.WriteLine("Processing message...");
    await Task.Delay(5000);

    // Acknowledge the message
    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
};

string consumerTag = await channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer: consumer);
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
await channel.BasicCancelAsync(consumerTag);