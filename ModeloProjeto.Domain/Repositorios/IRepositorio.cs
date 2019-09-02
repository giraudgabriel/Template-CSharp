using ModeloProjeto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModeloProjeto.Domain.Repositorios
{
    public interface IRepositorio<T> where T : IEntidadeModel
    {
        void Alterar(T model);
        IQueryable<T> Buscar(Expression<Func<T, bool>> @predicate, int pagina, int qtdRegistros, out long totalRegistros);
        IQueryable<T> Buscar<TKey>(Expression<Func<T, bool>> @predicate, int pagina, int qtdRegistros, out long totalRegistros, Expression<Func<T, TKey>> orderByExpression);
        Task<T> BuscarPorIdAsync(long id);        
        Task<T> BuscarPrimeiroAsync(Expression<Func<T, bool>> @predicate);
        Task<T> BuscarUltimoAsync(Expression<Func<T, bool>> @predicate);
        T Excluir(T model);
        T Inserir(T model);
        Task<long> TotalRegistrosAsync(Expression<Func<T, bool>> @predicate = null);
    }
}
