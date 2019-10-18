using ServiceTool.DAL.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.Logic
{
    public class CompanyUserCollection
    {
        private readonly DAL.ContextInterfaces.IUserContext _companyUserContext;


        public CompanyUserCollection(IUserContext companyUserContext)
        {
            _companyUserContext = companyUserContext;
        }

        //public async Task<CompanyUser> Login(string mail, string password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException(nameof(password));
        //    }

        //    await _companyUserContext.ApiLoginAsync(mail, password);

        //    CompanyUser customerUser = new CompanyUser();
            
        //    customerUser = new CompanyUser(await _companyUserContext.ApiGetCustomerTokenAsync());

        //    //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

        //    return customerUser;
        //}

        public async Task<CompanyUser> Login(string mail, string password, int? pin)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            await _companyUserContext.ApiGetCompanyUserToken(mail, password, pin);

            CompanyUser customerUser = new CompanyUser();

            customerUser = new CompanyUser(await _companyUserContext.ApiGetCompanyuserAsync());

            //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

            return customerUser;
        }

    }
}
