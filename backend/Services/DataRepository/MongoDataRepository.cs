﻿using System;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

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

        private IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public void Create<T>(T obj)
        {
            var collenction = GetCollection<T>();
            collenction.InsertOne(obj);
        }

        public void Delete<T>(string id)
        {
            var collenction = GetCollection<T>();
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            collenction.DeleteOne(filter);
        }

        public T GetObjectById<T>(string id)
        {
            var collenction = GetCollection<T>();
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return collenction.Find(filter).FirstOrDefault();
        }

        public List<T> GetObjects<T>()
        {
            var collenction = GetCollection<T>();
            return collenction.Find(Builders<T>.Filter.Empty).ToList();
        }

        public List<T> GetObjects<T>(Filter[] filters)
        {
            var collenction = GetCollection<T>();

            var filterBuilder = Builders<T>.Filter;
            FilterDefinition<T> filter = null;
            foreach (var f in filters)
                filter &= Builders<T>.Filter.Eq(f.Field, f.Value);


            if (filter == null)
                filter = Builders<T>.Filter.Empty;

            return collenction.Find(filter).ToList();

        }

        public void Update<T>(string id, T obj)
        {
            var collenction = GetCollection<T>();
            collenction.ReplaceOne(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)), obj, new UpdateOptions() { IsUpsert = true });
        }
    }
}
