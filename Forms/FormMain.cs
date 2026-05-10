using System;
using System.Windows.Forms;

namespace MedinolApp.Forms
{
    public partial class FormMain : Form
    {
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;

        public FormMain()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            // Menu Strip
            this.menuStrip = new MenuStrip();
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            fileMenu.DropDownItems.Add("&Exit", null, (s, e) => this.Close());
            this.menuStrip.Items.Add(fileMenu);

            ToolStripMenuItem viewMenu = new ToolStripMenuItem("&View");
            viewMenu.DropDownItems.Add("&Dashboard", null, (s, e) => ShowForm(new FormDashboard()));
            viewMenu.DropDownItems.Add("&Patients", null, (s, e) => ShowForm(new FormPatients()));
            viewMenu.DropDownItems.Add("&Billing", null, (s, e) => ShowForm(new FormBilling()));
            this.menuStrip.Items.Add(viewMenu);

            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;

            // Status Strip
            this.statusStrip = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel("Ready");
            this.statusStrip.Items.Add(this.statusLabel);
            this.Controls.Add(this.statusStrip);
        }

        private void ShowForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }
    }
}