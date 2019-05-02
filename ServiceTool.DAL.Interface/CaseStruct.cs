using System;

namespace ServiceTool.DAL.Interface
{
    public class CaseStruct
    {
        public string CaseNumber { get; private set; }
        public CaseStatusStruct CaseStatus { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }

        public CaseStruct(string caseNumber, CaseStatusStruct caseStatus, string comment, bool active)
        {
            this.CaseNumber = CaseNumber;
            this.CaseStatus = caseStatus;
            this.Comment = comment;
            this.Active = active;
        }
    }
}