using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class Case
    {
        private readonly ICaseContext _caseContext;

        public Case(ICaseContext caseContext)
        {
            _caseContext = caseContext;
        }

        public Case()
        {}

        public int id { get; private set; }
        public string CaseNumber { get; private set; }
        public CaseStatusStruct CaseStatus { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastEdited { get; private set; }
        //public ICaseDAL CaseDAL { get; private set; } = CaseFactory.CreateCaseDAL();

        public Case(CaseStruct caseStruct)
        {
            this.id = caseStruct.Id;
            this.CaseNumber = caseStruct.CaseNumber;
            this.CaseStatus = caseStruct.CaseStatus;
            this.Comment = caseStruct.Comment;
            this.Active = caseStruct.Active;
            this.LastEdited = caseStruct.LastEdited;
        }

        public Case Get(int id)
        {
            CaseStruct caseStruct = _caseContext.Get(id);
            return new Case(caseStruct);
        }

        public void Close()
        {
            _caseContext.Close(this.CaseNumber);
        }

        public bool UpdateStatus(string caseNumber, int idCaseStatus)
        {
            //CaseStatusStruct caseStatusStruct = new CaseStatusStruct(caseStatus.Description);
            return _caseContext.UpdateStatus(CaseNumber, idCaseStatus);
        }
    }
}
