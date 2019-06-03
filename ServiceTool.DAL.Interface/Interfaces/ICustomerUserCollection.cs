using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface.Interfaces
{
    public interface ICustomerUserCollection
    {
        CustomerUserStruct GetCustomerUser(string email);
        CustomerUserStruct Register(string name, string email, string password);
    }
}
