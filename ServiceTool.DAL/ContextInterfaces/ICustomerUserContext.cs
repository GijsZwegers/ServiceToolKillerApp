using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface ICustomerUserContext
    {
        int ResetPin(int NewPin);
        int GetPin();
        bool Login();
        bool Logout();
    }
}
