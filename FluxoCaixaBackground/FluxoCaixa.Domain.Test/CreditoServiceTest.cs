using FluxoCaixa.Application.Messages;
using FluxoCaixa.Application.Services;
using FluxoCaixa.Domain.Model;
using FluxoCaixa.Domain.Repository;
using NSubstitute;

namespace FluxoCaixa.Application.Test
{

    public class CreditoServiceTest
    {
        private ILancamentoRepository _dao;
        public CreditoServiceTest()
        {
            _dao = Substitute.For<ILancamentoRepository>();
        }

        [Fact]
        public async Task Realizar_Lancamento_Credito()
        {
            var message = new LancamentoMessage(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, 10, "Descricao", TipoLancamentoMessageEnum.Credito);

            var lancamentoService = new LancamentoService(_dao);
            await lancamentoService.Processar(message);
            await _dao.Received().Gravar(Arg.Any<Lancamento>());
        }

        [Fact]
        public async Task Realizar_Lancamento_Debito()
        {
            var message = new LancamentoMessage(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, 10, "Descricao", TipoLancamentoMessageEnum.Debito);

            var lancamentoService = new LancamentoService(_dao);
            await lancamentoService.Processar(message);
            await _dao.Received().Gravar(Arg.Any<Lancamento>());
        }
    }
}