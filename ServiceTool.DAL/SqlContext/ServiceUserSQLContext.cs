using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ServiceTool.DAL.ContextInterfaces;

namespace ServiceTool.DAL.SqlContext
{
    public class ServiceUserSQLContext : IServiceUserContext
    {
        private readonly DatabaseConnection _connection;

        public ServiceUserSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public ServiceUserSQLContext()
        {}


        public string GetServiceUserHashedPassword(string email)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("" +
                "SELECT [ServiceUser].password " +
                "FROM [User] " +
                "INNER JOIN [ServiceUser] ON [ServiceUser].idServiceUser = [User].idServiceUser " +
                "WHERE [User].Mail = @mail", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("mail", email));

            var reader = cmd.ExecuteReader();

            //String for hashed password
            string hashedpassword = null;

            while(reader.Read())
            {
                hashedpassword = reader.GetString(0);
            }

            _connection.SqlConnection.Close();

            return hashedpassword;
        }

        public int GetPin()
        {
            throw new NotImplementedException();
        }

        public int GetPinForCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public ServiceUserStruct GetServiceUser(string Email)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("" +
                "SELECT [User].Name, [User].Mail, [User].IsActive " +
                "FROM [User] " +
                "INNER JOIN [ServiceUser] ON [User].idServiceUser = [ServiceUser].idServiceUser " +
                "WHERE [User].Mail = @mail ", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("mail", Email));

            var reader = cmd.ExecuteReader();

            ServiceUserStruct sus = new ServiceUserStruct();

            while(reader.Read())
            {
                sus = new ServiceUserStruct(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetBoolean(2)
                    );
            }

            _connection.SqlConnection.Close();

            return sus;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public ServiceUserStruct Register(string Name, string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }

        public bool SetToInactive()
        {
            throw new NotImplementedException();
        }
    }
}
