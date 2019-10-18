using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface.Interfaces
{
    public interface ICustomerUserCollection
    {
        CompanyUserStruct GetCustomerUser(string email);
        CompanyUserStruct Register(string name, string email, string password);
    }
}
