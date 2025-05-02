using ControleLancamento.Application.Common;
using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Model;
using ControleLancamento.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.CreditoCommand
{
    public sealed class LancarCreditoCommandHandler : EfetuarLancamentoCommandHandler, IRequestHandler<LancarCreditoCommand, Guid>
    {
        public LancarCreditoCommandHandler(ILancamentoEfetuadoPublisher eventBus, ILancamentoRepository repository) 
            : base(eventBus, repository)
        {
        }

        public Task<Guid> Handle(LancarCreditoCommand request, CancellationToken cancellationToken)
            => EfetuarLancamento(request, cancellationToken);
        

        protected override LancamentoBase CriarLancamento(DateTime dataHora, decimal valor, string Descricao)
            => Credito.Lancar(dataHora, valor, Descricao);
        
    }
}
