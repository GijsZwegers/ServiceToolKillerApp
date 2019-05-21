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
        ServiceUserStruct Login(string Email, string Password);
        ServiceUserStruct Register(string Name, string Email, string Password);
        bool Logout();
    }
}
