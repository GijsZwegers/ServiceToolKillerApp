using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public static class Company
    {
        public static string Name { get; private set; }
        public static bool Active { get; private set; }

        private static List<Case> cases = new List<Case>();

        public static List<Case> GetCases()
        {
            throw new NotImplementedException();
        }

        public static List<CustomerUser> GetCustomerUsers()
        {
            throw new NotImplementedException();
        }

        public static void DeleteCustomerUser()
        {
            throw new NotImplementedException();
        }

        public static Case GetCaseById(int id)
        {
            throw new NotImplementedException();
        }

        public static void NewCase()
        {
            throw new NotImplementedException();
        }

        public static void NewCustomer()
        {
            throw new NotImplementedException();
        }

        public static CustomerUser GetCustomerUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
