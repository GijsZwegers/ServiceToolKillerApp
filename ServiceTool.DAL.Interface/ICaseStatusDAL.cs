using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICaseStatusDAL
    {
        void Update(int id, CaseStatusStruct caseStatus);
    }
}
