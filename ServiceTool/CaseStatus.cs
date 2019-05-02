using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;

namespace ServiceTool.Logic
{
    public class CaseStatus
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public ICaseStatusDAL CaseStatusDAL { get; private set; } = CaseStatusFactory.CreateCaseStatusDAL();

        public CaseStatus(CaseStatusStruct caseStatusStruct)
        {
            this.Description = caseStatusStruct.Description;
        }

        public void Update(int caseId, CaseStatusStruct newCaseStatus)
        {
            CaseStatusDAL.Update(caseId, newCaseStatus);
        }
    }
}