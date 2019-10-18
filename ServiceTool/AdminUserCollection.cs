using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using BCrypt.Net;
using ServiceTool.DAL.ContextInterfaces;
using System.Threading.Tasks;
using System;

namespace ServiceTool.Logic
{
    public class AdminUserCollection
    {
        //public static IServiceUserCollection ServiceUserCollection { get; set; } = UserFactory.CreateServiceCollection();

        private readonly DAL.ContextInterfaces.IAdminUserContext _adminUserContext;

        public AdminUserCollection(DAL.ContextInterfaces.IAdminUserContext adminUserContext)
        {
            _adminUserContext = adminUserContext;
        }

        async public Task<string> GetUserTokenAsync(string username, string password)
        {
            var test = await _adminUserContext.ApiGetAdminTokenAsync(username, password);
            return test.ToString();
        }

        async public Task<AdminUser> getCustomerAsync()
        {
           return new AdminUser(await _adminUserContext.ApiGetAdminAsync());
        }

        public async Task<AdminUser> Login(string mail, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            await _adminUserContext.ApiGetAdminTokenAsync(mail, password);

            AdminUser adminUser  = new AdminUser();

            adminUser = new AdminUser(await _adminUserContext.ApiGetAdminAsync());

            //string hash = _CustomerUserContext.GetCustomerUserHashedPassword(mail);

            return adminUser;
        }



        //public ServiceUser Login(string mail, string password)
        //{
        //    string hash = _serviceUserContext.GetServiceUserHashedPassword(mail);
        //    //Encrypt
        //    if(!BCrypt.Net.BCrypt.Verify(password, hash))
        //    {
        //        return null;
        //    }
        //    return new ServiceUser(_serviceUserContext.GetServiceUser(mail));
        //}

        //public ServiceUser Register(string mail, string password, string name, string lastname)
        //{
        //     password = BCrypt.Net.BCrypt.HashPassword(password);

        //    return new ServiceUser(_serviceUserContext.Register(name, lastname, mail, password));
        //}
    }
}
