using ServiceTool.DAL.ApiContext;
using ServiceTool.DAL.Interface;
using ServiceTool.DAL.Repositorys;
using ServiceTool.DAL.SqlContext;
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

        public static IUserCollectionDAL CreateUserCollection()
        {
            return new UserRepository(new UserApiContext());
        }
    }
}
