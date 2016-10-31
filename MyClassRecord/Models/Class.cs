using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyClassRecord.Models
{
    public class Class : ManagedEntity
    {
        public int Grade { get; set; }
        public string Section { get; set; }

        public Class(int grade, string section, bool isActive)
        {
            Grade = grade;
            Section = section;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Grade, Section);
        }
    }
}
