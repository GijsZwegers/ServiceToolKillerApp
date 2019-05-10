using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.SqlContext
{
    public class CompanySQLContext : ICompanyContext
    {
        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="CustomerUser"></param>
        
        public void DeleteCustomerUserForCompany(int CompanyId, CustomerUserStruct CustomerUser)
        {
            throw new NotImplementedException();
        }

        public List<CaseStruct> GetCasesForCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public CustomerUserStruct GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerUserStruct> GetCustomerUsersForCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public CustomerUserStruct NewCustomerUser(CustomerUserStruct NewCustomerUser)
        {
            throw new NotImplementedException();
        }
    }
}
