using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ServiceTool.SqlContext
{
    public class ServiceUserDAL : IServiceUser
    {
        public int GetPin()
        {
            throw new NotImplementedException();
        }

        public int GetPinForCustomer(int CustomerId)
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

        public bool ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }

        public bool SetToInactive()
        {
            throw new NotImplementedException();
        }
    }
}
