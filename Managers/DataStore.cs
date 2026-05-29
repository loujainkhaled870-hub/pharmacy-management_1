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
        public static List<Medicines>MedicinesList = new List<Medicines>();
        public static List<Company> CompaniesList = new List<Company>();
        public static List<Invoice> InvoicesList = new List<Invoice>();
        //public static List<Medicines> ActiveMedicinesList = new List<Medicines>();
        public static List<Medicines> ExpiredMedicinesList = new List<Medicines>();
        public static List<Users> UsersList = new List<Users>();
        public static Users CurrentUser = null;
        static DataStore()
        {
            UsersList.Add(new Users(1, "superadmin", "12345678", UserRole.SuperAdmin));
            UsersList.Add(new Users(2, "admin", "1234", UserRole.Admin));
        }
        //
    }
}
