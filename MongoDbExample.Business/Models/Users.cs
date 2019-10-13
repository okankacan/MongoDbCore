using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Business.Models
{
    public class Users : MongoBaseModel
    {
        //property’sini isimlendirmek BsonElement attribute eklenir.
        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonRequired]
        [BsonElement("Surname")]

        public string Surname { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public string Email { get; set; }

    }
}
