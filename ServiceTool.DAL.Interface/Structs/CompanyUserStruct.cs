using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public struct CompanyUserStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string Mail { get; set; }
        public int CompanyId { get; set; }
        public int Pin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public CompanyUserStruct(string firstname, string lastname, string email, bool isactive)
        {
            this.Id = 0;
            this.CompanyId = 0; //TODO: goedmaken aan de hand van de response van de api
            this.Pin = 0;       //""    ""
            this.DateOfBirth = DateTime.Now;
            this.Name = firstname + " " + lastname;
            this.Mail = email;
            this.IsActive = isactive;
        }

        public CompanyUserStruct(int id, string name, bool isActive, string mail, int companyId, int pin, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.IsActive = isActive;
            this.CompanyId = companyId;
            this.Mail = mail;
            this.Pin = pin;
            this.DateOfBirth = dateOfBirth;
        }

        public CompanyUserStruct(int id, string name, bool isActive, string mail, int pin, DateTime dateOfBirth)
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