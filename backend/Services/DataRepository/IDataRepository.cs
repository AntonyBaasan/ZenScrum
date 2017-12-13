using System.Collections.Generic;

namespace DataRepository
{
    public class Filter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        // TODO: not supported yet
        public string Comparator { get; set; } // "=", ">", "<"
    }

    public interface IDataRepository<T>
    {
        List<T> GetObjects();

        List<T> GetObjects(Filter[] filters);

        T GetObjectById(string id);

        void Create(T obj);

        void Update(string id, T obj);

        void UpdateProperty(string id, string propertyName, object value);

        void Delete(string id);
    }
}
