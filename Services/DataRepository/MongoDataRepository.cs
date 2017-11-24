using System;
using MongoDB.Driver;

namespace DataRepository
{
    public class MongoDataRepository : IDataRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public MongoDataRepository(DatabaseConfiguration dbConfig)
        {
            _client = new MongoClient(dbConfig.ConnectionString);
            _database = _client.GetDatabase(dbConfig.DatabaseName);
        }

        public void Create<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T GetObjectById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T[] GetObjects<T>()
        {
            var collenction = _database.GetCollection<T>(typeof(T).Name);
            return collenction.Find(_ => true).ToList<T>().ToArray();
        }

        public T[] GetObjects<T>(Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }
    }
}
