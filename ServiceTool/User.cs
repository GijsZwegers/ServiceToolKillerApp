using System;

namespace ServiceTool.Logic
{
    public abstract class User
    {
        public abstract string Name { get; set; }
        public abstract bool IsActive { get; set; }
        public abstract string Mail { get; set; }

        public abstract bool LogOut();
        public abstract bool SetToInactive();


    }
}
