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
        
        const string connectionstring = @"Data Source=DESKTOPTHINKPAD;Initial Catalog=ServiceTool;Integrated Security=True";

        private SqlConnection conn;

        private SqlConnection GetConnection()
        {
            return conn = new SqlConnection(connectionstring);
        }

        public List<CaseStatusStruct> GetAll()
        {
            List<CaseStatusStruct> caseStatusStructs = new List<CaseStatusStruct>();
            using (GetConnection())
            {
                string query = "SELECT * FROM CaseStatus";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        caseStatusStructs.Add(new CaseStatusStruct(
                            reader.GetInt32(0),
                            reader.GetString(1)
                            ));
                    }
                    conn.Close();
                }
            }
            return caseStatusStructs;
        }

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            using (GetConnection())
            {
                string query = "INSERT INTO CaseStatus(Description) VALUES (@description)";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@description", caseStatus.Description));
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void RemoveCaseStatus(int id)
        {
            using (GetConnection())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM CaseStatus WHERE idCaseStatus = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Update(int id, CaseStatusStruct caseStatus)
        {
            using (GetConnection())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UPDATE CaseStatus(Description) " +
                    "VALUES (@Description) WHERE idCaseStatus ='" + id, conn))
                {
                    command.Parameters.Add(new SqlParameter("@description", caseStatus.Description));
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
