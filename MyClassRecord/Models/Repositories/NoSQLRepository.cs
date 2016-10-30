using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MyClassRecord.Models.Repositories
{
    public class NoSQLRepository : IAppDataSource
    {
        private IMongoDatabase _noSqlDbContext;

        public NoSQLRepository()
        {
            _noSqlDbContext = new MongoClient(ConfigurationManager
                .ConnectionStrings["ExamMakerNoSQLContext"].ConnectionString).GetDatabase("EXAMMAKERD");
        }

        public void Add<T>(T entity) where T : class
        {
            var entityBsonDocument = entity.ToBsonDocument();

            _noSqlDbContext.GetCollection<BsonDocument>(typeof(T).Name + "s")
                .InsertOne(entityBsonDocument);
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>() where T : class
        {
            return _noSqlDbContext.GetCollection<T>(typeof (T).Name + "s")
                .Find(FilterDefinition<T>.Empty)
                .ToList();
        }

        public List<T> GetBySearchKeyword<T>(string keyword, string fieldName) where T : class
        {
            var filter = Builders<T>.Filter.Eq(fieldName, keyword);

            return _noSqlDbContext.GetCollection<T>(typeof(T).Name + "s")
                .Find(filter)
                .ToList();
        }

        public T GetById<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            throw new NotImplementedException();
        }
    }
}
