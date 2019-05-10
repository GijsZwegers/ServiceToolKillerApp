using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Repositorys
{
    public class ServiceUserRepository : IServiceUser
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

        public bool Login()
        {
            return ServiceUserContext.Login();
        }

        public bool Logout()
        {
            return ServiceUserContext.Logout();
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
