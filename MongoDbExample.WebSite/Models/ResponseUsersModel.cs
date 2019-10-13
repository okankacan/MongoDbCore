using MongoDbExample.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.WebSite.Models
{
    public class ResponseUsersModel
    {
        public Users user { get; set; }
        public List<Users> users { get; set; }
    }
}
