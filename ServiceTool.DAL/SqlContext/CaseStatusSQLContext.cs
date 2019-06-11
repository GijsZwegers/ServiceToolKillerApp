using ServiceTool.DAL;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CaseStatusSQLContext : ICaseStatusContext
    {

        private readonly DatabaseConnection _connection;

        public CaseStatusSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public CaseStatusSQLContext()
        {}

        public List<CaseStatusStruct> GetAll()
        {
            List<CaseStatusStruct> caseStatusStructs = new List<CaseStatusStruct>();

            _connection.SqlConnection.Open();

            string query = "SELECT * FROM CaseStatus";
                
            SqlCommand command = new SqlCommand(query, _connection.SqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    caseStatusStructs.Add(new CaseStatusStruct(
                        reader.GetInt32(0),
                        reader.GetString(1)
                        ));
                }
            }

            _connection.SqlConnection.Close();

            return caseStatusStructs;
        }

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {

            _connection.SqlConnection.Open();

            string query = "INSERT INTO CaseStatus(Description) VALUES (@description)";
            SqlCommand command = new SqlCommand(query, _connection.SqlConnection);
            command.Parameters.Add(new SqlParameter("@description", caseStatus.Description));
            command.ExecuteNonQuery();

            _connection.SqlConnection.Close();
        }

        public void RemoveCaseStatus(int id)
        {
            _connection.SqlConnection.Open();
            var cmd = new SqlCommand("DELETE FROM CaseStatus WHERE idCaseStatus = @id", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();

            _connection.SqlConnection.Close();
        }

        public void Update(int id, CaseStatusStruct caseStatus)
        {
            _connection.SqlConnection.Open();

            var cmd  = new SqlCommand("UPDATE CaseStatus(Description) " +
                "VALUES (@Description) WHERE idCaseStatus ='" + id, _connection.SqlConnection);
                cmd.Parameters.Add(new SqlParameter("@description", caseStatus.Description));
                cmd.ExecuteNonQuery();

            _connection.SqlConnection.Close();
        }
    }
}
