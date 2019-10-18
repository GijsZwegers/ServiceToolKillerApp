using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using BCrypt.Net;
using ServiceTool.DAL.ContextInterfaces;
using System.Threading.Tasks;

namespace ServiceTool.Logic
{
    public class ServerUserCollection
    {
        //public static IServiceUserCollection ServiceUserCollection { get; set; } = UserFactory.CreateServiceCollection();

        private readonly DAL.ContextInterfaces.IUserContext _serviceUserContext;

        public ServerUserCollection(DAL.ContextInterfaces.IUserContext serviceUserContext)
        {
            _serviceUserContext = serviceUserContext;
        }

        async public Task<string> GetUserTokenAsync(string username, string password)
        {
            var test = await _serviceUserContext.ApiLoginAsync(username, password);
            return test.ToString();
        }

        async public Task<ServiceUser> getCustomerAsync()
        {
           return new ServiceUser(await _serviceUserContext.ApiGetCustomerAsync());
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
