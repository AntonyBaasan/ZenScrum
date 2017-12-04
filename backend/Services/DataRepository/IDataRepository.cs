﻿using System.Collections.Generic;

namespace DataRepository
{
    public class Filter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        // TODO: not supported yet
        public string Comparator { get; set; } // "=", ">", "<"
    }

    public interface IDataRepository
    {
        List<T> GetObjects<T>();

        List<T> GetObjects<T>(Filter[] filters);

        T GetObjectById<T>(int id);

        void Create<T>(T obj);

        void Update<T>(int id, T obj);

        void Delete<T>(int id);
    }
}
