using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Logic
{
    public class CustomerUser : User
    {
        public CustomerUser()
        {}

        public CustomerUser(CustomerUserStruct customerUserStruct)
        {
            this.Id = customerUserStruct.Id;
            this.Mail = customerUserStruct.Mail;
            this.Name = customerUserStruct.Name;
            this.IsActive = customerUserStruct.IsActive;
            this.DateOfBirth = customerUserStruct.DateOfBirth;
            this.Pin = customerUserStruct.Pin;
            this.CompanyId = customerUserStruct.CompanyId;
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public override string Mail { get; set; }
        public override string Name { get; set; }
        public override string LastName { get; set; }
        public override bool IsActive { get; set; }

        public override bool LogOut()
        {
            throw new NotImplementedException();
        }

        public override bool SetToInactive()
        {
            throw new NotImplementedException();
        }

        //public string Mail { get; private set; }
        public int Pin { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public string GetPin()
        {
            throw new NotImplementedException();
        }

        public bool ResetPin(int NewPin)
        {
            throw new NotImplementedException();
        }
    }
}
