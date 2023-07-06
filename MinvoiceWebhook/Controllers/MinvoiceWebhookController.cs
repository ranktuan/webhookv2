using Microsoft.AspNetCore.Mvc;
using MinvoiceWebhook.Models;
using MinvoiceWebhook.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Reflection;
using System.Text;

namespace MinvoiceWebhook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinvoiceWebhookController : ControllerBase
    {
        
        private readonly IRabbitMQConnection _rabbitMQConnection;
       
        public MinvoiceWebhookController(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
        }

        [HttpPost]
        public IActionResult SendMessage(MessageMOD message)
        {
            
            _rabbitMQConnection.PushMessage(message);

            return Ok("okok");
        }
        
    }
}
