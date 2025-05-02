
using ControleLancamento.Domain.Events;
using ControleLancamento.Domain.Extensions;

namespace ControleLancamento.Domain.Model
{
    public class Credito : LancamentoBase
    {
        protected Credito(DateTime dataHora, decimal valor, string descricao)
            : base(dataHora, valor, descricao)
        {
        }

        protected override TipoLancamento DefinirTipoLancamento() => TipoLancamento.C;

        public static Credito Lancar(DateTime dataHora, decimal valor, string descricao)
        {
            var credito = new Credito(dataHora, valor, descricao);
            var @event = credito.ToLancamentoEfetuadoEvent();
            credito.AdicionarEvento(@event);

            return credito;
        }
    }
}
