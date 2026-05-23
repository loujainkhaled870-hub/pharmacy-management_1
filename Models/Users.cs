using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Models
{
    public enum UserRole
    {
        SuperAdmin,
        Admin,
    }
    internal class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public Users(string userName , string passWord , UserRole role )
        {
            UserName = userName;
            Password = passWord;
            Role = role;
        }
    }
}
