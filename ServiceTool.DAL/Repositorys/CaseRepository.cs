using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;

namespace ServiceTool.DAL.Repositorys
{
    public class CaseRepository : ICaseDAL
    {
        private ICaseContext CaseContext;

        public CaseRepository(ICaseContext caseContext)
        {
            CaseContext = caseContext;
        }

        public void Close(string CaseNumber)
        {
            CaseContext.Close(CaseNumber);
        }

        public CaseStruct Get(int id)
        {
            return CaseContext.Get(id);
        }

        public bool UpdateStatus(string CaseNumber, int idCaseStatus)
        {
            return CaseContext.UpdateStatus(CaseNumber, idCaseStatus);
        }
    }
}
