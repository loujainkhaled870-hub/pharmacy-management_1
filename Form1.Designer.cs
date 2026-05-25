namespace pharmacy_management_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel = new Guna.UI2.WinForms.Guna2Panel();
            label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btn_login = new Guna.UI2.WinForms.Guna2Button();
            txt_password = new Guna.UI2.WinForms.Guna2TextBox();
            txt_user = new Guna.UI2.WinForms.Guna2TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.None;
            panel.BackColor = Color.Transparent;
            panel.BorderColor = Color.FromArgb(64, 138, 113);
            panel.BorderRadius = 20;
            panel.BorderThickness = 3;
            panel.Controls.Add(label);
            panel.Controls.Add(btn_login);
            panel.Controls.Add(txt_password);
            panel.Controls.Add(txt_user);
            panel.CustomizableEdges = customizableEdges7;
            panel.FillColor = Color.White;
            panel.Location = new Point(224, 244);
            panel.Name = "panel";
            panel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panel.Size = new Size(400, 120);
            panel.TabIndex = 0;
            panel.Paint += panel_Paint;
            panel.MouseEnter += panel_MouseEnter;
            panel.MouseLeave += panel_MouseLeave;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top;
            label.AutoSize = false;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(64, 138, 113);
            label.Location = new Point(100, 36);
            label.Name = "label";
            label.Size = new Size(200, 40);
            label.TabIndex = 0;
            label.Text = "LOGIN";
            label.TextAlignment = ContentAlignment.MiddleCenter;
            label.Click += guna2HtmlLabel1_Click;
            label.MouseEnter += guna2HtmlLabel1_MouseEnter;
            // 
            // btn_login
            // 
            btn_login.Animated = true;
            btn_login.BorderRadius = 10;
            btn_login.CustomizableEdges = customizableEdges1;
            btn_login.DisabledState.BorderColor = Color.DarkGray;
            btn_login.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_login.FillColor = Color.FromArgb(64, 138, 113);
            btn_login.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_login.ForeColor = Color.White;
            btn_login.HoverState.FillColor = Color.FromArgb(40, 90, 72);
            btn_login.HoverState.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_login.Location = new Point(40, 268);
            btn_login.Name = "btn_login";
            btn_login.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_login.Size = new Size(320, 45);
            btn_login.TabIndex = 3;
            btn_login.Text = "LOG IN";
            btn_login.Click += btn_login_Click_1;
            // 
            // txt_password
            // 
            txt_password.BorderColor = Color.FromArgb(64, 138, 113);
            txt_password.BorderRadius = 10;
            txt_password.BorderThickness = 2;
            txt_password.CustomizableEdges = customizableEdges3;
            txt_password.DefaultText = "";
            txt_password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_password.FocusedState.BorderColor = Color.FromArgb(31, 111, 95);
            txt_password.Font = new Font("Segoe UI", 9F);
            txt_password.ForeColor = Color.Black;
            txt_password.HoverState.BorderColor = Color.FromArgb(64, 138, 113);
            txt_password.IconLeft = Properties.Resources.eye_close;
            txt_password.Location = new Point(40, 192);
            txt_password.Margin = new Padding(3, 4, 3, 4);
            txt_password.Name = "txt_password";
            txt_password.PlaceholderForeColor = SystemColors.ScrollBar;
            txt_password.PlaceholderText = "Password";
            txt_password.SelectedText = "";
            txt_password.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_password.Size = new Size(320, 45);
            txt_password.TabIndex = 2;
            txt_password.UseSystemPasswordChar = true;
            txt_password.IconLeftClick += guna2TextBox2_IconLeftClick;
            txt_password.TextChanged += guna2TextBox2_TextChanged;
            // 
            // txt_user
            // 
            txt_user.BorderColor = Color.FromArgb(64, 138, 113);
            txt_user.BorderRadius = 10;
            txt_user.BorderThickness = 2;
            txt_user.CustomizableEdges = customizableEdges5;
            txt_user.DefaultText = "";
            txt_user.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_user.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_user.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_user.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_user.FocusedState.BorderColor = Color.FromArgb(31, 111, 95);
            txt_user.Font = new Font("Segoe UI", 9F);
            txt_user.ForeColor = Color.Black;
            txt_user.HoverState.BorderColor = Color.FromArgb(64, 138, 113);
            txt_user.IconLeft = Properties.Resources._15181400;
            txt_user.Location = new Point(40, 130);
            txt_user.Margin = new Padding(3, 4, 3, 4);
            txt_user.Name = "txt_user";
            txt_user.PlaceholderForeColor = SystemColors.ScrollBar;
            txt_user.PlaceholderText = "Username";
            txt_user.SelectedText = "";
            txt_user.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_user.Size = new Size(320, 45);
            txt_user.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 245, 235);
            ClientSize = new Size(849, 609);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel label;
        private Guna.UI2.WinForms.Guna2TextBox txt_password;
        private Guna.UI2.WinForms.Guna2TextBox txt_user;
        private Guna.UI2.WinForms.Guna2Button btn_login;
        private System.Windows.Forms.Timer timer1;
    }
}
