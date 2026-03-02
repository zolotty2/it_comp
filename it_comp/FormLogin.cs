namespace it_comp
{
    public partial class FormLogin : Form
    {
        public User CurrentUser;
        public bool isGuest = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private Panel LoginPnl;
        private Button GuestBtn;
        private Button LoginBtn;
        private TextBox PasswordTxt;
        private TextBox LoginTxt;
        private Label PasswordLbl;
        private Label EmailLbl;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            LoginPnl = new Panel();
            GuestBtn = new Button();
            LoginBtn = new Button();
            PasswordTxt = new TextBox();
            LoginTxt = new TextBox();
            PasswordLbl = new Label();
            EmailLbl = new Label();
            pictureBox1 = new PictureBox();
            LoginPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoginPnl
            // 
            LoginPnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            LoginPnl.Controls.Add(GuestBtn);
            LoginPnl.Controls.Add(LoginBtn);
            LoginPnl.Controls.Add(PasswordTxt);
            LoginPnl.Controls.Add(LoginTxt);
            LoginPnl.Controls.Add(PasswordLbl);
            LoginPnl.Controls.Add(EmailLbl);
            LoginPnl.Location = new Point(120, 163);
            LoginPnl.Name = "LoginPnl";
            LoginPnl.Size = new Size(360, 194);
            LoginPnl.TabIndex = 0;
            // 
            // GuestBtn
            // 
            GuestBtn.BackColor = Color.FromArgb(156, 211, 216);
            GuestBtn.Location = new Point(28, 166);
            GuestBtn.Name = "GuestBtn";
            GuestBtn.Size = new Size(306, 23);
            GuestBtn.TabIndex = 5;
            GuestBtn.Text = "Войти как гость";
            GuestBtn.UseVisualStyleBackColor = false;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.FromArgb(156, 211, 216);
            LoginBtn.Location = new Point(28, 137);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(306, 23);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Войти";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(28, 105);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(306, 26);
            PasswordTxt.TabIndex = 3;
            // 
            // LoginTxt
            // 
            LoginTxt.Location = new Point(28, 54);
            LoginTxt.Name = "LoginTxt";
            LoginTxt.Size = new Size(306, 26);
            LoginTxt.TabIndex = 2;
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Location = new Point(28, 83);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(69, 19);
            PasswordLbl.TabIndex = 1;
            PasswordLbl.Text = "Password";
            // 
            // EmailLbl
            // 
            EmailLbl.AutoSize = true;
            EmailLbl.Location = new Point(28, 32);
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Size = new Size(42, 19);
            EmailLbl.TabIndex = 0;
            EmailLbl.Text = "Email";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(209, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 132);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            ClientSize = new Size(610, 369);
            Controls.Add(pictureBox1);
            Controls.Add(LoginPnl);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "FormLogin";
            Text = "Логин";
            Load += FormLogin_Load;
            LoginPnl.ResumeLayout(false);
            LoginPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }


        private PictureBox pictureBox1;

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(LoginTxt.Text) || String.IsNullOrEmpty(PasswordTxt.Text))
            {
                MessageBox.Show("Введите логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new ItCompanyContext())
                {
                    var user = db.Users.Where(w => w.Email == LoginTxt.Text && w.Password == PasswordTxt.Text).FirstOrDefault();

                    if (user != null)
                    {
                        CurrentUser = user;

                        isGuest = false;

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
            }
        }
    }
}
