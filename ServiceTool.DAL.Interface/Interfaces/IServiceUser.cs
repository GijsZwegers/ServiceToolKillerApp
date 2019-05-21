using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface IServiceUser
    {
        bool ResetPin(int NewPin);
        bool SetToInactive();
        int GetPin();
        int GetPinForCustomer(int CustomerId);
        bool Logout();
    }
}
