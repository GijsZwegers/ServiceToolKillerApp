using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTool.DAL.Interface;
using ServiceTool.Logic;
using ServiceTool.UnitTest.MemoryContext;
using ServiceTool.UnitTest.TestFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.UnitTest
{
    [TestClass]
    public class CaseStatusLogicUnitTest
    {
        [TestMethod]
        public void Try_Get_All_CaseStatusses()
        {
            CaseStatus caseStatus = new CaseStatus(CaseStatusTestFactory.CreateCaseStatusTestDAL());
            //caseStatus.Update();
        }

        [TestMethod]
        public void Try_Get_All_CaseStatuses()
        {
            //arrange
            List<CaseStatus> caseStatuses = new List<CaseStatus>();
            //Setting the memory database 
            //NOT SURE IF THIS IS ACT
            CaseStatusCollection.CaseStatusCollectionDAL = CaseStatusTestFactory.CreateCaseStatusCollectionTestDAL();
            CaseStatusMemoryContext caseStatusMemoryContext = new CaseStatusMemoryContext();

            //act
            //Getting the statusses
            caseStatuses = CaseStatusCollection.GetAll();

            //assert
            //Check if lists are the same
            Assert.AreEqual(caseStatuses, caseStatusMemoryContext.caseStatusStructs, "");
        }

        [TestMethod]
        public void Test()
        {
            //arrange

            //act

            //assert

        }
    }
}
