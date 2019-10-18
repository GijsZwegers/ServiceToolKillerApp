using ServiceTool.DAL.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.Logic
{
    public class UserCollection
    {
        private readonly IUserContext _UserContext;

        public UserCollection(IUserContext userContext)
        {
            _UserContext = userContext;
        }

        public async Task<User> Login(string mail, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            AdminUser customerUser = new AdminUser();

            //Set OAuth1 token in the session. 
            await _UserContext.ApiLoginAsync(mail, password);

            var test = await _UserContext.ApiGetCustomerAsync();
            customerUser = new AdminUser(test);

            return customerUser;
        }
    }
}
