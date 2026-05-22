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
    }
}
