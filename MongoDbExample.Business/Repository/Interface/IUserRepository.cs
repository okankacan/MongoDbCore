using MongoDbExample.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Business.Repository.Interface
{
    public interface IUserRepository: IBaseMongoRepository<Users>
    {
    }
}
