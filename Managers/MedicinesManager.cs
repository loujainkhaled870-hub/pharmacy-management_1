using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_management_1.Models;

namespace pharmacy_management_1.Managers
{
    internal class MedicinesManager
    {
        public List<Medicines> GetAllActiveMedicines()
        {
           return DataStore.ActiveMedicinesList;
        }
        public bool AddMedicine(Medicines newMedicine)
        {

            for (int i = 0; i < DataStore.ActiveMedicinesList.Count; i++)
            {
                if (DataStore.ActiveMedicinesList[i].BusinessName.ToLower()==newMedicine.BusinessName.ToLower() 
                    && DataStore.ActiveMedicinesList[i].ScientificName.ToLower() == newMedicine.ScientificName.ToLower())
                {
                    return false;
                }
            }
            int maxId = 0;

            for (int i = 0; i < DataStore.ActiveMedicinesList.Count; i++)
            {
                if (DataStore.ActiveMedicinesList[i].Id > maxId)
                {
                    maxId = DataStore.ActiveMedicinesList[i].Id;
                }
            }
            newMedicine.Id = maxId + 1;
            DataStore.ActiveMedicinesList.Add(newMedicine);
            return true;
        }
        public void EditMedicines(Medicines EditMedicine)
        {
            for (int i = 0; i < DataStore.ActiveMedicinesList.Count; i++)
            {
                if (DataStore.ActiveMedicinesList[i].Id == EditMedicine.Id)
                {
                    DataStore.ActiveMedicinesList[i].BusinessName = EditMedicine.BusinessName;
                    DataStore.ActiveMedicinesList[i].ScientificName = EditMedicine.ScientificName;
                    DataStore.ActiveMedicinesList[i].Price = EditMedicine.Price;
                    DataStore.ActiveMedicinesList[i].Company = EditMedicine.Company;
                    DataStore.ActiveMedicinesList[i].Quantity = EditMedicine.Quantity;
                    DataStore.ActiveMedicinesList[i].ExpiryDate = EditMedicine.ExpiryDate;
                    break;
                }
            }
        }
       
        public void DeleteActiveMedicine(int id)
        {

            for (int i = 0; i <DataStore.ActiveMedicinesList.Count; i++)
            {
                if (DataStore.ActiveMedicinesList[i].Id == id)
                {
                    DataStore.ActiveMedicinesList.Remove(DataStore.ActiveMedicinesList[i]);
                    break;
                }
            }
        }
        
        public List<Medicines> GetAllExpiredMedicinies()
        {
            return DataStore.ExpiredMedicinesList;
        }

        public void CheckAndMoveExpiredMedicines()
        {

            for (int i = DataStore.ActiveMedicinesList.Count; i >0; i--)
            {
                if (DataStore.ActiveMedicinesList[i] != null)
                {
                    if (DataStore.ActiveMedicinesList[i].ExpiryDate.Date < DateTime.Now.Date)
                    {
                        DataStore.ExpiredMedicinesList.Add(DataStore.ActiveMedicinesList[i]);
                        DataStore.ActiveMedicinesList.Remove(DataStore.ActiveMedicinesList[i]);
                    }
                }
            }
        }
        public List<Medicines> GetAllExpiredMedicines()
        {
            return DataStore.ExpiredMedicinesList;
        }
        public void ClearAllExpiredMedicines()
        {
                    DataStore.ExpiredMedicinesList.Clear();
                   
        }

    }
}
