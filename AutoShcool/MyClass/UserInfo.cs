using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShcool.MyClass
{
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }

        public string FName { get; set; }
        public string Otchestvo { get; set; }

        public string NumGroup { get; set; }

        public string Category { get; set; }

    }
}
