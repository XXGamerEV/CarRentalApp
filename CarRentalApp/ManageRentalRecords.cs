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
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnAddRercord_Click(object sender, EventArgs e)
        {

            if (!Utils.FromIsOpen("AddEditRentalRecord"))
            {
                var addRercordWindow = new AddEditRentalRecord();
                MdiParent = this.MdiParent;
                addRercordWindow.Show();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                if (!Utils.FromIsOpen("AddEditRentalRecord"))
                {
                    var editRecordWindow = new AddEditRentalRecord(record, this);
                    editRecordWindow.MdiParent = this.MdiParent;
                    editRecordWindow.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;
                var records = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete this Record?", "Delet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _db.CarRentalRecords.Remove(records);
                    _db.SaveChanges();
                }
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
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
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords.Select(q => new
            {
                Customer = q.CustomerName,
                DateOut = q.DateRented,
                DateIn = q.DateReturned,
                Id = q.id,
                q.Cost,
                Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Modle
            }).ToList();

            gvRecordList.DataSource = records;
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["Id"].Visible = false;
        }
    }
}
