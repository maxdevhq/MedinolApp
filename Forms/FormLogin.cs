using System;
using System.Windows.Forms;

namespace MedinolApp.Forms
{
    public partial class FormLogin : Form
    {
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonCancel;

        public string Username { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            // Title Label
            Label labelTitle = new Label();
            labelTitle.Text = "Login to Medinol";
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(20, 20);
            labelTitle.Size = new System.Drawing.Size(350, 30);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.Controls.Add(labelTitle);

            // Username Label
            Label labelUsername = new Label();
            labelUsername.Text = "Username:";
            labelUsername.Location = new System.Drawing.Point(20, 70);
            labelUsername.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelUsername);

            // Username TextBox
            this.textBoxUsername = new TextBox();
            this.textBoxUsername.Location = new System.Drawing.Point(130, 70);
            this.textBoxUsername.Size = new System.Drawing.Size(230, 20);
            this.Controls.Add(this.textBoxUsername);

            // Password Label
            Label labelPassword = new Label();
            labelPassword.Text = "Password:";
            labelPassword.Location = new System.Drawing.Point(20, 110);
            labelPassword.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelPassword);

            // Password TextBox
            this.textBoxPassword = new TextBox();
            this.textBoxPassword.Location = new System.Drawing.Point(130, 110);
            this.textBoxPassword.Size = new System.Drawing.Size(230, 20);
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.Controls.Add(this.textBoxPassword);

            // Login Button
            this.buttonLogin = new Button();
            this.buttonLogin.Text = "Login";
            this.buttonLogin.Location = new System.Drawing.Point(130, 160);
            this.buttonLogin.Size = new System.Drawing.Size(100, 35);
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Cursor = Cursors.Hand;
            this.buttonLogin.Click += ButtonLogin_Click;
            this.Controls.Add(this.buttonLogin);

            // Cancel Button
            this.buttonCancel = new Button();
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Location = new System.Drawing.Point(260, 160);
            this.buttonCancel.Size = new System.Drawing.Size(100, 35);
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Cursor = Cursors.Hand;
            this.buttonCancel.Click += ButtonCancel_Click;
            this.Controls.Add(this.buttonCancel);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Username = this.textBoxUsername.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}