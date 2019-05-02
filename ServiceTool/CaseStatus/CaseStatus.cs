using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;

namespace ServiceTool.Logic
{
    public class CaseStatus
    {
        public string Description { get; private set; }
        public ICaseStatusDAL CaseStatusDAL { get; private set; } = CaseStatusFactory.CreateCaseStatusDAL();

        public CaseStatus(CaseStatusStruct caseStatusStruct)
        {
            this.Description = caseStatusStruct.Description;
        }

        public void Update(CaseStatusStruct newCaseStatus)
        {
            CaseStatusDAL.Update(newCaseStatus);
        }
    }
}