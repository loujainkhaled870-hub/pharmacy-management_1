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
        }
        //
    }
}
