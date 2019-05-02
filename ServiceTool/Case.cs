using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class Case
    {
        public string CaseNumber { get; private set; }
        public CaseStatusStruct CaseStatus { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }
        public ICaseDAL CaseDAL { get; private set; } = CaseFactory.CreateCaseDAL();

        public Case(CaseStruct caseStruct)
        {
            this.CaseNumber = caseStruct.CaseNumber;
            this.CaseStatus = caseStruct.CaseStatus;
            this.Comment = caseStruct.Comment;
            this.Active = caseStruct.Active;
        }

        public Case Get()
        {
            CaseStruct caseStruct = CaseDAL.Get();
            return new Case(caseStruct);
        }

        public void Close()
        {
            CaseDAL.Close(this.CaseNumber);
        }

        public bool UpdateStatus(string caseNumber, CaseStatus caseStatus)
        {
            CaseStatusStruct caseStatusStruct = new CaseStatusStruct(caseStatus.Description);
            return CaseDAL.UpdateStatus(CaseNumber, caseStatusStruct);
        }
    }
}
