
using pharmacy_management_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Managers
{
    internal class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public List<InvoiceItem> Items { get; set; }
        public decimal TotalAmount { get; set; } 

    }
}
