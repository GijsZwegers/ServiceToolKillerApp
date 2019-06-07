using System;

namespace ServiceTool.DAL.Interface
{
    public class CaseStruct
    {
        public int Id { get; private set; }
        public string CaseNumber { get; private set; }
        public CaseStatusStruct CaseStatus { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastEdited { get; private set; }

        public CaseStruct(string caseNumber, CaseStatusStruct caseStatus, string comment, bool active, DateTime LastEdited)
        {
            this.CaseNumber = caseNumber;
            this.CaseStatus = caseStatus;
            this.Comment = comment;
            this.Active = active;
        }

        public CaseStruct(int id, string caseNumber, CaseStatusStruct caseStatus, string comment, bool active, DateTime LastEdited)
        {
            this.Id = id;
            this.CaseNumber = caseNumber;
            this.CaseStatus = caseStatus;
            this.Comment = comment;
            this.Active = active;
        }

        public CaseStruct()
        {

        }
    }
}