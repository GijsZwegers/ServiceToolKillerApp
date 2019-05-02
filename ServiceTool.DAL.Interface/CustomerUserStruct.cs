using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct CustomerUserStruct
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string Mail { get; set; }
        public int Pin { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
