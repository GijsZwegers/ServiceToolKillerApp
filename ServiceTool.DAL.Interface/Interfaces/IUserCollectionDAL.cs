using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Interface
{
    public interface IUserCollectionDAL
    {
        Task<AdminUserStruct> ApiGetCustomerAsync();
        Task<string> ApiLoginAsync(string Mail, string Password);
        Task<string> ApiLoginAsync(string Mail, string Password, int Pin);
        Task<string> ApiLoginAdminAsync(string UserName, string Password);
    }
}
