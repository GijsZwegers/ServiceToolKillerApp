using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL
{
    public class CustomerUserDAL : ICustomerUser
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
