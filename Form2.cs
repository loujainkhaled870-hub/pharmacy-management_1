using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy_management_1.Managers;
using pharmacy_management_1.Models;

namespace pharmacy_management_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }
        private void ActivateButton(Guna.UI2.WinForms.Guna2CircleButton selectedButton, int tabIndex)
        {
            btn_Medicines.Location = new Point(5, 9);
            btn_expired.Location = new Point(5, 108);
            btn_pos.Location = new Point(5, 207);
            btn_Bills.Location = new Point(5, 306);
            btn_Companies.Location = new Point(5, 405);
            btn_users.Location = new Point(5, 504);
            selectedButton.Location = new Point(15, selectedButton.Location.Y);
            guna2TabControl1.SelectedIndex = tabIndex;
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_users, 5);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Medicines_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_Medicines, 0);
        }

        private void btn_expired_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_expired, 1);
        }

        private void btn_pos_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_pos, 2);
        }

        private void btn_Bills_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_Bills, 3);
        }

        private void btn_Companies_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_Companies, 4);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {

        }

        private void btn_showUser_Click(object sender, EventArgs e)
        {
            UsersManager manager = new UsersManager();
            dgv_users.DataSource = null;
            dgv_users.DataSource = manager.GetAllUser();
            if (dgv_users.Columns.Count > 0)
            {
                dgv_users.Columns["Id"].DisplayIndex = 0;
                dgv_users.Columns["Role"].DisplayIndex = 1;

                dgv_users.Columns["Role"].HeaderText = "Role";
                dgv_users.Columns["PassWord"].HeaderText = "Password";
                dgv_users.Columns["UserName"].HeaderText = "Username";
                dgv_users.Columns["Id"].HeaderText = "Id";

            }
        }

        private void btn_addUser_Click_1(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to add new user ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            UsersManager manager = new UsersManager();
            string username = txt_newusername.Text.Trim();
            string password = txt_newpassword.Text.Trim();
            if (username == "" || password == "")
            {
                MessageBox.Show("please fill in all fields before adding a user!", "validation error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < username.Length; i++)
            {
                char c = username[i];
                if (c >= '0' && c <= '9')
                {
                    MessageBox.Show("Username must contain letters only ! numbers are not allowed "
                        , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    MessageBox.Show("Password must contain numbers only ! letters are not allowed "
                        , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            bool isUsernameExists = false;
            List<Users> allusers = manager.GetAllUser();
            for (int i = 0; i < allusers.Count; i++)
            {
                if (allusers[i].UserName.ToLower() == username.ToLower())
                {
                    isUsernameExists = true;
                    break;
                }
            }
            if (isUsernameExists)
            {
                MessageBox.Show("This username is already taken ! please choose another one "
                    , "Registration error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UserRole selectedRole;
            if (cmb_Role.SelectedItem != null && cmb_Role.SelectedItem.ToString() == "SuperAdmin")
            {
                selectedRole = UserRole.SuperAdmin;
            }
            else
            {
                selectedRole = UserRole.Admin;
            }
            manager.AddUser(username, password, selectedRole);
            MessageBox.Show($"User {username} has been add successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_users.DataSource = null;
            dgv_users.DataSource = manager.GetAllUser();
            if (dgv_users.Columns.Count > 0)
            {
                dgv_users.Columns["Id"].DisplayIndex = 0;
                dgv_users.Columns["Role"].DisplayIndex = 1;


                dgv_users.Columns["Role"].HeaderText = "Role";
                dgv_users.Columns["Password"].HeaderText = "Password";
                dgv_users.Columns["UserName"].HeaderText = "Username";
                dgv_users.Columns["Id"].HeaderText = "Id";
            }
            txt_newpassword.Clear();
            txt_newusername.Clear();
            cmb_Role.SelectedIndex = 0;
            txt_newusername.Focus();
        }

        private void btn_deleteUser_Click(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to delete users ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv_users.CurrentRow == null)
            {
                MessageBox.Show("please select a user from the table to delete  "
                       , "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataGridViewRow SelectedRow = dgv_users.CurrentRow;
            object cellvalue = SelectedRow.Cells["Id"].Value;
            int selectedUserId = Convert.ToInt32(cellvalue);

        }

        private void dtn_editUser_Click(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to delete users ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv_users.CurrentRow == null)
            {
                MessageBox.Show("please select a user from the table to edit"
                      , "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void dgv_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addCompany_Click(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to add company ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string name = txt_companyName.Text.Trim();
            string phone = txt_companyPhone.Text.Trim();
            if (name == ""|| phone=="")
            {
                MessageBox.Show("please fill in all fields before adding a company!", "validation error"
                  , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= '0' && name[i] <= '9')
                {
                    MessageBox.Show("company name must contain letters only", "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            for (int i = 0; i < phone.Length; i++)
            {
                char c = phone[i];
                if((c>='a' && c<='z')||(c>='A'&& c <= 'Z'))
                {
                    MessageBox.Show(" phone number must contain numbers only", "Validation Error"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            CompanyManager manager = new CompanyManager();
            bool isCompanyExists = false;
            List<Company> allCompanies = manager.GetAllCompanies();

            for (int i = 0; i < allCompanies.Count; i++)
            {
                if (allCompanies[i].Name.ToLower() == name.ToLower())
                {
                    isCompanyExists = true;
                    break;
                }
            }
            if (isCompanyExists)
            {
                MessageBox.Show("this company name already exists", "Registration Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            manager.AddCompany(name, phone);
            MessageBox.Show($"company {name} has been added successfuly ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_company.DataSource = null;
            dgv_company.DataSource = manager.GetAllCompanies();
            if (dgv_company.Columns.Count > 0)
            {
                dgv_company.Columns["Id"].DisplayIndex = 0;
                dgv_company.Columns["Name"].DisplayIndex = 1;
                dgv_company.Columns["Phone"].DisplayIndex = 2;

                dgv_company.Columns["Id"].HeaderText = "Company Id";
                dgv_company.Columns["Name"].HeaderText = "Company Name";
                dgv_company.Columns["Phone"].HeaderText = "Phone Number";
            }

            txt_companyName.Clear();
            txt_companyPhone.Clear();
            txt_companyName.Focus();
        }
    }
}
