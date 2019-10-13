using MongoDB.Bson;

namespace MongoDbExample.Business.Models
{
    public abstract class MongoBaseModel
    {
        /// <summary>
        /// ObjectId MongoDB’de document’lerin primary key’idir
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
