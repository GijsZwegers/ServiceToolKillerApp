using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.Logic
{
    public class CompanyUser : User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public override string Mail { get; set; }
        public override string Name { get; set; }
        public override string LastName { get; set; }
        public override bool IsActive { get; set; }

        public CompanyUser()
        {}

        public CompanyUser(CompanyUserStruct UserStruct)
        {
            this.Id = UserStruct.Id;
            this.Mail = UserStruct.Mail;
            this.Name = UserStruct.Name;
            this.IsActive = UserStruct.IsActive;
            this.DateOfBirth = UserStruct.DateOfBirth;
            this.Pin = UserStruct.Pin;
            this.CompanyId = UserStruct.CompanyId;
        }

        public CompanyUser(Task<AdminUserStruct> task)
        {
            this.Name = task.Result.Name;
            this.LastName = task.Result.LastName;
            this.Mail = task.Result.Mail;
            this.IsActive = task.Result.IsActive;
        }

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
