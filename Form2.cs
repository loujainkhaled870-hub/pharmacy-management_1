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
using System.Diagnostics.Eventing.Reader;

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

        //////////////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////
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


        //////////////////////////////////////////////////////////////////
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
            if (name == "" || phone == "")
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
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
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

            RefreshCompaniesComboBoxes();
        }

        //////////////////////////////////////////////////////////////////
        private void btn_editCompany_Click(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to edit company ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv_company.CurrentRow == null)
            {
                MessageBox.Show("please select a company from the table to edit"
                     , "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow SelectedRow = dgv_company.CurrentRow;
            object cellValue = SelectedRow.Cells["Id"].Value;
            int selectedCompanyId = Convert.ToInt32(cellValue);

            string name = txt_companyName.Text.Trim();
            string phone = txt_companyPhone.Text.Trim();
            if (name == "" || phone == "")
            {
                MessageBox.Show("please fill in all fields before editing !", "validation error"
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
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    MessageBox.Show(" phone number must contain numbers only", "Validation Error"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            CompanyManager manager = new CompanyManager();
            manager.EditCompany(selectedCompanyId, name, phone);
            MessageBox.Show("Company data has been edit successfully ", "Success"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //////////////////////////////////////////////////////////////////
        private void btn_deleteCompany_Click(object sender, EventArgs e)
        {
            if (DataStore.CurrentUser == null || DataStore.CurrentUser.Role != UserRole.SuperAdmin)
            {
                MessageBox.Show("Acccess Denied! only SuperAdmin is allowed to delete company ", "Security Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv_company.CurrentRow == null)
            {
                MessageBox.Show("please select a company from the table to delete"
                     , "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow SelectedRow = dgv_company.CurrentRow;
            object cellValue = SelectedRow.Cells["Id"].Value;
            int selectedCompanyId = Convert.ToInt32(cellValue);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this company?", "Confirmation"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CompanyManager manager = new CompanyManager();
                manager.DeleteCompany(selectedCompanyId);
                MessageBox.Show("Company has been delete successfully ", "Successs"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_company.DataSource = null;
                dgv_company.DataSource = manager.GetAllCompanies();
            }
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

        private void dgv_company_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_company.CurrentRow != null)
            {
                txt_companyName.Text = dgv_company.CurrentRow.Cells["Name"].Value.ToString();
                txt_companyPhone.Text = dgv_company.CurrentRow.Cells["phone"].Value.ToString();
            }
        }


        //////////////////////////////////////////////////////////////////
        private void btn_showCompany_Click(object sender, EventArgs e)
        {
            CompanyManager manager = new CompanyManager();
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btn_Medicines.Checked = true;
            RefreshCompaniesComboBoxes();

            //CompanyManager companyManager = new CompanyManager();
            //List<Company> list = companyManager.GetAllCompanies();
            //cmb_company.DataSource = null;
            //cmb_company.DataSource = list;
            //cmb_company.DisplayMember = "Name";
            //cmb_company.SelectedIndex = -1;

            MedicinesManager manager = new MedicinesManager();
            manager.CheckAndMoveExpiredMedicines();
            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = manager.GetAllActiveMedicines();
            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
            }
            dgv_expiredMedicines.DataSource = null;
            dgv_expiredMedicines.DataSource = manager.GetAllExpiredMedicines();
            if (dgv_expiredMedicines.Columns.Count > 0)
            {
                dgv_expiredMedicines.Columns["Id"].DisplayIndex = 0;
            }
            //CompanyManager compManager = new CompanyManager();
            //List<Company> filterList = new List<Company>(compManager.GetAllCompanies());
            //cmb_CompanyFilter.DataSource = null;
            //cmb_CompanyFilter.DataSource = filterList;
            //cmb_CompanyFilter.DisplayMember = "Name";
            //cmb_CompanyFilter.SelectedIndex = -1;

            RefreshPosMedicinesComboBoxes();
            txt_PosTotal.Text = "0";
        }


        ////// //////////////////////////////////////////////////////////////////
        private void btn_addMedicine_Click(object sender, EventArgs e)
        {
            string businessname = txt_businessname.Text.Trim();
            string scientificname = txt_scientificename.Text.Trim();
            string quantity = txt_quantity.Text.Trim();
            string Price = txt_Price.Text.Trim();
            string company = cmb_company.Text.Trim();
            DateTime expirydate = date_expiry.Value;
            if (businessname == "" || scientificname == "" || quantity == "" || Price == "" || company == "")
            {
                MessageBox.Show("please fill in all fields before adding !", "validation error"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < quantity.Length; i++)
            {
                if (quantity[i] < '0' || quantity[i] > '9')
                {
                    MessageBox.Show(" quantity must be a valid number !", "validation error"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            for (int i = 0; i < Price.Length; i++)
            {
                if (Price[i] < '0' || Price[i] > '9')
                {
                    MessageBox.Show(" price must be a valid number !", "validation error"
                     , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int quantityValue = Convert.ToInt32(quantity);
            decimal PriceValue = Convert.ToDecimal(Price);

            MedicinesManager manager = new MedicinesManager();
            CompanyManager companyManager = new CompanyManager();
            Company SelectedCompanyObject = null;
            List<Company> allCompanies = companyManager.GetAllCompanies();

            for (int i = 0; i < allCompanies.Count; i++)
            {
                if (allCompanies[i].Name.ToLower() == company.ToLower())
                {
                    SelectedCompanyObject = allCompanies[i];
                    break;
                }
            }
            if (SelectedCompanyObject == null)
            {
                MessageBox.Show("the selected company was not found in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Medicines newMedicine = new Medicines(0, businessname, scientificname, quantityValue, SelectedCompanyObject
                , PriceValue, expirydate);
            bool isAdded = manager.AddMedicine(newMedicine);
            if (isAdded == false)
            {
                MessageBox.Show("this medicine already exists in the system ", "Duplicate Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MessageBox.Show($"Medicine {businessname} has been added successfully ", "Success"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = manager.GetAllActiveMedicines();
            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
            }

            txt_businessname.Clear();
            txt_Price.Clear();
            txt_scientificename.Clear();
            txt_quantity.Clear();
            cmb_company.SelectedIndex = -1;
            txt_businessname.Focus();

            RefreshPosMedicinesComboBoxes();
        }
        //////////////////////////////////////////////////////////////

        private void btn_deleteMedicine_Click(object sender, EventArgs e)
        {

            if (dgv_medicine.CurrentRow == null)
            {
                MessageBox.Show("Please select a medicine from the table to delete!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dgv_medicine.CurrentRow;
            object cellValue = selectedRow.Cells["Id"].Value;
            int selectedMedId = Convert.ToInt32(cellValue);
            string medName = selectedRow.Cells["BusinessName"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the medicine '{medName}'?", "Confirmation"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MedicinesManager manager = new MedicinesManager();
                manager.DeleteActiveMedicine(selectedMedId);
                MessageBox.Show("Medicine deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_medicine.DataSource = null;
                dgv_medicine.DataSource = manager.GetAllActiveMedicines();
            }
            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
            }
            txt_businessname.Clear();
            txt_Price.Clear();
            txt_scientificename.Clear();
            txt_quantity.Clear();
            cmb_company.SelectedIndex = -1;
            txt_businessname.Focus();
        }

        private void dgv_medicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv_medicine.CurrentRow != null && dgv_medicine.CurrentRow.DataBoundItem != null)
            {
                Medicines med = (Medicines)dgv_medicine.CurrentRow.DataBoundItem;
                txt_businessname.Text = med.BusinessName;
                txt_scientificename.Text = med.ScientificName;
                txt_quantity.Text = med.Quantity.ToString();
                txt_Price.Text = med.Price.ToString();
                date_expiry.Value = med.ExpiryDate;
                if (med.Company != null)
                {
                    cmb_company.Text = med.Company.Name;
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////

        private void btn_editMedicine_Click(object sender, EventArgs e)
        {

            if (dgv_medicine.CurrentRow == null)
            {
                MessageBox.Show("please select a medicine from the table to edit"
                     , "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Medicines CurrentSelectedMedicine = (Medicines)dgv_medicine.CurrentRow.DataBoundItem;
            int selectedMedicineId = CurrentSelectedMedicine.Id;

            string businessname = txt_businessname.Text.Trim();
            string scientificname = txt_scientificename.Text.Trim();
            string quantity = txt_quantity.Text.Trim();
            string Price = txt_Price.Text.Trim();
            string company = cmb_company.Text.Trim();
            DateTime expirydate = date_expiry.Value;

            DataGridViewRow SelectedRow = dgv_medicine.CurrentRow;
            object cellValue = SelectedRow.Cells["Id"].Value;

            if (businessname == "" || scientificname == "" || quantity == "" || Price == "" || company == "")
            {
                MessageBox.Show("please fill in all fields before editing !", "validation error"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < quantity.Length; i++)
            {
                if (quantity[i] < '0' || quantity[i] > '9')
                {
                    MessageBox.Show(" quantity must be a valid number !", "validation error"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            for (int j = 0; j < Price.Length; j++)
            {
                if (Price[j] < '0' || Price[j] > '9')
                {
                    MessageBox.Show("  price must be a valid number !", "validation error"
                     , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int quantityValue = Convert.ToInt32(quantity);
            decimal PriceValue = Convert.ToDecimal(Price);

            CompanyManager companyManager = new CompanyManager();
            Company SelectedCompanyObject = null;
            List<Company> allCompanies = companyManager.GetAllCompanies();

            for (int i = 0; i < allCompanies.Count; i++)
            {
                if (allCompanies[i].Name.ToLower() == company.ToLower())
                {
                    SelectedCompanyObject = allCompanies[i];
                    break;
                }
            }
            if (SelectedCompanyObject == null)
            {
                MessageBox.Show("the selected company was not found in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medicines editedMed = new Medicines(selectedMedicineId, businessname, scientificname
                , quantityValue, SelectedCompanyObject, PriceValue, expirydate);
            MedicinesManager manager = new MedicinesManager();
            manager.EditMedicines(editedMed);
            MessageBox.Show($"Medicine {businessname}  edited successfully ", "Success"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = manager.GetAllActiveMedicines();
            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
            }

            txt_businessname.Clear();
            txt_Price.Clear();
            txt_scientificename.Clear();
            txt_quantity.Clear();
            txt_businessname.Focus();
            cmb_company.SelectedIndex = -1;
        }
        /// //////////////////////////////////////////////////////////////////////////////

        private void btn_showMedicine_Click(object sender, EventArgs e)
        {
            MedicinesManager manager = new MedicinesManager();
            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = manager.GetAllActiveMedicines();
            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
            }
            txt_businessname.Clear();
            txt_Price.Clear();
            txt_scientificename.Clear();
            txt_quantity.Clear();
            txt_businessname.Focus();
            cmb_company.SelectedIndex = -1;

        }

        private void btn_destroy_Click(object sender, EventArgs e)
        {

        }

        private void btn_destroy_Click_1(object sender, EventArgs e)
        {
            MedicinesManager manager = new MedicinesManager();

            if (manager.GetAllExpiredMedicines().Count == 0)
            {
                MessageBox.Show("There are no expired medicines to destroy!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to destroy ALL expired medicines permanently?\nThis action cannot be undone!", "Confirm Bulk Destruction"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                manager.ClearAllExpiredMedicines();

                MessageBox.Show("All expired medicines have been successfully destroyed and removed from the system.", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_expiredMedicines.DataSource = null;
                dgv_expiredMedicines.DataSource = manager.GetAllExpiredMedicines();

                if (dgv_expiredMedicines.Columns.Count > 0)
                {
                    dgv_expiredMedicines.Columns["Id"].DisplayIndex = 0;
                }
            }
        }

        private void chk_DateFilter_CheckedChanged(object sender, EventArgs e)
        {
            date_Filter.Enabled = chk_DateFilter.Checked;
            ApplyMedicinesFilter();
        }


        private void ApplyMedicinesFilter()
        {
            string? selectedCompany = null;
            if (cmb_CompanyFilter.SelectedIndex != -1)
            {
                selectedCompany = cmb_CompanyFilter.Text;
            }
            else
            {
                selectedCompany = null;
            }

            decimal maxPrice = 0;
            bool usePrice = false;
            if (txt_PriceFilter.Text != null && txt_PriceFilter.Text != "")
            {
                if (decimal.TryParse(txt_PriceFilter.Text, out maxPrice))
                {
                    usePrice = true;
                }
            }

            DateTime expiryDate = date_Filter.Value;
            bool useExpiry = chk_DateFilter.Checked;

            MedicinesManager manager = new MedicinesManager();
            List<Medicines> result = manager.FilterActiveMedicines(selectedCompany, maxPrice, usePrice, expiryDate, useExpiry);

            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = result;

            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
                dgv_medicine.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv_medicine.Columns["Id"].Width = 40;
            }
        }

        private void txt_PriceFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyMedicinesFilter();
        }

        private void cmb_CompanyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyMedicinesFilter();
        }

        private void date_Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyMedicinesFilter();
        }

        private void btn_ClearFilter_Click(object sender, EventArgs e)
        {
            cmb_CompanyFilter.SelectedIndex = -1;
            txt_PriceFilter.Text = "";
            chk_DateFilter.Checked = false;
            date_Filter.Enabled = false;

            MedicinesManager manager = new MedicinesManager();
            dgv_medicine.DataSource = null;
            dgv_medicine.DataSource = manager.GetAllActiveMedicines();

            if (dgv_medicine.Columns.Count > 0)
            {
                dgv_medicine.Columns["Id"].DisplayIndex = 0;
                dgv_medicine.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv_medicine.Columns["Id"].Width = 40;
            }
        }

        private void RefreshCompaniesComboBoxes()
        {
            CompanyManager compManager = new CompanyManager();

            List<Company> addList = new List<Company>(compManager.GetAllCompanies());
            cmb_company.DataSource = null;
            cmb_company.DataSource = addList;
            cmb_company.DisplayMember = "Name";
            cmb_company.SelectedIndex = -1;

            List<Company> filterList = new List<Company>(compManager.GetAllCompanies());
            cmb_CompanyFilter.DataSource = null;
            cmb_CompanyFilter.DataSource = filterList;
            cmb_CompanyFilter.DisplayMember = "Name";
            cmb_CompanyFilter.SelectedIndex = -1;
        }

        public void RefreshPosMedicinesComboBoxes()
        {
            MedicinesManager medManager = new MedicinesManager();
            List<Medicines> activeMedicines = new List<Medicines>(medManager.GetAllActiveMedicines());
            cmb_PosMedicine.DataSource = null;
            cmb_PosMedicine.DataSource = activeMedicines;
            cmb_PosMedicine.DisplayMember = "BusinessName";
            cmb_PosMedicine.SelectedIndex = -1;
        }

        private void cmb_PosMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_PosMedicine.SelectedIndex != -1 && cmb_PosMedicine.SelectedIndex != null)
            {
                Medicines selectedMedicine = (Medicines)cmb_PosMedicine.SelectedItem;
                txt_PosPrice.Text = selectedMedicine.Price.ToString();
            }
            else
            {
                txt_PosPrice.Text = "";
            }
        }

        private void btn_PosAdd_Click(object sender, EventArgs e)
        {
            if (cmb_PosMedicine.SelectedIndex == -1 || cmb_PosMedicine.SelectedIndex == null)
            {
                MessageBox.Show("please select a medicine first", "Warning"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Medicines selectedMedicine = (Medicines)cmb_PosMedicine.SelectedItem;
            int requirQty;
            if (!int.TryParse(txt_PosQuantity.Text, out requirQty) || requirQty <= 0)
            {
                MessageBox.Show("please enter a valid quantity greater than zero", "Invalid Quantity"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (requirQty > selectedMedicine.Quantity)
            {
                MessageBox.Show($"the requested quantity is not available ! max available quantity is : {selectedMedicine.Quantity}", "Stock Alert"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InvoiceItem existingItem = null;

            for (int i = 0; i < DataStore.cartList.Count; i++)
            {
                if (DataStore.cartList[i].Medicine.Id == selectedMedicine.Id)
                {
                    existingItem = DataStore.cartList[i];
                    break;
                }
            }
            if (existingItem != null)
            {
                if (existingItem.Quantity + requirQty > selectedMedicine.Quantity)
                {
                    MessageBox.Show($"total selected quantity for this item exceeds the available stock ! max available quantity is : {selectedMedicine.Quantity}", "Stock Alert"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                existingItem.Quantity += requirQty;
                existingItem.TotalPrice = (decimal)existingItem.Quantity * existingItem.Price;
            }
            else
            {
                InvoiceItem newItem = new InvoiceItem
                {
                    Medicine = selectedMedicine,
                    Price = selectedMedicine.Price,
                    Quantity = selectedMedicine.Quantity,
                    TotalPrice = (decimal)requirQty * (decimal)selectedMedicine.Price
                };
                DataStore.cartList.Add(newItem);
                UpdateCartGrid();
                txt_PosQuantity.Text = "";
                txt_PosQuantity.Focus();
            }
        }
        private void UpdateCartGrid()
        {

        }
    }

}
