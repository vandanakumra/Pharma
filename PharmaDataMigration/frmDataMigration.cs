using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using PharmaDataMigration.Master;

namespace PharmaDataMigration
{
    public partial class frmDataMigration : Form
    {
        public frmDataMigration()
        {
            InitializeComponent();
            Common.LoggedInUser = new PharmaBusinessObjects.Master.UserMaster(){ Username = "admin" };
        }

        private void frmDataMigration_Load(object sender, EventArgs e)
        {
            
        }        

        private void btnDataDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdDataDirectory.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDataDirectory.Text = fbdDataDirectory.SelectedPath;
                Common.DataDirectory = txtDataDirectory.Text;
            }
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            StartMigration();
        }

        private void StartMigration()
        {
            //List<DataMigrationResult> dmResult = new List<DataMigrationResult>();
            //dmResult.Add(new DataMigrationResult { TableName = "", Status = "", NumberOfRecords = 0 });
            ItemMaster itemMaster = new ItemMaster();
            int result = 0;

            grdDataMigration.Rows.Add("Item Master", "Processing", 0);

            result = itemMaster.InsertItemMasterData();

            grdDataMigration.Rows[0].Cells[1].Value = "Completed";
            grdDataMigration.Rows[0].Cells[2].Value = result;
        }
    }
}
