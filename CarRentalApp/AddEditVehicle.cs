using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private readonly CarRentalEntities _db;
        private bool isEditMode;
        private ManageVehicleListing _manageVehicleListing;
        private String errorMessage = "";
        public AddEditVehicle(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            this.Text = lblTitle.Text;
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();
        }

        public AddEditVehicle(TypesOfCar carToEdit, ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            this.Text = lblTitle.Text;
            _manageVehicleListing = manageVehicleListing;
            if (carToEdit == null)
            {
                MessageBox.Show("Please ensure that you have selected a valid record to edit");
            }
            else 
            { 
                isEditMode = true;
                _db = new CarRentalEntities();
                populateFields(carToEdit);
            }
        }

        private void populateFields(TypesOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Modle;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicensePlateNumber.Text = car.LicensePlateNumber;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrWhiteSpace(tbMake.Text)) || string.IsNullOrWhiteSpace(tbModel.Text))
                {
                    MessageBox.Show("Please ensure that you provide a make and model");
                }
                else
                {
                    if (isEditMode)
                    {
                        var id = int.Parse(lblId.Text);
                        var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                        car.Modle = tbMake.Text;
                        car.Make = tbModel.Text;
                        car.VIN = tbVIN.Text;
                        car.Year = int.Parse(tbYear.Text);
                        car.LicensePlateNumber = tbLicensePlateNumber.Text;

                        _db.SaveChanges();
                    }
                    else
                    {
                        var newCar = new TypesOfCar
                        {
                            Modle = tbModel.Text,
                            Make = tbMake.Text,
                            VIN = tbVIN.Text,
                            Year = int.Parse(tbYear.Text),
                            LicensePlateNumber = tbLicensePlateNumber.Text
                        };

                        _db.TypesOfCars.Add(newCar);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            _manageVehicleListing.PopulateGrid();
            MessageBox.Show("Saved Successfully");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
