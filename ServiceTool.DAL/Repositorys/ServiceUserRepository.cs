using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;

namespace ServiceTool.DAL.Repositorys
{
    public class ServiceUserRepository : IServiceUser, IServiceUserCollection
    {
        private IServiceUserContext ServiceUserContext;

        public ServiceUserRepository(IServiceUserContext serviceUserContext) 
        {
            ServiceUserContext = serviceUserContext;
        }
        public int GetPin()
        {
            return ServiceUserContext.GetPin();
        }

        public int GetPinForCustomer(int CustomerId)
        {
            return ServiceUserContext.GetPinForCustomer(CustomerId);
        }

        public ServiceUserStruct Login(string email, string password)
        {
            return ServiceUserContext.Login(email, password);
        }

        public bool Logout()
        {
            return ServiceUserContext.Logout();
        }

        public ServiceUserStruct Register(string name, string email, string password)
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
