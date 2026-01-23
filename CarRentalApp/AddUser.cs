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
    public partial class AddUser : Form
    {
        private readonly CarRentalEntities _db;
        private ManageUsers _manageUsers;
        public AddUser(ManageUsers manageUsers)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageUsers = manageUsers;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "id";
            cbRole.DataSource = roles;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var roleID = (int)cbRole.SelectedValue;
                var password = Utils.DefaultHashPassward();
                var user = new User
                {
                    username = username,
                    password = password,
                    isActive = true
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                var userId = user.id;
                var userRole = new UserRole
                {
                    roleid = roleID,
                    userid = userId
                };
                _db.UserRoles.Add(userRole);
                _db.SaveChanges();

                MessageBox.Show("New User Added");
                _manageUsers.PopulateGrid();
                Close();

            }
            catch (Exception)
            {

                MessageBox.Show("An Error happened");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
