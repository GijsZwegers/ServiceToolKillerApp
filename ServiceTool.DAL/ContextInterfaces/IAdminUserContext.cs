using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface IAdminUserContext
    {
        //Task<AdminUserStruct> ApiGetAdminTokenAsync();
        Task<string> ApiGetAdminTokenAsync(string UserName, string Password);
        Task<AdminUserStruct> ApiGetAdminAsync();
    }
}
