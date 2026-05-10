using System;
using System.Windows.Forms;

namespace MedinolApp.Forms
{
    public partial class FormPatients : Form
    {
        public FormPatients()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            Label label = new Label();
            label.Text = "Patients & Members Management\n\n(Under Development)";
            label.Font = new System.Drawing.Font("Segoe UI", 12);
            label.Location = new System.Drawing.Point(50, 50);
            label.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            label.AutoSize = true;
            this.Controls.Add(label);
        }
    }
}