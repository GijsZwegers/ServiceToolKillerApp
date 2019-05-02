using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTool.DAL.Interface;
using ServiceTool.Logic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ServiceTool.UnitTests
{
    [TestClass]
    public class CastStatusDALTest
    {
        //const string connectionstring = @"Data Source=TEUNZWEGERS;Initial Catalog=ServiceTool;Integrated Security=True";

        //private SqlConnection conn;

        //private SqlConnection GetConnection()
        //{
        //    return conn = new SqlConnection(connectionstring);
        //}
        
        [TestMethod]
        public void Try_Get_All_CaseStatuses()
        {
            //arrange

            //act
            List<CaseStatus> caseStatuses = CaseStatusCollection.GetAll();

            //assert
            Assert.IsTrue(caseStatuses.Count() != 0);
        }

        [TestMethod]
        public void Try_To_Add_And_Then_Remove_Case()
        {
            //arrange
            int CountOfCaseStatusesBeforeAdding;
            int CountOfCaseStatusesAfterAdding;
            int CountOfCaseStatusesAfterRemoving;
            int lastid;

            CaseStatusStruct testCaseStatusStruct = new CaseStatusStruct("Dit is een test status");
            List<CaseStatus> casestatuses = new List<CaseStatus>();
            
            //act

            //Before adding
            CountOfCaseStatusesBeforeAdding = CaseStatusCollection.GetAll().Count();

            //Adding
            CaseStatusCollection.NewCaseStatus(testCaseStatusStruct);
            List<CaseStatus> caseStatusStructs = CaseStatusCollection.GetAll();
            CountOfCaseStatusesAfterAdding = caseStatusStructs.Count();

            //Removing
            lastid = caseStatusStructs.Max(o => o.Id);
            CaseStatusCollection.RemoveCaseStatus(lastid);
            CountOfCaseStatusesAfterRemoving = CaseStatusCollection.GetAll().Count();

            //assert
            Assert.IsTrue(CountOfCaseStatusesBeforeAdding + 1 == CountOfCaseStatusesAfterAdding);
            Assert.IsTrue(caseStatusStructs[CountOfCaseStatusesAfterAdding - 1].Description == testCaseStatusStruct.Description);
            Assert.IsTrue(CountOfCaseStatusesAfterRemoving == CountOfCaseStatusesBeforeAdding);
        }
    }
}
