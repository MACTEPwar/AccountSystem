using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountSystem.Data
{
    public class MyRole: IdentityRole<int>
    {
        public MyRole() : base()
        {
        }

        public MyRole(string roleName)
        {
            Name = roleName;
        }
    }
}
