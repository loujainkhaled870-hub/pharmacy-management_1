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
    internal class Users:Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public Users( int id , string userName , string passWord , UserRole role ):base(id)
        {
            UserName = userName;
            Password = passWord;
            Role = role;
        }
    }
}
