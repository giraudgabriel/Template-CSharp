using ModeloProjeto.Domain.Entidades;
using ModeloProjeto.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModeloProjeto.Domain.Services
{
    public abstract class DomainService<T> where T : class, IEntidadeModel
    {
        protected readonly IRepositorio<T> repositorio;

        protected DomainService(IRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public virtual void Alterar(T model) => repositorio.Alterar(model);
        public virtual IQueryable<T> Buscar(Expression<Func<T, bool>> @predicate, int pagina, int qtdRegistros, out long totalRegistros) => repositorio.Buscar(@predicate, pagina, qtdRegistros, out totalRegistros);
        public virtual async Task<T> BuscarPorIdAsync(long id) => await repositorio.BuscarPorIdAsync(id);
        public virtual async Task<T> BuscarPrimeiroAsync(Expression<Func<T, bool>> @predicate) => await repositorio.BuscarPrimeiroAsync(@predicate);
        public virtual async Task<T> BuscarUltimoAsync(Expression<Func<T, bool>> @predicate) => await repositorio.BuscarUltimoAsync(@predicate);
        public virtual T Excluir(T model) => repositorio.Excluir(model);
        public virtual T Inserir(T model) => repositorio.Inserir(model);
        public virtual async Task<long> TotalRegistrosAsync(Expression<Func<T, bool>> @predicate = null) => await repositorio.TotalRegistrosAsync(predicate);
    }
}
