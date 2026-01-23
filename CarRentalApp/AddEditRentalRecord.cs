using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditRentalRecord : Form
    {
        private readonly CarRentalEntities _db;
        private bool isEditMode;
        private ManageRentalRecords _manageRentalRecords;

        public AddEditRentalRecord(ManageRentalRecords manageRentalRecords = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add Rental Record";
            this.Text = lblTitle.Text;
            isEditMode = false;
            _manageRentalRecords = manageRentalRecords;
            _db = new CarRentalEntities();
        }

        public AddEditRentalRecord(CarRentalRecord recordToEdit, ManageRentalRecords manageRentalRecords = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Rental Record";
            this.Text = lblTitle.Text;
            _manageRentalRecords = manageRentalRecords;
            if (recordToEdit == null)
            {
                MessageBox.Show("Please ensure that you have selected a valid record to edit");
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                populateFields(recordToEdit);
            }
        }

        private void populateFields(CarRentalRecord record)
        {
            tbCustomerName.Text = record.CustomerName;
            dtpDateRented.Value = (DateTime)record.DateRented;
            dtpDateReturned.Value = (DateTime)record.DateReturned;
            tbCost.Text = record.Cost.ToString();
            lblRecordId.Text = record.id.ToString();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                var dateOut = dtpDateRented.Value;
                var dateIn = dtpDateReturned.Value;
                double cost = Convert.ToDouble(tbCost.Text);

                var carType = cbTypeOfCar.Text;
                var isValid = true;
                var errorMessage = "";


                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    errorMessage += "Error: Please enter missing data. \n \r";
                    isValid = false;
                }

                if (dateOut >= dateIn)
                {
                    errorMessage += "Error: Illegal Date Selection \n\r";
                    isValid = false;
                }


                if (isValid)
                {
                    var rentalRecord = new CarRentalRecord();
                    var customer = new CustomerInfo();
                    if (isEditMode)
                    {
                        var id = int.Parse(lblRecordId.Text);
                        rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        customer = _db.CustomerInfoes.FirstOrDefault(q => q.Id == id);
                    }
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = dateOut;
                    rentalRecord.DateReturned = dateIn;
                    rentalRecord.Cost = (decimal)cost;
                    rentalRecord.TypeOFCarId = (int)cbTypeOfCar.SelectedValue;


                    customer.Customer = customerName;
                    customer.CarId = (int)cbTypeOfCar.SelectedValue;

                    if (!isEditMode)
                    {
                        _db.CarRentalRecords.Add(rentalRecord);
                        _db.CustomerInfoes.Add(customer);
                    }

                    _db.SaveChanges();
                    _manageRentalRecords.PopulateGrid();
                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                    $"Date Rented: {dateOut}\n\r" +
                    $"Date Returned: {dateIn}\n\r" +
                    $"Cost: {cost}\n\r" +
                    $"Car Type: {carType}\n\r" +
                    $"THANK YOU FOR YOUR BUSINESS");

                    Close();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* old way with only two things in deta
            var cars = carRentalEntities.TypesOfCars.ToList();
            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "id";
            cbTypeOfCar.DataSource = cars;
            */

            var cars = _db.TypesOfCars
                .Select(q => new {Id = q.Id, Name = q.Make + " " + q.Modle})
                .ToList();
            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "id";
            cbTypeOfCar.DataSource = cars;

        }
    }
}
