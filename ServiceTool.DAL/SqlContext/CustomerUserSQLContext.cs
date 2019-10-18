using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.SqlContext
{
    public class CustomerUserSQLContext : IServiceUserContext
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

        public CompanyUserStruct GetCustomerUser(string mail, string pin)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("" +
                "SELECT [CustomerUser].[idCustomerUser], [CustomerUser].Name, [User].IsActive, [User].Mail, [CustomerUser].[idCompany], [CustomerUser].Pin, [CustomerUser].DateOfBirth " +
                "FROM [User] " +
                "INNER JOIN [CustomerUser] ON [CustomerUser].idCustomerUser = [User].idCustomerUser " +
                "WHERE [User].Mail = @mail AND [CustomerUser].pin = @pin", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("mail", mail));
            cmd.Parameters.Add(new SqlParameter("pin", pin));

            var reader = cmd.ExecuteReader();

            CompanyUserStruct customerUserStruct = new CompanyUserStruct();

            while (reader.Read())
            {
                customerUserStruct = new CompanyUserStruct(
                    reader.GetInt32(0),    //id
                    reader.GetString(1),    //name
                    reader.GetBoolean(2),   //active
                    reader.GetString(3),    //mail
                    reader.GetInt32(4),    //companyId
                    Convert.ToInt32(reader.GetString(5)),     //pin
                    reader.GetDateTime(6)   //birthdate
                    );
            }

            _connection.SqlConnection.Close();

            return customerUserStruct;
        }

        bool IServiceUserContext.ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }

        public bool SetToInactive()
        {
            throw new NotImplementedException();
        }

        public int GetPinForCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public AdminUserStruct GetServiceUser(string Email)
        {
            throw new NotImplementedException();
        }

        public AdminUserStruct Register(string Name, string lastname, string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public string GetServiceUserHashedPassword(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAsync(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
