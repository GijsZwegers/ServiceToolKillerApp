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

        public CustomerUser Login(string mail, string pin)
        {
            if (pin == null)
            {
                throw new ArgumentNullException(nameof(pin));
            }

            CustomerUser customerUser = new CustomerUser();

            customerUser = new CustomerUser(_CustomerUserContext.GetCustomerUser(mail, pin));

            //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

            return customerUser;
        }

    }
}
