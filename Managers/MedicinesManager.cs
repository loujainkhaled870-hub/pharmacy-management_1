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
        // add
        //public void AddMedicine(Medicines medicine)
        //{
        //    DataStore.MedicinesList.Add(medicine);
        //}
        // delete
        public void DeleteMedicine(int id)
        {
            Medicines Delete = null;

            for (int i = 0; i < DataStore.MedicinesList.Count; i++)
            {
                if (DataStore.MedicinesList[i].Id == id)
                {
                    Delete = DataStore.MedicinesList[i];
                    break;
                }
            }

            if (Delete != null)
            {
                DataStore.MedicinesList.Remove(Delete);
                return;
            }
        }
        // Edit 
      
        public void EditMedicine(int id , Medicines editMedicines)
        {

            for (int i = 0; i < DataStore.MedicinesList.Count; i++)
            {
                if (DataStore.MedicinesList[i].Id == id)
                {
                    DataStore.MedicinesList[i].BusinessName = editMedicines.BusinessName;
                    DataStore.MedicinesList[i].ScientificName = editMedicines.ScientificName;
                    DataStore.MedicinesList[i].SalePrice = editMedicines.SalePrice;
                    DataStore.MedicinesList[i].Quantity = editMedicines.Quantity;
                    DataStore.MedicinesList[i].Company = editMedicines.Company;
                    DataStore.MedicinesList[i].BuyingPrice = editMedicines.BuyingPrice;
                }
            }   
           
        }
    }
}
