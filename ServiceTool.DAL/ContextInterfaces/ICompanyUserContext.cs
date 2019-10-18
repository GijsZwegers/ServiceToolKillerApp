using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface ICompanyUserContext
    {
        int ResetPin(int NewPin);
        int GetPin();
        bool Login();
        bool Logout();
        CompanyUserStruct GetCustomerUser(string mail, string password);
    }
}
