using MongoDbExample.Business.Models;
using MongoDbExample.Business.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Business.Repository
{
    public class UserRepository : BaseMongoRepository<Users> , IUserRepository
    {
        public UserRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }
    }
}
