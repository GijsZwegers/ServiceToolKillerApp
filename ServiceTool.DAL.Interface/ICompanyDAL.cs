using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICompanyDAL
    {
        List<CaseStruct> GetCasesForCompany(int CompanyId);
        List<CustomerUserStruct> GetCustomerUsersForCompany(int CompanyId);
        void DeleteCustomerUserForCompany(int CompanyId, CustomerUserStruct CustomerUser);
        //CaseStruct GetCaseById();     NODIG? AANGEZIEN DIT IN CASECOLLECITON OOK AL ZIT
        //NewCase ZIE HIERBOVEN
        CustomerUserStruct NewCustomerUser(CustomerUserStruct NewCustomerUser);
        CustomerUserStruct GetCustomerById(int id);
    }
}
