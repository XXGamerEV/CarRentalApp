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
    public partial class EditCustomerInfo : Form
    {
        private readonly CarRentalEntities _db;
        private ManageCustomerInfo _manageCustomerInfo;
        private CarRentalRecord _record;
        public EditCustomerInfo(CustomerInfo editCusInfo, ManageCustomerInfo manageCustomerInfo = null)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageCustomerInfo = new ManageCustomerInfo();
            _record = new CarRentalRecord();
            if (editCusInfo == null)
            {
                MessageBox.Show("Please ensure that you have selected a valid record to edit");
            }
            else
            {
                _db = new CarRentalEntities();
                populateFields(editCusInfo);
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                string bank = tbBank.Text;
                var car = cbCar.Text;
                var errorMessage = "";
                var isValid = true;
                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(car))
                {
                    errorMessage += "Error: Please enter missing data. \n \r";
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(bank))
                {
                    errorMessage += "Error: Please enter cash if no bank. \n \r";
                    isValid = false;
                }
                if (isValid)
                {
                    var customerRec = new CustomerInfo();
                    var rentalRecord = new CarRentalRecord();
                    var id = int.Parse(lblRecordId.Text);
                    rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                    customerRec = _db.CustomerInfoes.FirstOrDefault(q => q.Id == id);

                    rentalRecord.CustomerName = customerName;
                    rentalRecord.TypeOFCarId = (int)cbCar.SelectedValue;

                    customerRec.Customer = customerName;
                    customerRec.Bank = bank;
                    customerRec.CarId = (int)cbCar.SelectedValue;

                    _db.SaveChanges();
                    _manageCustomerInfo.PopulateGrid();

                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                        $"Bank: {bank}\n\r" +
                        $"Car: {car}");

                    Close();




                }
            }
            catch (Exception)
            {

                throw;
            }
 
        }

        private void populateFields(CustomerInfo record)
        {
            tbCustomerName.Text = record.Customer;
            tbBank.Text = record.Bank;
            lblRecordId.Text = record.Id.ToString();

        }

        private void EditCustomerInfo_Load(object sender, EventArgs e)
        {
            var cars = _db.TypesOfCars
                .Select(q => new { Id = q.Id, Name = q.Make + " " + q.Modle })
                .ToList();
            cbCar.DisplayMember = "Name";
            cbCar.ValueMember = "id";
            cbCar.DataSource = cars;
        }
    }
}
