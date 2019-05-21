using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface ICaseContext
    {
        CaseStruct Get(int id);
        void Close(string CaseNumber);
        bool UpdateStatus(string CaseNumber, int idCaseStatus);
    }
}
