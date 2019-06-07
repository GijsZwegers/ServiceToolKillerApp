using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTool.Presentation.Models
{
    public class Case
    {
        public Case(Logic.Case cs)
        {
            this.id = cs.id;
            this.CaseNumber = cs.CaseNumber;
            this.Company = "empty";
            this.Description = cs.CaseStatus.Description;
            this.LastEdited = cs.LastEdited;
            this.Active = cs.Active;
            this.Status = cs.CaseStatus.Description;
        }
        public int id { get; set; }
        public string CaseNumber { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }
        public DateTime LastEdited { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
