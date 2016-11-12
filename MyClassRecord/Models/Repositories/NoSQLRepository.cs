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

        public bool Add<T>(T entity) where T : class
        {
            var entityBsonDocument = entity.ToBsonDocument();
            
            string className = typeof (T).Name;
            string tableName = className.Last().Equals('s') ? className + "es" : className + "s";

            try
            {
                _noSqlDbContext.GetCollection<BsonDocument>(tableName)
                    .InsertOne(entityBsonDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
             
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
            string className = typeof(T).Name;
            string tableName = className.Last().Equals('s') ? className + "es" : className + "s";

            return _noSqlDbContext.GetCollection<T>(tableName)
                .Find(FilterDefinition<T>.Empty)
                .ToList();
        }

        public List<T> GetBySearchKeyword<T>(string keyword, string fieldName) where T : class
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(fieldName, keyword);

            int numericKeyword;
            if (int.TryParse(keyword, out numericKeyword))
            {
                filter = builder.Eq(fieldName, keyword) | builder.Eq(fieldName, numericKeyword);
            }

            string className = typeof(T).Name;
            string tableName = className.Last().Equals('s') ? className + "es" : className + "s";

            return _noSqlDbContext.GetCollection<T>(tableName)
                .Find(filter)
                .ToList();
        }

        public T GetById<T>(object id) where T : class
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            
            string className = typeof(T).Name;
            string tableName = className.Last().Equals('s') ? className + "es" : className + "s";

            return (T)_noSqlDbContext.GetCollection<T>(tableName)
                .Find(filter);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            throw new NotImplementedException();
        }


        public bool Update<T>(ObjectId id, UpdateDefinition<T> updateStatement) where T : class
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            string className = typeof(T).Name;
            string tableName = className.Last().Equals('s') ? className + "es" : className + "s";

            
            var updateResult = _noSqlDbContext.GetCollection<T>(tableName)
                .UpdateOne(filter, updateStatement);

            bool wasSuccessful = updateResult.ModifiedCount == 1;

            return wasSuccessful;
        }
    }
}
