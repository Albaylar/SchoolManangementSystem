using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlus
{
    internal class Admin : User
    {
        public Admin (string name, string username, string password, string email) : base(name, username, password, email)
        {
            userType = UserTypes.Admin;
        }

       

        
    }
}
