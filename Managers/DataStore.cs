using pharmacy_management_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Managers
{
    internal static class DataStore
    {
        //public static List<Medicines>MedicinesList = new List<Medicines>();
        public static List<Company> CompaniesList = new List<Company>();
        public static List<Invoice> InvoicesList = new List<Invoice>();
        public static List<InvoiceItem> cartList = new List<InvoiceItem>();
        public static List<Medicines> ActiveMedicinesList = new List<Medicines>();
        public static List<Medicines> ExpiredMedicinesList = new List<Medicines>();
        public static List<Users> UsersList = new List<Users>();
        public static Users CurrentUser = null;
        static DataStore()
        {
            UsersList.Add(new Users(1, "superadmin", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", UserRole.SuperAdmin));
            UsersList.Add(new Users(2, "admin", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", UserRole.Admin));
            CompaniesList.Add(new Company(1,"Thameco","011_444567"));
            CompaniesList.Add(new Company(2, "Diamond pharma", "031_222987"));
            CompaniesList.Add(new Company(3, "Alpha pharma", "021_333456"));
            ActiveMedicinesList.Add(new Medicines(1,"Thamecopramol" , "paracetamol" ,150, CompaniesList[0] , 1800 , new DateTime(2028,5,1)));
            ActiveMedicinesList.Add(new Medicines(2, "Thamecocillin", "Amoxicillin", 80, CompaniesList[0], 4800, new DateTime(2027, 5, 8)));
            ActiveMedicinesList.Add(new Medicines(3, "Profinal", "ibuprofen", 150, CompaniesList[1], 4000, new DateTime(2028, 3, 10)));
            ActiveMedicinesList.Add(new Medicines(4, "Diafloxin", "Ciprofloxacin", 60, CompaniesList[1], 5000, new DateTime(2027, 9, 20)));
            ActiveMedicinesList.Add(new Medicines(5, "Alphamox","Amoxicillin", 100, CompaniesList[2], 4500, new DateTime(2028, 1, 10)));
            ActiveMedicinesList.Add(new Medicines(6, "Alphanax", "Alprazolam", 50, CompaniesList[2], 3500, new DateTime(2028, 5, 1)));
            ActiveMedicinesList.Add(new Medicines(7, "Augmentin", "Amoxicillin", 25, CompaniesList[1], 9500, new DateTime(2025, 4, 1)));
            ActiveMedicinesList.Add(new Medicines(8, "Catafast", "Diclofenac Potassium", 110, CompaniesList[2], 3000, new DateTime(2025, 12, 5)));
        }
        //
    }
}
