using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountSystem.Models
{
    public class User: IdentityUser
    {

        public string _login { get; set; }
        public string _username { get; set; }
        public string _address { get; set; }
        public string _sex { get; set; }

        //public User(): base()
        //{
            
        //}
    }
}
