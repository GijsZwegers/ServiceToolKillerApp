using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Repositorys
{
    public class CustomerUserRepository : ICustomerUser
    {
        private ICustomerUserContext CustomerUserContext;

        public CustomerUserRepository(ICustomerUserContext customerUserContext)
        {
            CustomerUserContext = customerUserContext;
        }

        public int GetPin()
        {
            return CustomerUserContext.GetPin();
        }

        public bool Login()
        {
            return CustomerUserContext.Login();
        }

        public bool Logout()
        {
            return CustomerUserContext.Logout();
        }

        public int ResetPin(int NewPin)
        {
            return CustomerUserContext.ResetPin(NewPin);
        }
    }
}
