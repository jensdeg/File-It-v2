using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;


namespace FileServiceAPI.Messaging
{
    public class SendMessage
    {
        const string _queueName = "FileDeleted";
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

        public void FileDeleted(string fileid)
        {
            var body = Encoding.UTF8.GetBytes(fileid);

            _Channel.BasicPublish(exchange: string.Empty,
                     routingKey: _queueName,
                     basicProperties: null,
                     body: body);
        }
    }
}
