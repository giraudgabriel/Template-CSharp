using ModeloProjeto.Domain.Entidades;
using ModeloProjeto.Infraestrutura.ORM;
using ModeloProjeto.Infraestrutura.Repositorios;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace ModeloProjeto.Application
{
    public abstract class AppService<T> : IDisposable where T : class, IEntidadeModel
    {
        protected readonly RepositorioUnitOfWork unitOfWork;

        public static string CString { get; set; } = ConfigurationManager.ConnectionStrings["ConnectionString"]?.ConnectionString;

        protected readonly long? usuarioId;

        protected AppService()
        {
            var connectionString = CString;
            var dbContext = new ModeloProjetoDbContext(connectionString);

            unitOfWork = new RepositorioUnitOfWork(dbContext, usuarioId);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }

        protected async Task<int> SalvarAsync() => await unitOfWork.SalvarAsync();
    }
}
