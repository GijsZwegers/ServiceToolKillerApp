using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface ICaseCollectionDAL
    {
        List<CaseStruct> GetAll();
        List<CaseStruct> GetCasesyCompanyID(int id);

    }
}
