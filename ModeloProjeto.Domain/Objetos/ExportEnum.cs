using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace ModeloProjeto.Domain.Objetos
{
    public class ExportEnum<T>
    {
        public Type Type => typeof(T);
        public IEnumerable<T> Values => Enum.GetValues(Type).Cast<T>();
        public Dictionary<string, int> Dictionary => Values.ToDictionary(e => e.ToString(), e => Convert.ToInt32(e));
        public string Json => new JavaScriptSerializer().Serialize(Dictionary);
        public string Script => $"{Type.Name}={Json};";
    }

}
