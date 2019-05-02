using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICaseStatusCollectionDAL
    {
        void NewCaseStatus(CaseStatusStruct caseStatus);
        List<CaseStatusStruct> GetAll();
        void RemoveCaseStatus(int id);
    }
}
