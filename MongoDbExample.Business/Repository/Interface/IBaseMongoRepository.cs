using MongoDbExample.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbExample.Business.Repository.Interface
{
    public interface IBaseMongoRepository<TModel>
    where TModel : MongoBaseModel
    {

        Task<List<TModel>> GetList();

        Task<TModel> GetById(string id);
        Task<TModel> Create(TModel model);


        Task Update(string id, TModel model);


        Task Delete(TModel model);

        Task Delete(string id);
    }

}
