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

        public void DeleteCustomerUserForCompany(int CompanyId, CompanyUserStruct CustomerUser)
        {
            CompanyContext.DeleteCustomerUserForCompany(CompanyId, CustomerUser);
        }

        public List<CaseStruct> GetCasesForCompany(int CompanyId)
        {
            return CompanyContext.GetCasesForCompany(CompanyId);
        }

        public CompanyUserStruct GetCustomerById(int id)
        {
            return CompanyContext.GetCustomerById(id);
        }

        public List<CompanyUserStruct> GetCustomerUsersForCompany(int CompanyId)
        {
            return CompanyContext.GetCustomerUsersForCompany(CompanyId);
        }

        public CompanyUserStruct NewCustomerUser(CompanyUserStruct NewCustomerUser)
        {
            return CompanyContext.NewCustomerUser(NewCustomerUser);
        }
    }
}
