using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
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
        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void AddUser(string username , string password , UserRole role)
        {
            List<Users> allUser = GetAllUser();
            int maxId = 0;

            for (int i = 0; i < allUser.Count; i++)
            {
                if (allUser[i].Id > maxId)
                {
                    maxId = allUser[i].Id;
                }
            }
            int newId = maxId+1;
            string hashedPassword = ComputeSha256Hash(password);
            Users newUser = new Users (newId , username , hashedPassword , role );
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
                    DataStore.UsersList [i].Password = ComputeSha256Hash(EditUserData.Password);
                    DataStore.UsersList[i].Role = EditUserData.Role;
                    return;
                }

            }
        }
        public Users Login(string usernamwe , string password)
        {
            string hashedInput = ComputeSha256Hash(password);
            for (int i = 0; i < DataStore.UsersList.Count; i++)
            {
                if (DataStore.UsersList[i].UserName == usernamwe && DataStore.UsersList[i].Password == hashedInput)
                {
                    //لحفظ المستخدم الحالي  
                    DataStore.CurrentUser = DataStore.UsersList[i];
                    return DataStore.UsersList[i];
                }
            }
            return null;
        }
    }
}
