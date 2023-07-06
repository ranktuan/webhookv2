using MinvoiceWebhook.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MinvoiceWebhook.Services
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConfiguration _configuration;

        public RabbitMQConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMQ:Host"],
                UserName = _configuration["RabbitMQ:Username"],
                Password = _configuration["RabbitMQ:Password"],
                VirtualHost = _configuration["RabbitMQ:VirtualHost"],
                
            };

            return factory.CreateConnection();

        }
        public void PushMessage(MessageMOD message)
        {
            using (var connection = CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var jsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);
                channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "B",
                                 basicProperties: null,
                                 body: body);


            }
        }
    }
}
