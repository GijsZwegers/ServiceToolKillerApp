using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;

namespace ServiceTool.Logic
{
    public class CaseStatus
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public ICaseStatusDAL CaseStatusDAL { get; set; } = CaseStatusFactory.CreateCaseStatusDAL();

        public CaseStatus(ICaseStatusDAL caseStatusDAL)
        {
            CaseStatusDAL = caseStatusDAL;
        }

        public CaseStatus()
        {}

        public CaseStatus(CaseStatusStruct caseStatusStruct)
        {
            this.Description = caseStatusStruct.Description;
        }

        public void Update(CaseStatusStruct newCaseStatus)
        {
            CaseStatusDAL.Update(this.Id, newCaseStatus);
        }
    }
}