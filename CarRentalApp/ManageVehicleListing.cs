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
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
           
        }

        public void PopulateGrid()
        {
            /*
           Select * From TypeOfCars
           var cars = _db.TypesOfCars.ToList();
           */

            var cars = _db.TypesOfCars
                .Select(q => new { q.Make, q.Modle, q.VIN, q.Year, q.LicensePlateNumber, q.Id })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            var addVehicleWindow = new AddEditVehicle(this);
            addVehicleWindow.MdiParent = this.MdiParent;
            addVehicleWindow.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                var editVehicleWindow = new AddEditVehicle(car,this);
                editVehicleWindow.MdiParent = this.MdiParent;
                editVehicleWindow.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete this Record?", "Delet", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _db.TypesOfCars.Remove(car);
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
            gvVehicleList.Refresh();
        }
    }
}
