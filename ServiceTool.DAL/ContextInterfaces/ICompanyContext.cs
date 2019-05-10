using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface ICompanyContext
    {
        List<CaseStruct> GetCasesForCompany(int CompanyId);
        List<CustomerUserStruct> GetCustomerUsersForCompany(int CompanyId);
        void DeleteCustomerUserForCompany(int CompanyId, CustomerUserStruct CustomerUser);
        CustomerUserStruct NewCustomerUser(CustomerUserStruct NewCustomerUser);
        CustomerUserStruct GetCustomerById(int id);
    }
}
