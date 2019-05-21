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

        private readonly DatabaseConnection _connection;

        public CaseRepository(ICaseContext caseContext /*, DatabaseConnection connection*/)
        {
            //_connection = connection;
            CaseContext = caseContext;
        }

        public void Close(string CaseNumber)
        {
            CaseContext.Close(CaseNumber);
        }

        public CaseStruct Get(int id)
        {
            return CaseContext.Get(id);
        }

        public bool UpdateStatus(string CaseNumber, int idCaseStatus)
        {
            return CaseContext.UpdateStatus(CaseNumber, idCaseStatus);
        }
    }
}
