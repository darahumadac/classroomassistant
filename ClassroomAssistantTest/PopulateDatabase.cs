using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MyClassRecord;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace ClassroomAssistantTest
{
    [TestClass]
    public class PopulateDatabase
    {
        private IMongoDatabase _noSqlDb;

        public PopulateDatabase()
        {
            _noSqlDb = new MongoClient(ConfigurationManager
                .ConnectionStrings["ExamMakerNoSQLContext"].ConnectionString).GetDatabase("EXAMMAKERD");
        }

        [TestMethod]
        public void PopulateStudents()
        {
            LazyLoadingRepository.ClassRepository = new Repository<Class>(new NoSQLRepository());
            Program.LoggedInUser = new User("darah", "darah", true);
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 15; i++)
            {
                Student newStudent = new Student("1092654"+i,"STUDENT "+i, 
                    "MID "+i, 
                    "LASTNAME "+i,
                    new ObjectId("58175517c74322225c41f733"), 
                    true);

                students.Add(newStudent);
            }

            for (int j = 1; j <= 1000; j++)
            {
                Student newStudent = new Student("1092654" + j, "STUDENT " + j,
                    "MID " + j,
                    "LASTNAME",
                    new ObjectId("58175517c74322225c41f753"), 
                    true);

                students.Add(newStudent);
            }

            _noSqlDb.GetCollection<Student>("Students").InsertMany(students);
        }

        [TestMethod]
        public void PopulateClasses()
        {
            Program.LoggedInUser = new User("darah", "darah", true);
            List<Class> classes = new List<Class>();
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    Class newClass = new Class(i, "SECTION " + j, true);
                    classes.Add(newClass);
                }
                
            }

            _noSqlDb.GetCollection<Class>("Classes").InsertMany(classes);
        }
    }
}
