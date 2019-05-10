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
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public int ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }
    }
}
