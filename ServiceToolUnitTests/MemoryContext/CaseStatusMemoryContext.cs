using ServiceTool.DAL;
using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTool.UnitTest.MemoryContext
{
    public class CaseStatusMemoryContext : ICaseStatusContext
    {
        public List<CaseStatusStruct> caseStatusStructs = new List<CaseStatusStruct>();

        public CaseStatusMemoryContext()
        {
            caseStatusStructs.Add(new CaseStatusStruct(1, "de 1e test casestatus"));
            caseStatusStructs.Add(new CaseStatusStruct(2, "de 2e test casestatus"));
            caseStatusStructs.Add(new CaseStatusStruct(3, "de 3e test casestatus"));
        }

        public List<CaseStatusStruct> GetAll()
        {
            return caseStatusStructs;
        }

        public void NewCaseStatus(CaseStatusStruct caseStatus)
        {
            caseStatusStructs.Add(caseStatus);
        }

        public void RemoveCaseStatus(int id)
        {
            caseStatusStructs.Remove(caseStatusStructs.FirstOrDefault(cs => cs.Id == id));
        }

        public void Update(int id, CaseStatusStruct caseStatus)
        {
            CaseStatusStruct css = caseStatusStructs.FirstOrDefault(cs => cs.Id == id);
            css.Description = caseStatus.Description;
        }
    }
}
