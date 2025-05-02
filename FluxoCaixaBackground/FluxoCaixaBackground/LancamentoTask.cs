using ControleLancamento.Infrastructure.EventBus;
using FluxoCaixa.Application.Messages;
using FluxoCaixa.Application.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading.Channels;

namespace FluxoCaixaBackground
{
    public class LancamentoTask : BackgroundService
    {
        private readonly ILogger<LancamentoTask> _logger;
        protected readonly RabbitMqConnector _rabbitMqConnector;
        private readonly LancamentoService _lancamentoService;

        public LancamentoTask(ILogger<LancamentoTask> logger, RabbitMqConnector rabbitMqConnector, LancamentoService lancamentoService)
        {
            _logger = logger;
            _rabbitMqConnector = rabbitMqConnector;
            _lancamentoService = lancamentoService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = await _rabbitMqConnector.CreateChannel();
            await channel.QueueDeclareAsync(queue: "lancamento.efetuado.queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var lancamentoMessage = JsonConvert.DeserializeObject<LancamentoMessage>(message);

                try
                {
                    await _lancamentoService.Processar(lancamentoMessage);
                    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex, "Erro ocorreu ao tentar processar mensagem");
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
                
            };

            await channel.BasicConsumeAsync(queue: "lancamento.efetuado.queue",
                                 autoAck: false,
                                 consumer: consumer);
        }
    }
}
