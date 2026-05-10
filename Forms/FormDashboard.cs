using System;
using System.Windows.Forms;
using MedinolApp.Services;

namespace MedinolApp.Forms
{
    public partial class FormDashboard : Form
    {
        private DataAccessLayer _dal;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private Label labelStats;

        public FormDashboard()
        {
            InitializeComponent();
            _dal = new DataAccessLayer();
            CreateControls();
        }

        private void CreateControls()
        {
            // Title
            Label labelTitle = new Label();
            labelTitle.Text = "Dashboard - Global Search";
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(20, 20);
            labelTitle.AutoSize = true;
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.Controls.Add(labelTitle);

            // Search Box
            this.textBoxSearch = new TextBox();
            this.textBoxSearch.Location = new System.Drawing.Point(20, 70);
            this.textBoxSearch.Size = new System.Drawing.Size(500, 25);
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10);
            this.Controls.Add(this.textBoxSearch);

            // Search Button
            this.buttonSearch = new Button();
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Location = new System.Drawing.Point(530, 70);
            this.buttonSearch.Size = new System.Drawing.Size(100, 25);
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Cursor = Cursors.Hand;
            this.buttonSearch.Click += ButtonSearch_Click;
            this.Controls.Add(this.buttonSearch);

            // Statistics
            this.labelStats = new Label();
            this.labelStats.Text = "Loading statistics...";
            this.labelStats.Location = new System.Drawing.Point(20, 120);
            this.labelStats.Size = new System.Drawing.Size(700, 200);
            this.labelStats.Font = new System.Drawing.Font("Segoe UI", 11);
            this.Controls.Add(this.labelStats);

            this.Load += FormDashboard_Load;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                var members = _dal.GetAllMembers();
                var invoices = _dal.GetAllInvoices();
                var patients = _dal.GetAllPatients();
                var doctors = _dal.GetAllDoctors();

                this.labelStats.Text = string.Format(
                    "System Statistics:\n\nTotal Members: {0}\nTotal Invoices: {1}\nTotal Patients: {2}\nTotal Doctors: {3}",
                    members.Count, invoices.Count, patients.Count, doctors.Count);
            }
            catch (Exception ex)
            {
                this.labelStats.Text = string.Format("Error loading statistics: {0}", ex.Message);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxSearch.Text))
            {
                MessageBox.Show("Please enter a search term.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var results = _dal.GlobalSearch(this.textBoxSearch.Text);
                MessageBox.Show(
                    string.Format(
                        "Search Results:\n\nMembers: {0}\nInvoices: {1}\nPatients: {2}\nDoctors: {3}\n\nTotal: {4}",
                        results.Members.Count, results.Invoices.Count, results.Patients.Count, results.Doctors.Count, results.TotalResults),
                    "Search Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Search error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}