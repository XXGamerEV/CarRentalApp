using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addRentalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "AddEditRentalRecord");
            if (!isOpen)
            {
                var addRentalRecordWindow = new AddEditRentalRecord();
                addRentalRecordWindow.ShowDialog();
                addRentalRecordWindow.MdiParent = this;
            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "ManageVehicleListing");
            if(!isOpen)
            {
                var vehicleListingWindow = new ManageVehicleListing();
                vehicleListingWindow.MdiParent = this;
                vehicleListingWindow.Show();
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "ManageRentalRecords");
            if (!isOpen)
            {
                var manageRentalRecordsWindow = new ManageRentalRecords();
                manageRentalRecordsWindow.MdiParent = this;
                manageRentalRecordsWindow.Show();
            }
        }
    }
}
