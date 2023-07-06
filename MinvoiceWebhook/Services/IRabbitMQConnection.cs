using MinvoiceWebhook.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MinvoiceWebhook.Services
{
    public interface IRabbitMQConnection
    {
        IConnection CreateConnection();
        void PushMessage(MessageMOD message);
    }
    
}
