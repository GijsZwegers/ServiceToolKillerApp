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
            throw new NotImplementedException();
        }

        public CaseStruct Get()
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatus(string CaseNumber, CaseStatusStruct caseStatusStruct)
        {
            throw new NotImplementedException();
        }
    }
}
