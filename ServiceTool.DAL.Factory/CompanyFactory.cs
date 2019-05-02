using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CompanyFactory
    {
        public static ICompanyDAL CreateCompanyDAL()
        {
            return new CompanyDAL();
        }
    }
}
