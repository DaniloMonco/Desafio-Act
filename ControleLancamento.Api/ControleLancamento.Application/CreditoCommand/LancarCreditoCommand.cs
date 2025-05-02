using ControleLancamento.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.CreditoCommand
{
    public record LancarCreditoCommand(DateTime DataHora, decimal Valor, string Descricao) 
        : EfetuarLancamentoCommand(DataHora, Valor, Descricao);
}
