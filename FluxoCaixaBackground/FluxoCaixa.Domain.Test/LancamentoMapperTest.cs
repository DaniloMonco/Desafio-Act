using FluxoCaixa.Application.Messages;
using FluxoCaixa.Domain.Model;

namespace FluxoCaixa.Application.Test
{
    /*
    public class LancamentoMapperTest
    {
        private DateTime _dataHora = new DateTime(2024, 8, 12);
        private Guid _eventId = Guid.NewGuid();
        private Guid _lancamentoId = Guid.NewGuid();
        private decimal _valor = 10;
        private string _descricao = "Descricao";
        private DateTime _timeStamp = DateTime.Now;

        [Fact]
        public void Mapear_CreditoMessage_Para_CreditoModel()
        {
            var message = new LancamentoMessage(_eventId, _timeStamp, _lancamentoId, _dataHora, _valor, _descricao, TipoLancamentoMessageEnum.Credito);

            var credito = message.ToModel();
            Assert.Equal(_dataHora, credito.DataHora);
            Assert.Equal(_valor, credito.Valor);
            Assert.Equal(_descricao, credito.Descricao);
            Assert.Equal(TipoLancamento.C, credito.TipoLancamento);
            Assert.Equal(_lancamentoId, credito.Id);
        }

        [Fact]
        public void Mapear_DebitoMessage_Para_DebitoModel()
        {
            var message = new LancamentoMessage(_eventId, _timeStamp, _lancamentoId, _dataHora, _valor, _descricao, TipoLancamentoMessageEnum.Debito);

            var debito = message.ToModel();
            Assert.Equal(_dataHora, debito.DataHora);
            Assert.Equal(_valor, debito.Valor);
            Assert.Equal(_descricao, debito.Descricao);
            Assert.Equal(TipoLancamento.D, debito.TipoLancamento);
            Assert.Equal(_lancamentoId, debito.Id);
        }
    }
    */
}