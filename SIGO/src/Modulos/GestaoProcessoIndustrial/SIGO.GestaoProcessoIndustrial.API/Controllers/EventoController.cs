using Microsoft.AspNetCore.Mvc;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using SIGO.Bus.EventBusRabbitMQ;
using System;

namespace SIGO.GestaoProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Evento evento = new Evento()
            {
                Nome = "Nome"
            };

            send();

            return Ok(evento);
        }

        private static void send()
        {
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "hello",
            //                         durable: false,
            //                         exclusive: false,
            //                         autoDelete: false,
            //                         arguments: null);

            //    string message = "Hello World!";
            //    var body = Encoding.UTF8.GetBytes(message);

            //    channel.BasicPublish(exchange: "",
            //                         routingKey: "hello",
            //                         basicProperties: null,
            //                         body: body);
            //}
        }
    }
}