using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using BCrypt.Net;
using ServiceTool.DAL.ContextInterfaces;

namespace ServiceTool.Logic
{
    public class ServerUserCollection
    {
        //public static IServiceUserCollection ServiceUserCollection { get; set; } = UserFactory.CreateServiceCollection();

        private readonly IServiceUserContext _serviceUserContext;

        public ServerUserCollection(IServiceUserContext serviceUserContext)
        {
            _serviceUserContext = serviceUserContext;
        }

        public ServiceUser Login(string mail, string password)
        {
            string hash = _serviceUserContext.GetServiceUserHashedPassword(mail);
            //Encypt
            if(!BCrypt.Net.BCrypt.Verify(password, hash))
            {
                return null;
            }
            
            return new ServiceUser(_serviceUserContext.GetServiceUser(mail));

        }

        public ServiceUser Register(string mail, string password, string name, string lastname)
        {
             password = BCrypt.Net.BCrypt.HashPassword(password);

            return new ServiceUser(_serviceUserContext.Register(name, lastname, mail, password));
        }

    }
}
