using System.Threading.Tasks;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;

namespace ServiceTool.DAL.Repositorys
{
    public class ServiceUserRepository : IServiceUser, IServiceUserCollection
    {
        private ContextInterfaces.IServiceUserContext ServiceUserContext;

        public ServiceUserRepository(IServiceUserContext serviceUserContext) 
        {
            ServiceUserContext = serviceUserContext;
        }

        public Task<string> ApiLoginAsync(string Username, string Password)
        {
            return ServiceUserContext.ApiLoginAsync(Username, Password);
        }

        public int GetPin()
        {
            return ServiceUserContext.GetPin();
        }

        public int GetPinForCustomer(int CustomerId)
        {
            return ServiceUserContext.GetPinForCustomer(CustomerId);
        }

        public AdminUserStruct GetServiceUser(string email)
        {
            return ServiceUserContext.GetServiceUser(email);
        }

        public bool Logout()
        {
            return ServiceUserContext.Logout();
        }

        public AdminUserStruct Register(string name, string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool ResetPin(int NewPin)
        {
            return ServiceUserContext.ResetPin(NewPin);
        }

        public bool SetToInactive()
        {
            return ServiceUserContext.SetToInactive();
        }
    }
}
