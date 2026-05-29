using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Models
{
    internal class Company : Entity
    {
        public string Name { get; set; }

        public string Phone { get; set; }
        public Company(int id, string name, string phone) : base(id)
        {
            Name = name;
            Phone = phone;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
