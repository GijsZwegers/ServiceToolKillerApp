using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Repositorys
{
    public class CaseRepository : ICaseDAL
    {
        private ICaseContext CaseContext;

        public CaseRepository(ICaseContext caseContext)
        {
            CaseContext = caseContext;
        }

        public void Close(string CaseNumber)
        {
            CaseContext.Close(CaseNumber);
        }

        public CaseStruct Get()
        {
            return CaseContext.Get();
        }

        public bool UpdateStatus(string CaseNumber, CaseStatusStruct caseStatusStruct)
        {
            return CaseContext.UpdateStatus(CaseNumber, caseStatusStruct);
        }
    }
}
