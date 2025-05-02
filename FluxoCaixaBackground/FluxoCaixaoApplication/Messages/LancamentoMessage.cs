using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Messages
{
    public record LancamentoMessage(Guid EventId, DateTime TimeStamp, Guid LancamentoId, DateTime DataHora, decimal Valor, string Descricao, TipoLancamentoMessageEnum TipoLancamento);
}
