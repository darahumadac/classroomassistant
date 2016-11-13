using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Models
{
    public class Student : ManagedEntity
    {
        [DisplayName("Student Number")]
        public string StudentNumber { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Browsable(false)]
        public ObjectId ClassId { get; set; }
        
        [DisplayName("Grade/Section")]
        public Class GradeAndSection { get; set; }

        public Student() { }
        public Student(string studentNum, string firstName, string middleName,
            string lastName, ObjectId classId, bool isActive)
        {
            StudentNumber = studentNum;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            ClassId = classId;
            GradeAndSection = LazyLoadingRepository.ClassRepository.GetById(ClassId);
            IsActive = isActive;
        }

    }
}
