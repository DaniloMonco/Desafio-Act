namespace ControleLancamento.Api.Request
{
    public record EfetuarLancamentoRequest(DateTime DataHora, decimal Valor, string Descricao);

}
