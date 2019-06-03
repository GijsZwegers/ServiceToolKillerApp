using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class CaseCollection
    {

        private readonly ICaseContext _caseContext;


        public CaseCollection(ICaseContext caseContext)
        {
            _caseContext = caseContext;
        }

        public CaseCollection()
        { }

        public List<Case> cases { get; private set; } = new List<Case>();

        public List<Case> GetAllCases()
        {
            foreach (CaseStruct caseStruct in _caseContext.GetAllCases())
            {
                cases.Add(new Case(caseStruct));
            }
            return cases;
        }

        public List<Case> GetCasesForCompany(int idCompany)
        {
            foreach (CaseStruct caseStruct in _caseContext.GetCasesForCompany(idCompany))
            {
                cases.Add(new Case(caseStruct));
            }
            return cases;
        }


    }
}
