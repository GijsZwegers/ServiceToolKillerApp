using ServiceTool.DAL;
using ServiceTool.DAL.Interface;
using ServiceTool.UnitTest.MemoryContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.UnitTest.TestFactories
{
    public static class CaseStatusTestFactory
    {
        public static ICaseStatusDAL CreateCaseStatusTestDAL()
        {
            return new CaseStatusRepository(new CaseStatusMemoryContext());
        }

        public static ICaseStatusCollectionDAL CreateCaseStatusCollectionTestDAL()
        {
            return new CaseStatusRepository(new CaseStatusMemoryContext());
        }
    }
}
