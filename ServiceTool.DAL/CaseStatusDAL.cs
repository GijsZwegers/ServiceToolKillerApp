using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL
{
    public class CaseStatusDAL : ICaseStatusDAL, ICaseStatusCollectionDAL
    {
        /// <summary>
        /// Dal moet nog worden geimplementeerd
        /// </summary>

        public List<CaseStatusStruct> GetAll()
        {
            throw new NotImplementedException();
        }

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            throw new NotImplementedException();
        }

        public void RemoveCaseStatus(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CaseStatusStruct caseStatus)
        {
            throw new NotImplementedException();
        }
    }
}
