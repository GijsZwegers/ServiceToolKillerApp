using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTool.Logic;

namespace ServiceTool.Presentation.Models
{
    public class CaseViewModel
    {
        public CaseViewModel(List<Logic.Case> cases)
        {
            foreach (var cs in cases)
            {
                CaseList.Add(new Models.Case(cs));
            }
        }

        public CaseViewModel()
        {}

        public List<Case> CaseList { get; set; } = new List<Case>();
    }
}
