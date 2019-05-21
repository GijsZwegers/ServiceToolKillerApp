using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;

namespace ServiceTool.DAL.Repositorys
{
    public class CustomerUserRepository : ICustomerUser
    {
        private ICustomerUserContext CustomerUserContext;

        private readonly DatabaseConnection _connection;

        public CustomerUserRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public CustomerUserRepository(ICustomerUserContext customerUserContext, DatabaseConnection connection)
        {
            CustomerUserContext = customerUserContext;
            _connection = connection;
        }

        public CustomerUserRepository(ICustomerUserContext customerUserContext)
        {
            CustomerUserContext = customerUserContext;
        }

        public int GetPin()
        {
            return CustomerUserContext.GetPin();
        }

        public bool Login()
        {
            return CustomerUserContext.Login();
        }

        public bool Logout()
        {
            return CustomerUserContext.Logout();
        }

        public int ResetPin(int NewPin)
        {
            return CustomerUserContext.ResetPin(NewPin);
        }
    }
}
