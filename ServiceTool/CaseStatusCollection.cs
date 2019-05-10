using ServiceTool.DAL.Factory;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public static class CaseStatusCollection
    {
        public static ICaseStatusCollectionDAL CaseStatusCollectionDAL { get; set; } = CaseStatusFactory.CreateCaseStatusCollectionDAL();

        public static void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            CaseStatusCollectionDAL.NewCaseStatus(caseStatus);
        }

        public static List<CaseStatus> GetAll()
        {
            List<CaseStatus> caseStatuses = new List<CaseStatus>();
            foreach (CaseStatusStruct caseStatus in CaseStatusCollectionDAL.GetAll())
            {
                caseStatuses.Add(new CaseStatus(caseStatus));
            }
            return caseStatuses;
        }

        public static void RemoveCaseStatus(int id)
        {
            CaseStatusCollectionDAL.RemoveCaseStatus(id);
        }
    }
}
