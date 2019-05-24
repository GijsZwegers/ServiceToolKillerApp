using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface IServiceUserContext
    {
        bool ResetPin(int NewPin);
        bool SetToInactive();
        int GetPin();
        int GetPinForCustomer(int CustomerId);
        ServiceUserStruct GetServiceUser(string Email);
        ServiceUserStruct Register(string Name, string lastname, string Email, string Password);
        string GetServiceUserHashedPassword(string Email);
        bool Logout();
    }
}
