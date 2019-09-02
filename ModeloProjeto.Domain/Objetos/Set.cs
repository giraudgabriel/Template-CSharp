using System.Collections.Generic;

namespace ModeloProjeto.Domain.Objetos
{
    public class Set<T> where T : class
    {
        public Set()
        {
        }

        public Set(long totalRegistros, IEnumerable<T> registros)
        {
            TotalRegistros = totalRegistros;
            Registros = registros;
        }

        public IEnumerable<T> Registros { get; set; }

        public long TotalRegistros { get; set; }
    }
}
