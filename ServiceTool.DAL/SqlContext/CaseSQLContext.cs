using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Helper;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CaseSQLContext : ICaseContext
    {
      
        private readonly DatabaseConnection _connection;

        public CaseSQLContext()
        {}

        public CaseSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public void Close(string CaseNumber)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("UPDATE[Case] SET[Case].Active = 0 " +
                    "WHERE CaseNumber = @casenNumber", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("casenNumber", CaseNumber));

            cmd.ExecuteNonQuery();

            _connection.SqlConnection.Close();
        }

        public CaseStruct Get(int id)
        {

            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("SELECT [Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active], [Case].[LastEdited] FROM [Case]" +
                "INNER JOIN [CaseStatus] ON " +
                "CaseStatus.idCaseStatus = [Case].[idCaseStatus] " +
                "WHERE [Case].[idCase] = @idCase", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("idCase", id));

            var reader = cmd.ExecuteReader();

            CaseStruct cs = null;

            while (reader.Read())
            {
                cs = new CaseStruct(
                    reader.GetString(0),
                    new CaseStatusStruct(reader.GetString(1)),
                    reader.GetString(2),
                    reader.GetBoolean(3),
                    reader.GetDateTime(4));
            }
            _connection.SqlConnection.Close();
            
            return cs;
        }

        //Nadenken of ik dit niet beter een boolean kan maken en of ik aan de hand van het casenummer ga werken of aan de hand van het meegegeven ID
        public bool UpdateStatus(string caseNumber, int idCaseStatus)
        {
            throw new NotImplementedException();
        }

        public List<CaseStruct> GetAllCases()
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("SELECT [Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active], [Case].[idCase], [Case].[LastEdited] FROM [Case]" +
                "INNER JOIN [CaseStatus] ON " +
                "CaseStatus.idCaseStatus = [Case].[idCaseStatus]", _connection.SqlConnection);

            var reader = cmd.ExecuteReader();

            List<CaseStruct> lcs = new List<CaseStruct>();

            while (reader.Read())
            {
                lcs.Add(new CaseStruct(
                    reader.GetInt32(4),
                    reader.GetString(0),
                    new CaseStatusStruct(reader.GetString(1)),
                    reader.SafeGetString(2),
                    reader.GetBoolean(3),
                    reader.GetDateTime(5)));
            }

            _connection.SqlConnection.Close();

            return lcs;
        }

        public List<CaseStruct> GetCasesForCompany(int idCompany)
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("SELECT [Case].[IdCase], [Case].[CaseNumber], [CaseStatus].[idCaseStatus], [CaseStatus].[Description], [Case].[Comment], [Case].[Active], [Case].[LastEdited] FROM [Case]" +
                "INNER JOIN [CaseStatus] ON " +
                "CaseStatus.idCaseStatus = [Case].[idCaseStatus]" +
                "WHERE [Case].idCompany = @idCompany", _connection.SqlConnection);
            cmd.Parameters.Add(new SqlParameter("idCompany", idCompany));

            var reader = cmd.ExecuteReader();

            List<CaseStruct> lcs = new List<CaseStruct>();

            while (reader.Read())
            {
                lcs.Add(new CaseStruct(
                    reader.GetInt32(0), //CaseId
                    reader.GetString(1), //CaseNumber
                    new CaseStatusStruct(
                        reader.GetInt32(2),  //id casestatus
                        reader.GetString(3) //description
                    ), 
                    reader.GetString(4), //comment
                    reader.GetBoolean(5), //active
                    reader.GetDateTime(6)));  //lastedited
            }

            _connection.SqlConnection.Close();

            return lcs;
        }
    }
}
