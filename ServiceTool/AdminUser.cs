using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.Logic
{
    public class AdminUser : User
    {
        //private Task<ServiceUserStruct> task;

        public override string Name { get; set; }
        public override string LastName { get; set; }
        public override string Mail { get; set; }
        public override bool IsActive { get; set; }

        public AdminUser()
        {}

        public AdminUser(AdminUserStruct serviceUserStruct)
        {
            this.Name = serviceUserStruct.Name;
            this.LastName = serviceUserStruct.LastName;
            this.Mail = serviceUserStruct.Mail;
            this.IsActive = serviceUserStruct.IsActive;
        }

        public AdminUser(Task<AdminUserStruct> task)
        {
            //this.task = task;
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

        public string Password { get; private set; }

        public int GetPingForCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public List<CompanyUser> GetCustomerUsers()
        {
            throw new NotImplementedException();
        }

        public int ResetPinForCustomer(int CustomerId, int NewPin)
        {
            throw new NotImplementedException();
        }

    }
}
