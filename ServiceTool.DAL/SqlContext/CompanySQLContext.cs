using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ServiceTool.DAL.SqlContext
{
    public class CompanySQLContext : ICompanyContext
    {
        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="CustomerUser"></param>
        /// 

        private readonly DatabaseConnection _connection;

        public CompanySQLContext()
        {}

        public CompanySQLContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public void DeleteCustomerUserForCompany(int CompanyId, CompanyUserStruct CustomerUser)
        {
            throw new NotImplementedException();
        }

        public List<CaseStruct> GetCasesForCompany(int CompanyId)
        {
            List<CaseStruct> cases = new List<CaseStruct>();
            _connection.SqlConnection.Open();
            var cmd = new SqlCommand("SELECT " +
                "[Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active] [Case].[idCase] " +
                "FROM [Case], [Case].[LastEdited] INNER JOIN CaseStatus ON " +
                "[Case].[idCaseStatus] = [CaseStatus].[idCaseStatus] WHERE [Case].[idCompany] ="+ CompanyId);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cases.Add(new CaseStruct(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    new CaseStatusStruct(reader.GetString(2)),
                    reader.GetString(3),
                    reader.GetBoolean(4),
                    reader.GetDateTime(5)));
            }

            _connection.SqlConnection.Close();

            return cases;
        }

        public CompanyUserStruct GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CompanyUserStruct> GetCustomerUsersForCompany(int CompanyId)
        {
            List<CompanyUserStruct> customers = new List<CompanyUserStruct>();
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("SELECT " +
                    "[Customer].[idCustomerUser] [Customer].[Name], [Customer].[Active], [Case].[idCompany], [Customer].[Mail]" +
                    "FROM [Customer]  INNER JOIN ON " +
                    "[Customer].[idCompany] = [Company].[idCompany]  WHERE [Case].[idCompany] = @companyid");
            cmd.Parameters.Add(new SqlParameter("companyid", CompanyId));
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new CompanyUserStruct(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetBoolean(2),
                    reader.GetString(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5),
                    reader.GetDateTime(6)
                    ));
            }
            _connection.SqlConnection.Close();

            return customers;
        }

        public CompanyUserStruct NewCustomerUser(CompanyUserStruct NewCustomerUser)
        {
            throw new NotImplementedException();
        }
    }
}
