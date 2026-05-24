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
            }
        }
        // update
      
        public void UpdateMedicine(int id , Medicines updateMedicines)
        {
            
         
        }
    }
}
