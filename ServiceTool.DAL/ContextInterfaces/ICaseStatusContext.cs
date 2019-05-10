using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL
{
    public interface ICaseStatusContext
    {
        void Update(int id, CaseStatusStruct caseStatus);
        void NewCaseStatus(CaseStatusStruct caseStatus);
        List<CaseStatusStruct> GetAll();
        void RemoveCaseStatus(int id);
    }
}
