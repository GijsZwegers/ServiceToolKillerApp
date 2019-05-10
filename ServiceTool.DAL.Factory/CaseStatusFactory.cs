using ServiceTool.DAL.Interface;
using ServiceTool.SqlContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CaseStatusFactory
    {
        public static ICaseStatusDAL CreateCaseStatusDAL()
        {
            return new CaseStatusRepository(new CaseStatusSQLContext());
        }

        public static ICaseStatusCollectionDAL CreateCaseStatusCollectionDAL()
        {
            return new CaseStatusRepository(new CaseStatusSQLContext());
        }
    }
}
