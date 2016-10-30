using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyClassRecord.Models
{
    public class ManagedEntity
    {
        [BsonId]
        [Browsable(false)]
        public ObjectId Id { get; set; }

        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Browsable(false)]
        public string CreatedBy { get; set; }

        [Browsable(false)]
        public DateTime CreatedDate { get; set; }

        [Browsable(false)]
        public string UpdatedBy { get; set; }

        [Browsable(false)]
        public DateTime UpdatedDate { get; set; }


        public ManagedEntity()
        {
            CreatedBy = Program.LoggedInUser.Username;
            CreatedDate = DateTime.Now;
            UpdatedBy = Program.LoggedInUser.Username;
            UpdatedDate = DateTime.Now;
        }

    }
}
