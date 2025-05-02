using ControleLancamento.Application.DebitoCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.Common
{
    public abstract record EfetuarLancamentoCommand(DateTime DataHora, decimal Valor, string Descricao) : IRequest<Guid>;
}
