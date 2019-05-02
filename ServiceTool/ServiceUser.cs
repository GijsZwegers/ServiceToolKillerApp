using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    internal class ServiceUser : User
    {
        public override string Name { get; set; }
        public override bool IsActive { get; set; }

        public override bool LogOut()
        {
            throw new NotImplementedException();
        }

        public override bool SetToInactive()
        {
            throw new NotImplementedException();
        }

        public string Password { get; private set; }

        public int GetPingForCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerUser> GetCustomerUsers()
        {
            throw new NotImplementedException();
        }

        public int ResetPinForCustomer(int CustomerId, int NewPin)
        {
            throw new NotImplementedException();
        }

    }
}
