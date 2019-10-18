using ServiceTool.DAL.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class CompanyUserCollection
    {
        private readonly ICustomerUserContext _CustomerUserContext;

        public CompanyUserCollection(ICustomerUserContext customerUserContext)
        {
            _CustomerUserContext = customerUserContext;
        }

        public CompanyUser Login(string mail, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            CompanyUser customerUser = new CompanyUser();

            customerUser = new CompanyUser(_CustomerUserContext.GetCustomerUser(mail, password));

            //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

            return customerUser;
        }

    }
}
