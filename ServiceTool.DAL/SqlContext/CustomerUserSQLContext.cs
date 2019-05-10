using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CustomerUserSQLContext : ICustomerUserContext
    {
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

        public bool SetToInactive()
        {
            throw new NotImplementedException();
        }
    }
}
