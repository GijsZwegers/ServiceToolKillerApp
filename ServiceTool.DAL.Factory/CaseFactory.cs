using ServiceTool.DAL.Interface;
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
