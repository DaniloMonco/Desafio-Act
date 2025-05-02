using ControleLancamento.Domain.Events.Common;

namespace ControleLancamento.Domain.Events
{
    public record LancamentoEfetuadoEvent(Guid LancamentoId, DateTime DataHora, decimal Valor, string Descricao, TipoLancamentoEnum TipoLancamento) : DomainEvent
    {
        public Guid LancamentoId { get; protected set; } = LancamentoId;
        public DateTime DataHora { get; protected set; } = DataHora;
        public decimal Valor { get; protected set; } = Valor;
        public string Descricao { get; protected set; } = Descricao;
        public TipoLancamentoEnum TipoLancamento { get; protected set; } = TipoLancamento;
    }
}
