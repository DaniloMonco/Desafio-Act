using ControleLancamento.Domain.Events;
using ControleLancamento.Domain.Model;

namespace ControleLancamento.Domain.Test
{
    public class ModelToEventTest
    {
        [Fact]
        public void Credito_Cria_LancamentoEfetuadoEvent()
        {
            var creditoDataHora = DateTime.Now;
            var credito = Credito.Lancar(creditoDataHora, 10, "Descricao");
            var eventos = credito.RecuperarEventos();

            var lancamentoEvento = (LancamentoEfetuadoEvent)eventos.First();
            Assert.Equal(credito.Id, lancamentoEvento.LancamentoId);
            Assert.Equal(credito.DataHora, lancamentoEvento.DataHora);
            Assert.Equal(credito.Valor, lancamentoEvento.Valor);
            Assert.Equal(credito.Descricao, lancamentoEvento.Descricao);
            Assert.Equal(TipoLancamentoEnum.Credito, lancamentoEvento.TipoLancamento);
        }


        [Fact]
        public void Debito_Cria_LancamentoEfetuadoEvent()
        {
            var debitoDataHora = DateTime.Now;
            var debito = Debito.Lancar(debitoDataHora, 10, "Descricao");
            var eventos = debito.RecuperarEventos();

            var lancamentoEvento = (LancamentoEfetuadoEvent)eventos.First();
            Assert.Equal(debito.Id, lancamentoEvento.LancamentoId);
            Assert.Equal(debito.DataHora, lancamentoEvento.DataHora);
            Assert.Equal(debito.Valor, lancamentoEvento.Valor);
            Assert.Equal(debito.Descricao, lancamentoEvento.Descricao);
            Assert.Equal(TipoLancamentoEnum.Debito, lancamentoEvento.TipoLancamento);
        }
    }
}