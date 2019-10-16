using ServiceTool.DAL.Interface;
using System;

namespace ServiceTool.Logic.Interface
{
    public interface ICase
    {
        CaseStruct Get(int id);
        void Close();
        bool UpdateStatus(string caseNumber, int idCaseStatus);
    }
}
