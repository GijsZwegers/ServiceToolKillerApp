using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class Company
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }

        //private List<Case> cases = new List<Case>();

        public List<Case> GetCases()
        {
            throw new NotImplementedException();
        }

        public List<CustomerUser> GetCustomerUsers()
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerUser()
        {
            throw new NotImplementedException();
        }

        public Case GetCaseById(int id)
        {
            throw new NotImplementedException();
        }

        public void NewCase()
        {
            throw new NotImplementedException();
        }

        public void NewCustomer()
        {
            throw new NotImplementedException();
        }

        public CustomerUser GetCustomerUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
