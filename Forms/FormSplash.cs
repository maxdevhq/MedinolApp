using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedinolApp.Forms
{
    public partial class FormSplash : Form
    {
        private ProgressBar progressBar;
        private Label labelVersion;
        private Label labelStatus;

        public FormSplash()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            // Logo/Title Label
            Label labelTitle = new Label();
            labelTitle.Text = "MEDINOL";
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 28, System.Drawing.FontStyle.Bold);
            labelTitle.ForeColor = System.Drawing.Color.White;
            labelTitle.Location = new System.Drawing.Point(50, 50);
            labelTitle.AutoSize = true;
            this.Controls.Add(labelTitle);

            // Subtitle
            Label labelSubtitle = new Label();
            labelSubtitle.Text = "Legacy Medical Practice Management";
            labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 11);
            labelSubtitle.ForeColor = System.Drawing.Color.White;
            labelSubtitle.Location = new System.Drawing.Point(50, 95);
            labelSubtitle.AutoSize = true;
            this.Controls.Add(labelSubtitle);

            // Progress Bar
            this.progressBar = new ProgressBar();
            this.progressBar.Location = new System.Drawing.Point(50, 180);
            this.progressBar.Size = new System.Drawing.Size(400, 20);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.Controls.Add(this.progressBar);

            // Status Label
            this.labelStatus = new Label();
            this.labelStatus.Text = "Initializing...";
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 10);
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(50, 210);
            this.labelStatus.AutoSize = true;
            this.Controls.Add(this.labelStatus);

            // Version Label
            this.labelVersion = new Label();
            this.labelVersion.Text = "Version 1.0.0";
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9);
            this.labelVersion.ForeColor = System.Drawing.Color.LightGray;
            this.labelVersion.Location = new System.Drawing.Point(50, 260);
            this.labelVersion.AutoSize = true;
            this.Controls.Add(this.labelVersion);
        }

        public async Task ShowWithProgressAsync()
        {
            this.Show();
            await Task.Delay(2000);
        }
    }
}