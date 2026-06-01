using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Models
{
    internal class Medicines : Entity
    {
        public string BusinessName { get; set; }
        public string ScientificName { get; set; }
        public int Quantity { get; set; }

        public Company Company { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Medicines(int id, string businessName,
            string scientificName, int quantity, Company company, decimal buyingPrice,
            decimal salePrice , DateTime expirydate) : base(id)
        {
            BusinessName = businessName;
            ScientificName = scientificName;
            Quantity = quantity;
            Company = company;
            BuyingPrice = buyingPrice;
            SalePrice = salePrice;
            ExpiryDate = expirydate;
        }

    }
}
