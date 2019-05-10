using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct ServiceUserStruct
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string Password { get; set; }
    }
}
