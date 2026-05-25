using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_management_1.Models;

namespace pharmacy_management_1.Managers
{
    internal class UsersManager
    {
        int idCount = 1;
        public List<Users> GetAllUser()
        {
            return DataStore.UsersList;
        }

        public void AddUser(string username , string password , UserRole role)
        {
            int newId = idCount;
            idCount++;
            Users newUser = new Users (newId , username , password , role );
            DataStore.UsersList.Add( newUser );
        }
        public void DeleteUser(int id)
        {
            Users delete = null;

            for (int i = 0; i < DataStore.UsersList.Count; i++)
            {
                if (DataStore.UsersList[i].Id == id)
                {
                    delete = DataStore.UsersList[i];
                    break;
                }
                if(delete != null)
                {
                    DataStore.UsersList.Remove(delete);
                }
            }
        }
        public void EditUser(int id , Users EditUserData)
        {

            for (int i = 0; i < DataStore.UsersList.Count; i++)
            {
                if (DataStore.UsersList[i].Id == id)
                {
                    DataStore.UsersList[i].UserName = EditUserData.UserName;
                    DataStore.UsersList [i].Password = EditUserData.Password;
                    DataStore.UsersList[i].Role = EditUserData.Role;
                    return;
                }

            }
        }
        public Users Login(string usernamwe , string password)
        {

            for (int i = 0; i < DataStore.UsersList.Count; i++)
            {
                if (DataStore.UsersList[i].UserName == usernamwe && DataStore.UsersList[i].Password == password)
                {
                    return DataStore.UsersList[i];
                }
            }
            return null;
        }
    }
}
