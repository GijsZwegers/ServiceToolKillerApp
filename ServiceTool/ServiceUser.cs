using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class ServiceUser : User
    {
        public override string Name { get; set; }
        public override string Mail { get; set; }
        public override bool IsActive { get; set; }
        public string Role { get; } = "Service Medewerker";

        public ServiceUser(ServiceUserStruct serviceUserStruct)
        {
            this.Name = serviceUserStruct.Name;
            this.Mail = serviceUserStruct.Mail;
            this.IsActive = serviceUserStruct.IsActive;
        }

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
