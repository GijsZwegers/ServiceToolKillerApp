using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct ServiceUserStruct
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool IsActive { get; set; }

        public string Password { get; set; }

        public ServiceUserStruct(string name, string mail,  string password, bool isactive)
        {
            this.Name = name;
            this.Mail = mail;
            this.IsActive = isactive;
            this.Password = password;
        }

        public ServiceUserStruct(string name, string mail, bool isactive)
        {
            this.Name = name;
            this.Mail = mail;
            this.IsActive = isactive;
            this.Password = null;
        }

    }
}
