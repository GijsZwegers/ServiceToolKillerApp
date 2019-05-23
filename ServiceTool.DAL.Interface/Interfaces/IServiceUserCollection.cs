using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface IServiceUserCollection
    {
        ServiceUserStruct GetServiceUser(string email);
        ServiceUserStruct Register(string name, string email, string password);
    }
}
