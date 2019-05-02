using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class Case
    {
        public string CaseNumber { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }

        public static Case Get()
        {
            throw new NotImplementedException();
        }

        public static void Close()
        {
            throw new NotImplementedException();
        }

        public static bool UpdateStatus(CaseStatus caseStatus)
        {
            throw new NotImplementedException();
        }
    }
}
