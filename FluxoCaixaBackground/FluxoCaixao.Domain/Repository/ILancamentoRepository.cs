using FluxoCaixa.Domain.Model;

namespace FluxoCaixa.Domain.Repository
{
    public interface ILancamentoRepository
    {
        Task<int> Gravar(Lancamento lancamento);
    }
}
