using ServiceTool.DAL.Interface;
using ServiceTool.DAL.Repositorys;
using ServiceTool.DAL.SqlContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CaseFactory
    {
        public static ICaseDAL CreateCaseDAL()
        {
            return new CaseRepository(new CaseSQLContext());
        }
    }
}
