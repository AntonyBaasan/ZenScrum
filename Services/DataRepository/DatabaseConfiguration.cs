using MongoDB.Driver;

namespace DataRepository
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
