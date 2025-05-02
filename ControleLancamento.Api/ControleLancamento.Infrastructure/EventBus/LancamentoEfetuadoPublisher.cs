using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Model;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Infrastructure.EventBus
{
    public class LancamentoEfetuadoPublisher : ILancamentoEfetuadoPublisher
    {
        private readonly RabbitMqConnector _connector;

        public LancamentoEfetuadoPublisher(RabbitMqConnector connector)
        {
            _connector = connector;
        }

        public Task Publicar(LancamentoBase model)
        {
            var tasks = new List<Task>(); 
            foreach (var @event in model.RecuperarEventos())
            {
                var json = JsonConvert.SerializeObject(@event);
                var utf8Bytes = Encoding.UTF8.GetBytes(json);
                tasks.Add(SendTo("lancamento.efetuado", utf8Bytes));
            }
            return Task.WhenAll(tasks);
        }

        protected async Task SendTo(string exchange, byte[] message)
        {
            var channel = await _connector.CreateChannel();
            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: "",
                body: message
            );
        }
    }
}
