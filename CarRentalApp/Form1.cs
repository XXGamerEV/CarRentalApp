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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                    $"Date Rented: {dateOut}\n\r" +
                    $"Date Returned: {dateIn}\n\r" +
                    $"Cost: {cost}\n\r" +
                    $"Car Type: {carType}\n\r" +
                    $"THANK YOU FOR YOUR BUSINESS");
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
    }
}
