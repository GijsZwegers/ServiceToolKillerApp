using ServiceTool.DAL.Interface;
using ServiceTool.SqlContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CaseFactory
    {
        public static ICaseDAL CreateCaseDAL()
        {
            return new CaseDAL();
        }
    }
}
