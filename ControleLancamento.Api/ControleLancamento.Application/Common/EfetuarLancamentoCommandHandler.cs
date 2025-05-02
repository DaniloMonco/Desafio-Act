using ControleLancamento.Domain.Events.Common;
using ControleLancamento.Domain.Model;
using ControleLancamento.Domain.Repository;
using MediatR;

namespace ControleLancamento.Application.Common
{
    public abstract class EfetuarLancamentoCommandHandler
    {
        private readonly ILancamentoEfetuadoPublisher _eventBus;
        private readonly ILancamentoRepository _repository;

        public EfetuarLancamentoCommandHandler(ILancamentoEfetuadoPublisher eventBus, ILancamentoRepository repository)
        {
            _eventBus = eventBus;
            _repository = repository;
        }

        protected abstract LancamentoBase CriarLancamento(DateTime dataHora, decimal valor,  string descricao);

        public async Task<Guid> EfetuarLancamento(EfetuarLancamentoCommand command, CancellationToken cancellationToken)
        {
            var lancamento = CriarLancamento(command.DataHora, command.Valor, command.Descricao);
            await _repository.Salvar(lancamento);
            await _eventBus.Publicar(lancamento);

            return lancamento.Id;
        }
    }
}
