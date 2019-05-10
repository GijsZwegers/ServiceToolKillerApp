using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Repositorys
{
    public class CompanyRepository : ICompanyDAL
    {
        private ICompanyContext CompanyContext;

        public CompanyRepository(ICompanyContext companyContext)
        {
            CompanyContext = companyContext;
        }

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
