using ModeloProjeto.Domain.Entidades;
using ModeloProjeto.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ModeloProjeto.Infraestrutura.Repositorios
{
    /// <summary>
    /// Classe de persistência e leitura de dados da base de dados.
    /// </summary>
    /// <typeparam name="T">Classe do tipo IEntidadeModel que representa uma entidade na base de dados.</typeparam>
    abstract class Repositorio<T> : IRepositorio<T> where T : class, IEntidadeModel
    {
        protected readonly DbContext dbContext;

        protected Repositorio(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Alterar(T model) => dbContext.Entry(model).State = EntityState.Modified;

        public virtual IQueryable<T> Buscar(Expression<Func<T, bool>> @predicate = null, int? pagina = null, int? qtdRegistros = null)
        {
            var query = dbContext.Set<T>().AsQueryable();

            if (predicate != null)
                query = query.Where(@predicate);

            AplicarPaginacao(ref query, pagina, qtdRegistros);

            return query;
        }

        public virtual IQueryable<T> Buscar(Expression<Func<T, bool>> @predicate, int pagina, int qtdRegistros, out long totalRegistros)
        {
            try
            {
                totalRegistros = dbContext.Set<T>().LongCount(predicate);

                var query = dbContext.Set<T>().Where(predicate);
                AplicarPaginacao(ref query, pagina, qtdRegistros);

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }            
        }

        public virtual IQueryable<T> Buscar<TKey>(Expression<Func<T, bool>> @predicate, int pagina, int qtdRegistros, out long totalRegistros, Expression<Func<T, TKey>> orderByExpression)
        {
            try
            {
                totalRegistros = dbContext.Set<T>().LongCount(predicate);

                var query = dbContext.Set<T>().Where(predicate);
                AplicarPaginacao(ref query, pagina, qtdRegistros, orderByExpression);

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public virtual async Task<T> BuscarPorIdAsync(long id) => await dbContext.Set<T>().FindAsync(id);

        public virtual T Excluir(T model) => dbContext.Set<T>().Remove(model);

        public virtual T Inserir(T model) => dbContext.Set<T>().Add(model);

        public virtual async Task<long> TotalRegistrosAsync(Expression<Func<T, bool>> @predicate = null)
            => predicate == null ? await dbContext.Set<T>().LongCountAsync() : await dbContext.Set<T>().LongCountAsync(predicate);

        protected static void AplicarPaginacao<TKey>(ref IQueryable<T> query, int? pagina, int? qtdRegistros, Expression<Func<T, TKey>> orderByExpression)
        {
            if (pagina.HasValue && qtdRegistros.HasValue)
                query = query.OrderBy(orderByExpression).Skip((pagina.Value - 1) * qtdRegistros.Value).Take(qtdRegistros.Value);
        }

        protected static void AplicarPaginacao(ref IQueryable<T> query, int? pagina, int? qtdRegistros)
        {
            if (pagina.HasValue && qtdRegistros.HasValue)
                query = query.OrderBy(x => x.Id).Skip((pagina.Value - 1) * qtdRegistros.Value).Take(qtdRegistros.Value);
        }

        public async Task<T> BuscarPrimeiroAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> BuscarUltimoAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>()
                .Where(predicate)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
