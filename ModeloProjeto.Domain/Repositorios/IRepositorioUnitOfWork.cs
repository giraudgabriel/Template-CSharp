using System;
using System.Threading.Tasks;

namespace ModeloProjeto.Domain.Repositorios
{
    public interface IRepositorioUnitOfWork : IDisposable
    {
        Task<int> SalvarAsync();
    }
}
