using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Interface
{
    public interface IAdminUserCollection
    {
        AdminUserStruct GetServiceUser(string email);
        AdminUserStruct Register(string name, string email, string password);
        //Task<string> ApiLoginAsync(string Username, string Password);
    }
}
