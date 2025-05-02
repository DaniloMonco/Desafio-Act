namespace FluxoCaixa.Domain.Model
{
    public record FluxoCaixaItem(DateOnly Data, decimal Debito, decimal Credito)
    {
        public DateOnly Data { get; protected set; } = Data;
        public decimal Debito { get; protected set; } = Debito;
        public decimal Credito { get; protected set; } = Credito;

        public decimal Saldo => Credito - Debito;

        
        protected FluxoCaixaItem() : this(default, default, default)
        {

        }
        
        public static FluxoCaixaItem Criar(DateOnly data, decimal debito, decimal credito)
            => new FluxoCaixaItem(data, debito, credito);
        public static FluxoCaixaItem Criar(DateOnly data)
            => new FluxoCaixaItem { Data = data };

        public void AdicionarValor(TipoLancamento tipoLancamento, decimal valor)
        {
            if (tipoLancamento == TipoLancamento.C)
                Credito += valor;
            else
                Debito += valor;
        }
    }
}
