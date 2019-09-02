using ModeloProjeto.Domain.Repositorios;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ModeloProjeto.Infraestrutura.Repositorios
{
    public class RepositorioUnitOfWork : IRepositorioUnitOfWork
    {
        private readonly DbContext dbContext;
        private bool disposed;
        private readonly long? usuarioId;


        public RepositorioUnitOfWork(DbContext dbContext, long? usuarioId)
        {
            this.dbContext = dbContext;
            this.usuarioId = usuarioId;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SalvarAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                dbContext.Dispose();

            disposed = true;
        }
    }
}
