using ServiceTool.DAL;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class CaseStatusCollection
    {
        private readonly ICaseStatusContext _caseContext;

        public CaseStatusCollection(ICaseStatusContext caseContext)
        {
            _caseContext = caseContext;
        }

        public CaseStatusCollection()
        { }

        public static ICaseStatusCollectionDAL CaseStatusCollectionDAL { get; set; } = CaseStatusFactory.CreateCaseStatusCollectionDAL();

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            _caseContext.NewCaseStatus(caseStatus);
        }

        public List<CaseStatus> GetAll()
        {
            List<CaseStatus> caseStatuses = new List<CaseStatus>();
            foreach (CaseStatusStruct caseStatus in _caseContext.GetAll())
            {
                caseStatuses.Add(new CaseStatus(caseStatus));
            }
            return caseStatuses;
        }

        public void RemoveCaseStatus(int id)
        {
            _caseContext.RemoveCaseStatus(id);
        }
    }
}
