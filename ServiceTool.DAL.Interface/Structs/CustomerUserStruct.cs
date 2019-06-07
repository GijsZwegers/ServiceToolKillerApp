using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct CustomerUserStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string Mail { get; set; }
        public int CompanyId { get; set; }
        public int Pin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public CustomerUserStruct(int id, string name, bool isActive, string mail, int companyId, int pin, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.IsActive = isActive;
            this.CompanyId = companyId;
            this.Mail = mail;
            this.Pin = pin;
            this.DateOfBirth = dateOfBirth;
        }

        public CustomerUserStruct(int id, string name, bool isActive, string mail, int pin, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.IsActive = isActive;
            this.Mail = mail;
            this.CompanyId = 0;
            this.Pin = pin;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
