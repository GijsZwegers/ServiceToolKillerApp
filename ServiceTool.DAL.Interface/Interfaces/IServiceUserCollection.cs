using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Interface
{
    public interface IServiceUserCollection
    {
        ServiceUserStruct Login(string email, string password);
        ServiceUserStruct Register(string name, string email, string password);
    }
}
