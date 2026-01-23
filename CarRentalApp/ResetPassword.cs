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
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        private User _user;
        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
        }

        private void btnPassReset_Click(object sender, EventArgs e)
        {
            try
            {
                var password = tbNewPass.Text;
                var passconfirm = tbConfirmPass.Text;
                var user = _db.Users.FirstOrDefault(q => q.id == _user.id);
                if (password != passconfirm)
                {
                    MessageBox.Show("Passwords do not match. Please try again!");
                }
                user.password = Utils.HashPassward(passconfirm);
                _db.SaveChanges();
                MessageBox.Show("New password saved");
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("There was an Error. Please try again.");
            }

        }
    }
}
