using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.SqlContext
{
    public class CaseSQLContext : ICaseContext
    {
        /// <summary>
        /// Not yet implemented
        /// </summary>

        public void Close(string CaseNumber)
        {
            throw new NotImplementedException();
        }

        public CaseStruct Get()
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatus(string caseNumber, CaseStatusStruct caseStatusStruct)
        {
            throw new NotImplementedException();
        }
    }
}
