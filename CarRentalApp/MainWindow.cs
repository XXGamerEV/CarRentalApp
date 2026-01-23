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
        private Login _login;
        public string _roleName;
        public User _user;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login, User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void addRentalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FromIsOpen("AddEditRentalRecord"))
            {
                var addRentalRecordWindow = new AddEditRentalRecord();
                addRentalRecordWindow.MdiParent = this;
                addRentalRecordWindow.Show();
            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FromIsOpen("ManageVehicleListing"))
            {
                var vehicleListingWindow = new ManageVehicleListing();
                vehicleListingWindow.MdiParent = this;
                vehicleListingWindow.Show();
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FromIsOpen("ManageRentalRecords"))
            {
                var manageRentalRecordsWindow = new ManageRentalRecords();
                manageRentalRecordsWindow.MdiParent = this;
                manageRentalRecordsWindow.Show();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FromIsOpen("ManageUsers"))
            {
                var manageUsersWindow = new ManageUsers();
                manageUsersWindow.MdiParent = this;
                manageUsersWindow.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashPassward())
            {
                    var resetPasswordWindow = new ResetPassword(_user);
                    resetPasswordWindow.ShowDialog();
            }


            var username = _user.username;
            tsiLoginTxt.Text = username;
            if (_roleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FromIsOpen("ManageCustomerInfo"))
            {
                var manageCustomerInfoWindow = new ManageCustomerInfo();
                manageCustomerInfoWindow.MdiParent = this;
                manageCustomerInfoWindow.Show();
            }
        }
    }
}
