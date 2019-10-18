using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Repositorys
{
    public class UserRepository : IUserCollectionDAL, IAdminUserCollection
    {
        private IUserContext UserContext;

        public UserRepository(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<CompanyUserStruct> ApiGetCompanyUserAsync()
        {
            return await UserContext.ApiGetCompanyuserAsync();
        }

        public async Task<string> ApiLoginAdminAsync(string Mail, string Password)
        {
            return await ApiLoginAdminAsync(Mail, Password);
        }

        //public async Task<string> ApiLoginAsync(string Mail, string Password)
        //{
        //    return await UserContext.(Mail, Password);
        //}

        public async Task<string> ApiLoginAsync(string Mail, string Password, int Pin)
        {
            return await UserContext.ApiGetCompanyUserToken(Mail, Password, Pin);
        }

        public Task<string> ApiLoginAsync(string Mail, string Password)
        {
            throw new System.NotImplementedException();
        }

        public AdminUserStruct GetServiceUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public AdminUserStruct Register(string name, string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
