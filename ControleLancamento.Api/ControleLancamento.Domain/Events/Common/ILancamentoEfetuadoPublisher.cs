using ControleLancamento.Domain.Model;

namespace ControleLancamento.Domain.Events.Common
{
    public interface ILancamentoEfetuadoPublisher
    {
        Task Publicar(LancamentoBase model);
    }
}
