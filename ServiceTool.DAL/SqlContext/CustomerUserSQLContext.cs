using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CustomerUserSQLContext : ICustomerUserContext
    {
        private readonly DatabaseConnection _connection;

        public CustomerUserSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public CustomerUserSQLContext()
        {}

        public int ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }

        public int GetPin()
        {
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public CustomerUserStruct GetCustomerUser(string mail, string pin)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("" +
                "SELECT [CustomerUser].Name, [User].IsActive, [User].Mail, [CustomerUser].Pin, [CustomerUser].DateOfBirth " +
                "FROM [User] " +
                "INNER JOIN [CustomerUser] ON [CustomerUser].idCustomerUser = [User].idCustomerUser " +
                "WHERE [User].Mail = @mail AND [CustomerUser].pin = @pin", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("mail", mail));
            cmd.Parameters.Add(new SqlParameter("pin", pin));

            var reader = cmd.ExecuteReader();

            CustomerUserStruct customerUserStruct = new CustomerUserStruct();

            while (reader.Read())
            {
                customerUserStruct = new CustomerUserStruct(
                    reader.GetString(0),    //name
                    reader.GetBoolean(1),   //active
                    reader.GetString(2),    //mail
                    Convert.ToInt32(reader.GetString(3)),     //pin
                    reader.GetDateTime(4)   //birthdate
                    );
            }

            _connection.SqlConnection.Close();

            return customerUserStruct;
        }
    }
}
