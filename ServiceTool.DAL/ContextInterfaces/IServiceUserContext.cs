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
        bool Login();
        bool Logout();
    }
}
