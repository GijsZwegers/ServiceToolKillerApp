using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct CaseStatusStruct
    {
        public int Id { get; private set; }
        public string Description { get; set; }


        public CaseStatusStruct(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public CaseStatusStruct(string description)
        {
            this.Id = 0;
            this.Description = description;
        }
    }
}
