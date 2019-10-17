using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.Interface
{
    public interface IServiceUserCollection
    {
        ServiceUserStruct GetServiceUser(string email);
        ServiceUserStruct Register(string name, string email, string password);
        //Task<string> ApiLoginAsync(string Username, string Password);
    }
}
