using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Repositorys
{
    public class UserRepository : Interface.IUserCollectionDAL
    {
        private IUserContext UserContext;

        public UserRepository(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public Task<ServiceUserStruct> ApiGetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAdminAsync(string Mail, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAsync(string Mail, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAsync(string Mail, string Password, int Pin)
        {
            throw new NotImplementedException();
        }
    }
}
