using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CaseSQLContext : ICaseContext
    {
        /// <summary>
        /// Not yet implemented
        /// </summary>

        private readonly DatabaseConnection _connection;

        public CaseSQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public CaseSQLContext()
        {}

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

            var cmd = new SqlCommand("SELECT [Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active] FROM [Case]" +
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
                    reader.GetBoolean(3));
            }

            #region oldcode
            //using (_connection.SqlConnection)
            //{
            //    _connection.SqlConnection.Open();
            //    using (SqlCommand command = new SqlCommand("SELECT " +
            //    "[Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active] " +
            //    "FROM [Case] " +
            //    "INNER JOIN [CaseStatus] ON " +
            //    "CaseStatus.idCaseStatus = [Case].[idCaseStatus] " +
            //    "WHERE [Case].[idCase] = @idCase"))
            //    {
            //        command.Parameters.Add(new SqlParameter("@idCase", id));
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                cs = new CaseStruct(reader.GetString(0), new CaseStatusStruct(reader.GetString(1)), reader.GetString(2), reader.GetBoolean(3));
            //            }
            //        }
            //    }
            #endregion
            _connection.SqlConnection.Close();
            
            return cs;
        }

        //Nadenken of ik dit niet beter een boolean kan maken en of ik aan de hand van het casenummer ga werken of aan de hand van het meegegeven ID
        public bool UpdateStatus(string caseNumber, int idCaseStatus)
        {

            throw new NotImplementedException();
        }
    }
}
