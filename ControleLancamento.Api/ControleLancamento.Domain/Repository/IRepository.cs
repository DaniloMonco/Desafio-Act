using ControleLancamento.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Domain.Repository
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task Salvar(T model);
    }
}
