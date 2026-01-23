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
    public partial class ManageCustomerInfo : Form
    {
        private readonly CarRentalEntities _db;
        public ManageCustomerInfo()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvCustomerList.SelectedRows[0].Cells["Id"].Value;
                var customer = _db.CustomerInfoes.FirstOrDefault(q => q.Id == id);

                if (!Utils.FromIsOpen("EditCustomerInfo"))
                {
                    var editCustomerInfoWindow = new EditCustomerInfo(customer, this);
                    editCustomerInfoWindow.MdiParent = this.MdiParent;
                    editCustomerInfoWindow.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteCustomerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvCustomerList.SelectedRows[0].Cells["Id"].Value;
                var Customer = _db.CustomerInfoes.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete this Record?", "Delet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _db.CustomerInfoes.Remove(Customer);
                    _db.SaveChanges();
                }
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        public void PopulateGrid()
        {
            var customers = _db.CustomerInfoes.Select(q => new
            {
                q.Customer,
                q.Bank,
                q.Id,
                Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Modle,
                q.CarId,
            }).ToList();

            gvCustomerList.DataSource = customers;
            gvCustomerList.Columns["Id"].Visible = false;
            gvCustomerList.Columns["CarId"].Visible = false;
        }

        private void ManageCustomerInfo_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
