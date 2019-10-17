using ServiceTool.DAL.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class CustomerUserCollection
    {
        private readonly ICustomerUserContext _CustomerUserContext;

        public CustomerUserCollection(ICustomerUserContext customerUserContext)
        {
            _CustomerUserContext = customerUserContext;
        }

        public CustomerUser Login(string mail, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            CustomerUser customerUser = new CustomerUser();

            customerUser = new CustomerUser(_CustomerUserContext.GetCustomerUser(mail, password));

            //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

            return customerUser;
        }

    }
}
