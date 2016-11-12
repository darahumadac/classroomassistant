using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MyClassRecord.Models.Repositories
{
    public class Repository<T> where T : class 
    {
        private readonly IAppDataSource _dataSource;

        public Repository(IAppDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public bool Add(T entity)
        {
            return _dataSource.Add(entity);
        }

        public void Update(T entity)
        {
            _dataSource.Update(entity);
        }

        public void Delete(T entity)
        {
            _dataSource.Delete(entity);
        }

        public void Save()
        {
            _dataSource.Save();
        }

        public void Revert()
        {
            _dataSource.Revert();
        }

        public List<T> GetAll()
        {
            return _dataSource.GetAll<T>();
        }

        public T GetById(object id)
        {
            return _dataSource.GetById<T>(id);
        }

        public List<T> GetBySearchKeyword(string keyword, string fieldsToSearch)
        {
            return _dataSource.GetBySearchKeyword<T>(keyword, fieldsToSearch);
        }

        public bool Update(ObjectId id, UpdateDefinition<T> updateStatement)
        {
           return _dataSource.Update(id, updateStatement);
        }


    }

    
}
