using FluxoCaixa.Application.Mappers;
using FluxoCaixa.Application.Messages;
using FluxoCaixa.Domain.Repository;

namespace FluxoCaixa.Application.Services
{
    public sealed class LancamentoService
    {
        private readonly ILancamentoRepository _dao;
        public LancamentoService(ILancamentoRepository dao)
        {
            _dao = dao;
        }

        public async Task Processar(LancamentoMessage message)
        {
            if (message is null)
                throw new ArgumentNullException("Lancamento Message");

            var entity = message.ToModel();
            await _dao.Gravar(entity);
        }
    }
}
