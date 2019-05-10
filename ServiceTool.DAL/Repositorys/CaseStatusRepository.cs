using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL
{
    public class CaseStatusRepository : ICaseStatusDAL, ICaseStatusCollectionDAL
    {
        private ICaseStatusContext CaseStatusContext;

        public CaseStatusRepository(ICaseStatusContext caseStatusContext)
        {
            CaseStatusContext = caseStatusContext;
        }

        public List<CaseStatusStruct> GetAll()
        {
            return CaseStatusContext.GetAll();
        }

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            CaseStatusContext.NewCaseStatus(caseStatus);
        }

        public void RemoveCaseStatus(int id)
        {
            CaseStatusContext.RemoveCaseStatus(id);
        }

        public void Update(int id, CaseStatusStruct caseStatus)
        {
            CaseStatusContext.Update(id, caseStatus);
        }
    }
}
