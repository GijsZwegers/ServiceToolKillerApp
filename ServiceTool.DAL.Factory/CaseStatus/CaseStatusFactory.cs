using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CaseStatusFactory
    {
        public static ICaseStatusDAL CreateCaseStatusDAL()
        {
            return new CaseStatusDAL();
        }

        public static ICaseStatusCollectionDAL CreateCaseStatusCollectionDAL()
        {
            return new CaseStatusDAL();
        }
    }
}
