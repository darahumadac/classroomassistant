//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Driver.Core.Configuration;
//using MyClassRecord;
//using MyClassRecord.Models;

//namespace ClassroomAssistantTest
//{
//    //[TestClass]
//    public class MyClassRecordStudentsTests
//    {
//        private IMongoDatabase _noSqlDbContext;

//        public MyClassRecordStudentsTests()
//        {
//            _noSqlDbContext = new MongoClient(ConfigurationManager
//                .ConnectionStrings["ExamMakerNoSQLContext"].ConnectionString).GetDatabase("EXAMMAKERD");

//            //set up logged in user
//            Program.LoggedInUser = new User("darah", "darah", true);
//        }

//        [TestInitialize]
//        public void addStudents()
//        {
//            Student testStudent1 = new Student()
//            {
//                FirstName = "Darah",
//                MiddleName = "Francisco",
//                LastName = "Umadac",
//                GradeAndSection = new Class(1, "Gumamela", true),
//                IsActive = true
//            };

//            Student testStudent2 = new Student("10926542", "Betty", "Francisco", "Boop", new Class(6, "Kalachuchi", true), true);

//            List<BsonDocument> students = new List<BsonDocument>();
//            students.Add(testStudent1.ToBsonDocument());
//            students.Add(testStudent2.ToBsonDocument());

//            _noSqlDbContext.GetCollection<BsonDocument>("Students")
//                .InsertMany(students);
//        }

//        [TestCleanup]
//        public void removeStudents()
//        {
//            var builder = Builders<BsonDocument>.Filter;
//            var filter = builder.Eq("FirstName", "Darah") | builder.Eq("FirstName", "Betty");
//            _noSqlDbContext.GetCollection<BsonDocument>("Students")
//                .DeleteMany(filter);
//        }

//        [TestMethod]
//        public void AddStudents()
//        {
//            List<Student> studentList = _noSqlDbContext.GetCollection<Student>("Students")
//                .Find(FilterDefinition<Student>.Empty).ToList();

//            Assert.AreEqual(2, studentList.Count);
//        }

//        [TestMethod]
//        public void AddedStudentMustHaveCorrectInformation_Default()
//        {
//            var builder = Builders<Student>.Filter;
//            var filter = builder.Eq("FirstName", "Darah") 
//                         & builder.Eq("LastName", "Umadac")
//                         & builder.Eq("MiddleName", "Francisco") 
//                         & builder.Eq("GradeAndSection.Grade", 1)
//                         & builder.Eq("GradeAndSection.Section", "Gumamela") 
//                         & builder.Eq("IsActive", true);

//            List<Student> studentList = _noSqlDbContext.GetCollection<Student>("Students")
//                .Find(filter).ToList();

//            Assert.AreEqual(1, studentList.Count);
//        }

//        [TestMethod]
//        public void AddedStudentMustHaveCorrectInformation_StudentConstructor()
//        {
//            var builder = Builders<Student>.Filter;
//            var filter = builder.Eq("FirstName", "Betty")
//                         & builder.Eq("LastName", "Boop")
//                         & builder.Eq("MiddleName", "Francisco")
//                         & builder.Eq("GradeAndSection.Grade", 6)
//                         & builder.Eq("GradeAndSection.Section", "Kalachuchi")
//                         & builder.Eq("IsActive", true);

//            List<Student> studentList = _noSqlDbContext.GetCollection<Student>("Students")
//                .Find(filter).ToList();

//            Assert.AreEqual(1, studentList.Count);
//        }



//    }
//}
