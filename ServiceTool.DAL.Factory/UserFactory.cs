using ServiceTool.DAL.Interface;
using ServiceTool.DAL.Repositorys;
using System;

namespace ServiceTool.DAL.Factory
{
    public class UserFactory
    {
        public static ICustomerUser CreateCustomer()
        {
            return new CustomerUserRepository(new CustomerUserSQLContext());
        }

        public static IServiceUser CreateService()
        {
            return new ServiceUserRepository(new ServiceUserSQLContext());
        }
    }
}
