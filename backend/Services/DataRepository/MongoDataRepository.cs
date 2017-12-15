using System;
using MongoDB.Driver;
using System.Collections.Generic;
using Domain;
using MongoDB.Bson;

namespace DataRepository
{
    public class MongoDataRepository<T> : IDataRepository<T> where T : BaseObject
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public MongoDataRepository(DatabaseConfiguration dbConfig)
        {
            _client = new MongoClient(dbConfig.ConnectionString);
            _database = _client.GetDatabase(dbConfig.DatabaseName);
        }

        private IMongoCollection<T> GetCollection()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public void Create(T obj)
        {
            var collenction = GetCollection();
            collenction.InsertOne(obj);
        }

        public void Delete(string id)
        {
            var collenction = GetCollection();
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            collenction.DeleteOne(filter);
        }

        public T GetObjectById(string id)
        {
            var collenction = GetCollection();
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return collenction.Find(filter).FirstOrDefault();
        }

        public List<T> GetObjects()
        {
            var collenction = GetCollection();
            return collenction.Find(Builders<T>.Filter.Empty).ToList();
        }

        public List<T> GetObjects(Filter[] filters)
        {
            var collenction = GetCollection();

            var filterBuilder = Builders<T>.Filter;
            FilterDefinition<T> filter = null;
            foreach (var f in filters)
                filter &= Builders<T>.Filter.Eq(f.Field, f.Value);


            if (filter == null)
                filter = Builders<T>.Filter.Empty;

            return collenction.Find(filter).ToList();
        }

        public void Update(string id, T obj)
        {
            var collenction = GetCollection();
            var objId = ObjectId.Parse(id);
            collenction.ReplaceOne(Builders<T>.Filter.Eq("_id", objId), obj, new UpdateOptions() {IsUpsert = true});
            obj.Id = objId;
        }

        public void UpdateProperty(string id, string propertyName, object value)
        {
            throw new NotImplementedException();
        }
    }
}