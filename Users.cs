using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1
{
    internal class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Users(string userName , string passWord)
        {
            UserName = userName;
            Password = passWord;
        }
    }
}
