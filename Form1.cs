using Guna.UI2.WinForms;
using pharmacy_management_1.Managers;
using pharmacy_management_1.Models;

namespace pharmacy_management_1
{
    public partial class Form1 : Form
    {
        private int minHeight = 120;
        private int maxHeight = 500;
        private bool isExpanding = true;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            label.MouseEnter += panel_MouseEnter;
            label.MouseLeave += panel_MouseLeave;
            panel.MouseLeave += panel_MouseLeave;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 30;
            int halfSpeed = speed / 2;
            if (isExpanding)
            {
                if (panel.Height < maxHeight)
                {
                    panel.Height += speed;
                    panel.Location = new Point(panel.Location.X, panel.Location.Y - halfSpeed);
                }
                else
                {
                    panel.Height = maxHeight;
                    timer1.Stop();
                }
            }
            else
            {
                if (panel.Height > minHeight)
                {
                    panel.Height -= speed;
                    panel.Location = new Point(panel.Location.X, panel.Location.Y + halfSpeed);
                }
                else
                {
                    panel.Height = minHeight;
                    timer1.Stop();
                }
                this.Refresh();
            }
        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanding)
            {
                isExpanding = true;
                timer1.Start();
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanding)
            {
                isExpanding = true;
                timer1.Start();
            }
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            Point cursor = this.PointToClient(Cursor.Position);
            if (!panel.Bounds.Contains(cursor) && !panel.Bounds.Contains(cursor))
            {
                isExpanding = false;
                timer1.Start();

            }
        }

        private void guna2TextBox2_IconLeftClick(object sender, EventArgs e)
        {
            if (txt_password.UseSystemPasswordChar == true)
            {
                txt_password.UseSystemPasswordChar = false;
                txt_password.IconLeft = Properties.Resources.eye_open;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
                txt_password.IconLeft = Properties.Resources.eye_close;
            }
        }

        //private void btn_login_Click(object sender, EventArgs e)
        //{
        //    Form2 dashboard = new Form2();
        //    dashboard.Show();
        //    this.Hide();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            string username = txt_user.Text;
            string password = txt_password.Text;
            UsersManager usersManager = new UsersManager();
            Users user = usersManager.Login(username, password);
            if (user != null)
            {
                Form2 dashboard = new Form2();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}