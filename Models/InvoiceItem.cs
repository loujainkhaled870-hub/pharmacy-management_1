using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Models
{
    internal class InvoiceItem
    {
        public Medicines Medicine { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string MedicineName
        {
            get
            {
                if (Medicine == null)
                {
                    return "Unknown Medicine";
                }
                if (Medicine.BusinessName == null)
                {
                    return "no name";
                }
              return Medicine.BusinessName;
               
            }
        }
    }
}

