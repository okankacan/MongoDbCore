using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbExample.Business.Models;
using MongoDbExample.Business.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbExample.Business.Repository
{
    public class BaseMongoRepository<TModel> : IBaseMongoRepository<TModel>
    where TModel : MongoBaseModel
    {
        private readonly IMongoCollection<TModel> mongoCollection;

        public BaseMongoRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<TModel>(collectionName);
        }


        async Task<List<TModel>> IBaseMongoRepository<TModel>.GetList()
        {
            return mongoCollection.Find(book => true).ToList();
            ;
        }

        async Task<TModel> IBaseMongoRepository<TModel>.GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<TModel>(m => m.Id == docId).FirstOrDefault();
        }

        async Task<TModel> IBaseMongoRepository<TModel>.Create(TModel model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

       async Task IBaseMongoRepository<TModel>.Update(string id, TModel model)
        {
            var docId = new ObjectId(id);
            model.Id = docId;
            var result = mongoCollection.ReplaceOne(m => m.Id == docId, model);
        }

        async Task IBaseMongoRepository<TModel>.Delete(TModel model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

       async Task IBaseMongoRepository<TModel>.Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == docId);
        }
    }
}
