using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MyClassRecord.Models.Repositories
{
    public interface IAppDataSource
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        List<T> GetAll<T>() where T : class;
        T GetById<T>(object id) where T : class;
        List<T> GetBySearchKeyword<T>(string keyword, string fieldName) where T : class;
        void Save();
        void Revert();
        void Update<T>(ObjectId id, UpdateDefinition<T> updateStatement) where T : class;
    }
}