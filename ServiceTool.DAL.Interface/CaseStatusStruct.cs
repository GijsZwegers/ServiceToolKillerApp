using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct CaseStatusStruct
    {
        public string Description { get; private set; }

        public CaseStatusStruct(string description)
        {
            this.Description = description;
        }
    }
}
