using ServiceTool.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTool.DAL.ContextInterfaces
{
    public interface IUserContext
    {
        Task<CompanyUserStruct> ApiGetCompanyuserAsync();
        Task<string> ApiGetCompanyUserToken(string Mail, string Password, int? Pin);


        //Task<string> ApiLoginAsync(string Mail, string Password);
    }
}
