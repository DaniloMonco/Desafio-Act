using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Model;
using ControleLancamento.Domain.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.Test
{
    public class EfetuarLancamentoCommandHandlerTest
    {
        private ILancamentoEfetuadoPublisher _lancamentoEventBus;
        private ILancamentoRepository _repository;

        public EfetuarLancamentoCommandHandlerTest()
        {
            _lancamentoEventBus = Substitute.For<ILancamentoEfetuadoPublisher>();
            _repository = Substitute.For<ILancamentoRepository>();
        }


        [Fact]
        public async Task Executar_CreditoCommandHandler_Quando_CreditoCommand_Executado()
        {
            var command = new CreditoCommand.LancarCreditoCommand(DateTime.Now, 10, "Descricao");
            var handler = new CreditoCommand.LancarCreditoCommandHandler(_lancamentoEventBus, _repository);
            await handler.Handle(command, CancellationToken.None);

            await _lancamentoEventBus.Received().Publicar(Arg.Any<Credito>());
            await _repository.Received().Salvar(Arg.Any<Credito>());
        }

        [Fact]
        public async Task Executar_DebitoCommandHandler_Quando_DebitoCommand_Executado()
        {
            var command = new DebitoCommand.LancarDebitoCommand(DateTime.Now, 10, "Descricao");
            var handler = new DebitoCommand.LancarDebitoCommandHandler(_lancamentoEventBus, _repository);
            await handler.Handle(command, CancellationToken.None);

            await _lancamentoEventBus.Received().Publicar(Arg.Any<Debito>());
            await _repository.Received().Salvar(Arg.Any<Debito>());
        }

    }
}
