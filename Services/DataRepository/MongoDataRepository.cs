using System;
using MongoDB.Driver;

namespace DataRepository
{
    public class MongoDataRepository : IDataRepository
    {
        private string _mongoDbName;
        private IMongoClient _client;
        private IMongoDatabase _database;

        public MongoDataRepository(IMongoClient mongoClient, string databaseName = "ZenScrumDB")
        {
            _client = mongoClient;
            _mongoDbName = databaseName;
            _database = _client.GetDatabase(_mongoDbName);
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
