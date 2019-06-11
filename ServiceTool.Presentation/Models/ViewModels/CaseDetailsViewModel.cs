using ServiceTool.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTool.Presentation.Models
{
    public class CaseDetailsViewModel
    {
        public Case Case { get; set; }
        public CaseStatus CaseStatus { get; set; }
        public List<CaseStatus> caseStatuses { get; set; } = new List<CaseStatus>();
    }
}
