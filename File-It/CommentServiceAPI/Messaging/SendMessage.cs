using CommentServiceAPI.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CommentServiceAPI.Messaging
{
    public class SendMessage
    {
        const string _queueName = "CommentCreated";
        IModel? _Channel;

        public void createChannel(IConfiguration configuration)
        {
            var factory = new ConnectionFactory { Uri = new Uri(configuration["rabbitmqconnection"]) };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            _Channel = channel;
        }

        public void CommentCreated(string message)
        {
            
            var body = Encoding.UTF8.GetBytes(message);

            _Channel.BasicPublish(exchange: string.Empty,
                     routingKey: _queueName,
                     basicProperties: null,
                     body: body);
        }
    }
}
