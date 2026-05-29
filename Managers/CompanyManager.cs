using pharmacy_management_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_management_1.Managers
{
    internal class CompanyManager
    {
        public List<Company> GetAllCompanies()
        {
            return DataStore.CompaniesList;
        }
        public void AddCompany(string name,string phone)
        {
            List<Company> currentCompanies = GetAllCompanies();
            int maxId = 0;

            for (int i = 0; i < currentCompanies.Count; i++)
            {
                if (currentCompanies[i].Id > maxId)
                {
                    maxId = currentCompanies[i].Id;
                }
            }
            int newId = maxId + 1;
            Company newCompany = new Company(newId,name,phone);
            DataStore.CompaniesList.Add(newCompany);
        }
        public void EditCompany(int id , string newName , string newPhone)
        {

            for (int i = 0; i < DataStore.CompaniesList.Count; i++)
            {
                if (DataStore.CompaniesList[i].Id == id)
                {
                    DataStore.CompaniesList[i].Name = newName;
                    DataStore.CompaniesList[i].Phone = newPhone;

                    break;
                }
            }
        }
        public void DeleteCompany(int id)
        {

            for (int i = 0; i < DataStore.CompaniesList.Count; i++)
            {
                if (DataStore.CompaniesList[i].Id == id)
                {
                    DataStore.CompaniesList.Remove(DataStore.CompaniesList[i]);
                    break;
                }
            }
        }
    }
}
