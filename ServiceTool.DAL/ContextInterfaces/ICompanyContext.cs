using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface ICompanyContext
    {
        List<CaseStruct> GetCasesForCompany(int CompanyId);
        List<CompanyUserStruct> GetCustomerUsersForCompany(int CompanyId);
        void DeleteCustomerUserForCompany(int CompanyId, CompanyUserStruct CustomerUser);
        CompanyUserStruct NewCustomerUser(CompanyUserStruct NewCustomerUser);
        CompanyUserStruct GetCustomerById(int id);
    }
}
