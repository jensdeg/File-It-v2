using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using FileServiceAPI.Interfaces;

namespace FileServiceAPI.Messaging
{
    public class ReceiveMessage
    {
        private const string _queueName = "CommentCreated";
        
        public static void CreateChannel(IFileRepo filerepo, IConfiguration configuration)
        {

            var factory = new ConnectionFactory { Uri = new Uri(configuration["rabbitmqconnection"]) };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                filerepo.AddCommentCount(message);
            };
            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
