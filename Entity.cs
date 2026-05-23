using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1
{
    internal abstract class Entity
    {
        int id = 1;
      public int Id { get; set; }
        public Entity(int id)
        {
            Id = id;
        }
    }
}
