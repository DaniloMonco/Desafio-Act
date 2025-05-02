using FluxoCaixa.Application.Messages;
using FluxoCaixa.Domain.Model;

namespace FluxoCaixa.Application.Mappers
{
    public static class LancamentoMapper
    {
        public static Lancamento ToModel(this LancamentoMessage message)
            => new Lancamento(message.LancamentoId, message.DataHora, message.Valor, message.Descricao, (TipoLancamento)message.TipoLancamento);
    }
}
