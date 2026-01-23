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
    public partial class EditCustomerInfo : Form
    {
        private readonly CarRentalEntities _db;
        private ManageCustomerInfo _manageCustomerInfo;
        public EditCustomerInfo(ManageCustomerInfo editCusInfo, ManageCustomerInfo manageCustomerInfo = null)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageCustomerInfo = new ManageCustomerInfo();
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

        }

        private void populateFields(ManageCustomerInfo record)
        {
            tbCustomerName.Text = record.Customer;
            tbBank.Text = 

        }
    }
}
