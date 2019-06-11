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

        const string connectionstring = @"Data Source=DESKTOPTHINKPAD;Initial Catalog=ServiceTool;Integrated Security=True";

        private SqlConnection conn;

        private SqlConnection GetConnection()
        {
            return conn = new SqlConnection(connectionstring);
        }

        public void DeleteCustomerUserForCompany(int CompanyId, CustomerUserStruct CustomerUser)
        {
            throw new NotImplementedException();
        }


        public List<CaseStruct> GetCasesForCompany(int CompanyId)
        {
            List<CaseStruct> cases = new List<CaseStruct>();
            using (GetConnection())
            {
                string query = "SELECT " +
                    "[Case].[CaseNumber], [CaseStatus].[Description], [Case].[Comment], [Case].[Active] [Case].[idCase] " +
                    "FROM [Case], [Case].[LastEdited] INNER JOIN CaseStatus ON " +
                    "[Case].[idCaseStatus] = [CaseStatus].[idCaseStatus] WHERE [Case].[idCompany] ="+ CompanyId;
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
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
                    conn.Close();
                }
            }
            return cases;
        }

        public CustomerUserStruct GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerUserStruct> GetCustomerUsersForCompany(int CompanyId)
        {
            List<CustomerUserStruct> customers = new List<CustomerUserStruct>();
            using (GetConnection())
            {
                string query = "SELECT " +
                    "[Customer].[idCustomerUser] [Customer].[Name], [Customer].[Active], [Case].[idCompany], [Customer].[Mail]" +
                    "FROM [Customer]  INNER JOIN ON " +
                    "[Customer].[idCompany] = [Company].[idCompany]  WHERE [Case].[idCompany] =" + CompanyId;
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new CustomerUserStruct(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetBoolean(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5),
                            reader.GetDateTime(6)
                            ));
                    }
                    conn.Close();
                }
            }
            return customers;
        }

        public CustomerUserStruct NewCustomerUser(CustomerUserStruct NewCustomerUser)
        {
            throw new NotImplementedException();
        }
    }
}
