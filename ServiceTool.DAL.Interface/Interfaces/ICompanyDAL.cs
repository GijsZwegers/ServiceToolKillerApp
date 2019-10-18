using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICompanyDAL
    {
        List<CaseStruct> GetCasesForCompany(int CompanyId);
        List<CompanyUserStruct> GetCustomerUsersForCompany(int CompanyId);
        void DeleteCustomerUserForCompany(int CompanyId, CompanyUserStruct CustomerUser);
        CompanyUserStruct NewCustomerUser(CompanyUserStruct NewCustomerUser);
        CompanyUserStruct GetCustomerById(int id);
    }
}
