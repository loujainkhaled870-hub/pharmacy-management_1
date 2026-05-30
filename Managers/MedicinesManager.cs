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
        public List<Medicines> GetAllActiveMedicinies()
        {
           return DataStore.ActiveMedicinesList;
        }
        public void AddMedicine(Medicines newMedicine)
        {
            DataStore.ActiveMedicinesList.Add(newMedicine);
        }
        public void EditMedicines(Medicines EditMedicine)
        {
            for (int i = 0; i < DataStore.ActiveMedicinesList.Count; i++)
            {
                if (DataStore.ActiveMedicinesList[i].Id == EditMedicine.Id)
                {
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
        public void DestoryExpiredMedicine(int id)
        {

            for (int i = 0; i <DataStore.ExpiredMedicinesList.Count; i++)
            {
                if (DataStore.ExpiredMedicinesList[i].Id == id)
                {
                    DataStore.ExpiredMedicinesList.Remove(DataStore.ExpiredMedicinesList[i]);
                    break;
                }
            }
        }
    }
}
