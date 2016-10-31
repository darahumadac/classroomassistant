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
            Program.LoggedInUser = new User("darah", "darah", true);
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 15; i++)
            {
                Student newStudent = new Student("1092654"+i,"STUDENT "+i, 
                    "MID "+i, 
                    "LASTNAME "+i, 
                    new Class(i, "SECTION 1"));

                students.Add(newStudent);
            }

            for (int j = 1; j <= 1000; j++)
            {
                Student newStudent = new Student("1092654" + j, "STUDENT " + j,
                    "MID " + j,
                    "LASTNAME",
                    new Class(1, "SECTION 1"));

                students.Add(newStudent);
            }

            _noSqlDb.GetCollection<Student>("Students").InsertMany(students);
        }
    }
}
