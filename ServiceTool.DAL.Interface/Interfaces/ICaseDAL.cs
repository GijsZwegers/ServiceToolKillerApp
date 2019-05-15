using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICaseDAL
    {
        CaseStruct Get(int id);
        void Close(string CaseNumber);
        bool UpdateStatus(string CaseNumber, CaseStatusStruct caseStatusStruct);
    }
}
