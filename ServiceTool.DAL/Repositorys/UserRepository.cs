using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Repositorys
{
    public class UserRepository : IUserCollectionDAL
    {
        private IUserContext UserContext;

        public UserRepository(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<ServiceUserStruct> ApiGetCustomerAsync()
        {
            return await UserContext.ApiGetCustomerAsync();
        }

        public async Task<string> ApiLoginAdminAsync(string Mail, string Password)
        {
            return await UserContext.ApiLoginAdminAsync(Mail, Password);
        }

        public async Task<string> ApiLoginAsync(string Mail, string Password)
        {
            return await UserContext.ApiLoginAsync(Mail, Password);
        }

        public async Task<string> ApiLoginAsync(string Mail, string Password, int Pin)
        {
            return await UserContext.ApiLoginAsync(Mail, Password, Pin);
        }
    }
}
