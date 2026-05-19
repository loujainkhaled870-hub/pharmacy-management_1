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
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isExpanding)
            {
                if (panel.Height < maxHeight)
                    panel.Height += 35;
                else
                {
                    panel.Height = maxHeight;
                    timer1.Stop();
                }
            }
            else
            {
                if (panel.Height > minHeight)
                    panel.Height -= 35;
                else
                {
                    panel.Height = minHeight;
                    timer1.Stop();
                }

            }
        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            isExpanding = true;
            timer1.Start();
        }
    }
}
