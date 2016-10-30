using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyClassRecord.Models
{
    public class User
    {
        [BsonId]
        [Browsable(false)]
        public ObjectId UserId { get; set; }

        public string Username { get; set; }
        
        [Browsable(false)]
        [StringLength(16, MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Administrator?")]
        public bool IsAdmin { get; set; }

        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Browsable(false)]
        public bool IsExisting
        {
            get { return UserId != ObjectId.Empty; }
        }

        public User() { }
        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}