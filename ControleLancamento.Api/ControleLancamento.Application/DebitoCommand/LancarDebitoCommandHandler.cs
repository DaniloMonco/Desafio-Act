using ControleLancamento.Application.Common;
using ControleLancamento.Application.CreditoCommand;
using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Model;
using ControleLancamento.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.DebitoCommand
{
    public sealed  class LancarDebitoCommandHandler : EfetuarLancamentoCommandHandler, IRequestHandler<LancarDebitoCommand, Guid>
    {
        public LancarDebitoCommandHandler(ILancamentoEfetuadoPublisher eventBus, ILancamentoRepository repository) 
            : base(eventBus, repository)
        {
        }

        public Task<Guid> Handle(LancarDebitoCommand request, CancellationToken cancellationToken)
            => EfetuarLancamento(request, cancellationToken);
        

        protected override LancamentoBase CriarLancamento(DateTime dataHora, decimal valor, string descricao)
            => Debito.Lancar(dataHora, valor, descricao);
        
    }
}
