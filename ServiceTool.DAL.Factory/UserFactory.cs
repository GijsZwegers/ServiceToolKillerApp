using ServiceTool.DAL.Interface;
using ServiceTool.SqlContext;
using System;

namespace ServiceTool.DAL.Factory
{
    public class UserFactory
    {
        public static ICustomerUser CreateCustomer()
        {
            return new CustomerUserDAL();
        }

        public static IServiceUser CreateService()
        {
            return new ServiceUserDAL();
        }
    }
}
