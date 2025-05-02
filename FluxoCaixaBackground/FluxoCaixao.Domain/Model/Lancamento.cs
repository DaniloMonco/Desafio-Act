namespace FluxoCaixa.Domain.Model
{
    public record Lancamento(Guid Id, DateTime DataHora, decimal Valor, string Descricao, TipoLancamento TipoLancamento)
    {
        public Guid Id { get; protected set; } = Id;
        public DateTime DataHora { get; protected set; } = DataHora;
        public decimal Valor { get; protected set; } = Valor;
        public string Descricao { get; protected set; } = Descricao;
        public TipoLancamento TipoLancamento { get; protected set; } = TipoLancamento;
    }
}
