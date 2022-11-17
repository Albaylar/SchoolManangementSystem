using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlus
{
    internal class User
    {
        public string name;
        public string username;
        public string password;
        public string email;
        public UserTypes userType = UserTypes.Invalid;

        public User (string name, string username, string password, string email)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
            this.userType = UserTypes.Invalid;
        }

        public override string ToString ()
        {
            return this.name;
        }

     
    }

    public enum UserTypes
    {
        Invalid = 0,
        Admin = 1,
        Teacher = 2,
        Student = 3,
        Parent = 4
    }
}
