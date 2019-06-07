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
        [TestMethod]
        public void Try_Get_All_CaseStatuses()
        {
            //arrange

            //act
            List<CaseStatus> caseStatuses = CaseStatusCollection.GetAll();

            //assert
            Assert.AreNotEqual(caseStatuses.Count() , 0);
        }

        [TestMethod]
        public void Try_To_Add_And_Then_Remove_CaseStatus()
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
            Assert.AreEqual(CountOfCaseStatusesBeforeAdding + 1 , CountOfCaseStatusesAfterAdding, "The CaseStatus isn't added to the database");
            Assert.AreEqual(caseStatusStructs[CountOfCaseStatusesAfterAdding - 1].Description, testCaseStatusStruct.Description, "The last casestatus description doesn't match the inputted CaseStatus");
            Assert.AreEqual(CountOfCaseStatusesAfterRemoving , CountOfCaseStatusesBeforeAdding, "The Case status isn't removed from the database");
        }

        [TestMethod]
        public void Try_To_Add_Then_Update_And_Then_Remove_A_Case_Status()
        {
            //arrange
            int CountOfCaseStatusesBeforeAdding;
            int CountOfCaseStatusesAfterAdding;
            int CountOfCaseStatusesAfterRemoving;
            int lastid;
            string newDescription = "De beschrijving van de CaseStatus is geüpdated";

            CaseStatusStruct testCaseStatusStruct = new CaseStatusStruct("Dit is een test status");
            List<CaseStatus> casestatuses = new List<CaseStatus>();
            CaseStatus updatedCaseStatus = new CaseStatus(testCaseStatusStruct);

            //act
            //Before adding
            CountOfCaseStatusesBeforeAdding = CaseStatusCollection.GetAll().Count();

            //Adding
            CaseStatusCollection.NewCaseStatus(testCaseStatusStruct);
            List<CaseStatus> caseStatuses = CaseStatusCollection.GetAll();
            CountOfCaseStatusesAfterAdding = caseStatuses.Count();

            lastid = caseStatuses.Max(o => o.Id);

            //Updating
            CaseStatus caseStatus = caseStatuses.Where(o => o.Id == lastid).First();
            caseStatus.Update(new CaseStatusStruct(newDescription));
            updatedCaseStatus = CaseStatusCollection.GetAll().Where(o => o.Id == lastid).First();


            //Removing
            CaseStatusCollection.RemoveCaseStatus(lastid);
            CountOfCaseStatusesAfterRemoving = CaseStatusCollection.GetAll().Count();

            //assert
            Assert.IsTrue(CountOfCaseStatusesBeforeAdding + 1 == CountOfCaseStatusesAfterAdding, "The CaseStatus isn't added to the databse");
            Assert.IsTrue(caseStatuses[CountOfCaseStatusesAfterAdding - 1].Description == testCaseStatusStruct.Description, "The last casestatus description doesn't match the inputted CaseStatus");
            Assert.IsTrue(CountOfCaseStatusesAfterRemoving == CountOfCaseStatusesBeforeAdding, "The Case status isn't removed from the database");
            Assert.IsTrue(updatedCaseStatus.Description == newDescription);
            Assert.IsFalse(updatedCaseStatus.Description == testCaseStatusStruct.Description, "De beschrijvingen zijn hetzelfde en dus niet gewijzigd.");
        }
    }
}
