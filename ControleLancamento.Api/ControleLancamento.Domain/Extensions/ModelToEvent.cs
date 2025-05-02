using ControleLancamento.Domain.Events;
using ControleLancamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Domain.Extensions
{
    internal static class ModelToEvent
    {
        public static LancamentoEfetuadoEvent ToLancamentoEfetuadoEvent(this Credito credito)
            => new LancamentoEfetuadoEvent(credito.Id, credito.DataHora, credito.Valor, credito.Descricao, (TipoLancamentoEnum)credito.TipoLancamento);

        public static LancamentoEfetuadoEvent ToLancamentoEfetuadoEvent(this Debito debito)
            => new LancamentoEfetuadoEvent(debito.Id, debito.DataHora, debito.Valor, debito.Descricao, (TipoLancamentoEnum)debito.TipoLancamento);
    }
}
