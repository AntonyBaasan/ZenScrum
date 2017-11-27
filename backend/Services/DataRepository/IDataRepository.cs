namespace DataRepository
{
    public class Filter
    {
        string Field { get; set; }
        string Value { get; set; }
    }

    public interface IDataRepository
    {
        T[] GetObjects<T>();

        T[] GetObjects<T>(Filter[] filters);

        T GetObjectById<T>(int id);

        void Create<T>(T obj);

        void Update<T>(int id, T obj);

        void Delete<T>(int id);
    }
}
