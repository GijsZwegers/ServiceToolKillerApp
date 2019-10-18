using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ServiceTool.DAL.ContextInterfaces;
using System.Threading.Tasks;
using ServiceTool.DAL.Model.Json;

namespace ServiceTool.DAL.SqlContext
{
    public class ServiceUserSQLContext : ContextInterfaces.IServiceUserContext
    {
        private readonly DatabaseConnection _connection;

        public ServiceUserSQLContext()
        {}

        public ServiceUserSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

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
                "SELECT [User].Name, [User].LastName ,[User].Mail, [User].IsActive " +
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
                    reader.GetString(2),
                    reader.GetBoolean(3)
                    );
            }

            //Close Connection
            _connection.SqlConnection.Close();

            return sus;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public ServiceUserStruct Register(string Name, string LastName, string Email, string Password)
        {
            _connection.SqlConnection.Open();

            var sqlcmd = new SqlCommand("" +
                "INSERT INTO ServiceUser " +
                "(Password) VALUES (@password); " +
                "SELECT IDENT_CURRENT('ServiceUser');", _connection.SqlConnection);
            sqlcmd.Parameters.Add(new SqlParameter("password", Password));

            var reader = sqlcmd.ExecuteReader();
            List<ServiceUserStruct> serviceUserStructs = new List<ServiceUserStruct>();

            decimal lastid = 0;
            while(reader.Read())
            {
                lastid = reader.GetDecimal(0);
            }

            _connection.SqlConnection.Close();

            _connection.SqlConnection.Open();

            var sqlcmd2 = new SqlCommand("" +
                "INSERT INTO [User] " +
                "(Name, LastName, idCustomerUser idServiceUser, IsActive, Mail) " +
                "VALUES (@name, @lastname, @idcustomeruser @idserviceuser @isactive, @mail); " +
                "GO; " +
                "SELECT [User].Name, [User].LastName ,[User].Mail, [User].IsActive " +
                "FROM [User] " +
                "INNER JOIN [ServiceUser] ON [User].idServiceUser = [ServiceUser].idServiceUser " +
                "WHERE [User].id = @id; ", _connection.SqlConnection);
            sqlcmd2.Parameters.Add(new SqlParameter("name", Name));
            sqlcmd2.Parameters.Add(new SqlParameter("lastname", LastName));
            sqlcmd2.Parameters.Add(new SqlParameter("idcustomeruser", null));
            sqlcmd2.Parameters.Add(new SqlParameter("idserviceuser", lastid));
            sqlcmd2.Parameters.Add(new SqlParameter("isactive", true));
            sqlcmd2.Parameters.Add(new SqlParameter("mail", Email));
            sqlcmd2.Parameters.Add(new SqlParameter("id", lastid));

            reader = sqlcmd2.ExecuteReader();

            ServiceUserStruct sus = new ServiceUserStruct();

            while (reader.Read())
            {
                sus = new ServiceUserStruct(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetBoolean(3)
                    );
            }
            _connection.SqlConnection.Close();

            return sus;
        }

        public bool ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }

        public bool SetToInactive()
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAsync(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> ApiGetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        //async Task<ServiceUserStruct> ContextInterfaces.IUserCollectionDAL.ApiGetCustomerAsync()
        //{
        //    //var response = await _httpClient.GetAsync(Apiurl + "/integration/customer/token");
        //    //var cms = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
        //    return new ServiceUserStruct();
        //}
    }
}