using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface IUserContext
    {
        Task<ServiceUserStruct> ApiGetCustomerAsync();
        Task<string> ApiLoginAsync(string Mail, string Password);
        Task<string> ApiLoginAsync(string Mail, string Password, int Pin);
        Task<string> ApiLoginAdminAsync(string Mail, string Password);
        Task<string> ApiLoginAdminAsync();
    }
}
