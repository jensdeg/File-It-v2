using CommentServiceAPI.Interface;
using CommentServiceAPI.Repos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CommentServiceAPI.Messaging
{
    public class ReceiveMessage
    {
        const string _queueName = "FileDeleted";
        public static void createChannel(ICommentRepository commentRepository, IConfiguration configuration)
        {
            
            var factory = new ConnectionFactory { Uri= new Uri(configuration["rabbitmqconnection"])};
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
                commentRepository.DeleteAllCommentsFromFile(message);

            };
            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);


        }

    }
}
