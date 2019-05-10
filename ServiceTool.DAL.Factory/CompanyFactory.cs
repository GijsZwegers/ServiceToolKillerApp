using ServiceTool.DAL.Interface;
using ServiceTool.DAL.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Factory
{
    public static class CompanyFactory
    {
        public static ICompanyDAL CreateCompanyDAL()
        {
            return new CompanyRepository(new CompanySQLContext());
        }
    }
}
