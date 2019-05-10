﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTool.DAL.Interface;
using ServiceTool.Logic;
using ServiceTool.UnitTest.MemoryContext;
using ServiceTool.UnitTest.TestFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTool.UnitTest
{
    [TestClass]
    public class CaseStatusLogicUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
            //Setting the correct context for testing
            CaseStatusCollection.CaseStatusCollectionDAL = CaseStatusTestFactory.CreateCaseStatusCollectionTestDAL();
        }


        [TestMethod]
        public void Try_Get_All_CaseStatuses()
        {
            //arrange
            List<CaseStatus> caseStatuses = new List<CaseStatus>();
            //Setting the memory database 
            //NOT SURE IF THIS IS ACT
            //CaseStatusCollection.CaseStatusCollectionDAL = CaseStatusTestFactory.CreateCaseStatusCollectionTestDAL();
            CaseStatusMemoryContext caseStatusMemoryContext = new CaseStatusMemoryContext();

            //act
            //Getting the statusses
            caseStatuses = CaseStatusCollection.GetAll();

            //assert
            //Check if lists are the same
            Assert.AreEqual(caseStatuses, caseStatusMemoryContext.caseStatusStructs);
        }

        [TestMethod]
        public void Try_To_Add_A_New_CaseStatus()
        {
            //arrange
            CaseStatusStruct newCaseStatus = new CaseStatusStruct("Toegevoegde CaseStatus");
            //CaseStatusCollection.CaseStatusCollectionDAL = CaseStatusTestFactory.CreateCaseStatusCollectionTestDAL();
            CaseStatusMemoryContext caseStatusMemoryContext = new CaseStatusMemoryContext();
            List<CaseStatus> caseStatusesBeforeAdding = new List<CaseStatus>();
            List<CaseStatus> caseStatusesAfterAdding = new List<CaseStatus>();
            CaseStatus lastCaseStatus = new CaseStatus();

            //act
            caseStatusesBeforeAdding = CaseStatusCollection.GetAll();
            CaseStatusCollection.NewCaseStatus(newCaseStatus);
            caseStatusesAfterAdding = CaseStatusCollection.GetAll();
            lastCaseStatus = CaseStatusCollection.GetAll().LastOrDefault();

            //assert
            Assert.AreNotEqual(caseStatusesBeforeAdding, caseStatusesAfterAdding);
            Assert.AreEqual(4, caseStatusesAfterAdding.Count);
            Assert.AreEqual(lastCaseStatus.Description, new CaseStatus(newCaseStatus).Description);
        }

        [TestMethod]
        public void Try_To_Remove_A_New_CaseStatus()
        {
            ////arrange
            //CaseStatusCollection.CaseStatusCollectionDAL = CaseStatusTestFactory.CreateCaseStatusCollectionTestDAL();
            //CaseStatusMemoryContext caseStatusMemoryContext = new CaseStatusMemoryContext();
            //List<CaseStatus> caseStatusesBeforeAdding = new List<CaseStatus>();
            //List<CaseStatus> caseStatusesAfterAdding = new List<CaseStatus>();
            //CaseStatus lastCaseStatus = new CaseStatus();

            ////act
            //caseStatusesBeforeAdding = CaseStatusCollection.GetAll();
            //CaseStatusCollection.NewCaseStatus(newCaseStatus);
            //caseStatusesAfterAdding = CaseStatusCollection.GetAll();
            //lastCaseStatus = CaseStatusCollection.GetAll().LastOrDefault();

            ////assert
            //Assert.AreNotEqual(caseStatusesBeforeAdding, caseStatusesAfterAdding);
            //Assert.AreEqual(4, caseStatusesAfterAdding.Count);
            //Assert.AreEqual(lastCaseStatus.Description, new CaseStatus(newCaseStatus).Description);
        }
    }
}