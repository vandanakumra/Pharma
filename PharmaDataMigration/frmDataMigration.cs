using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PharmaDataMigration.Master;

namespace PharmaDataMigration
{
    public partial class frmDataMigration : Form
    {
        public frmDataMigration()
        {
            InitializeComponent();
            Common.LoggedInUser = new PharmaBusinessObjects.Master.UserMaster(){ Username = "admin" };
            Common.companyCodeMap = new List<CompanyCodeMap>();
            Common.itemCodeMap = new List<ItemCodeMap>();
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
            CompanyMaster companyMaster = new CompanyMaster();
            ItemMaster itemMaster = new ItemMaster();
            PersonRouteMaster personRouteMaster = new PersonRouteMaster();
            int result = 0;

            grdDataMigration.Rows.Add("Company Master", "Processing", 0);
            result = companyMaster.InsertCompanyMasterData();

            grdDataMigration.Rows[0].Cells[1].Value = "Completed";
            grdDataMigration.Rows[0].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Item Master", "Processing", 0);
            result = 0;

            result = itemMaster.InsertItemMasterData();

            grdDataMigration.Rows[1].Cells[1].Value = "Completed";
            grdDataMigration.Rows[1].Cells[2].Value = result;

            grdDataMigration.Rows.Add("A.S.M.", "Processing", 0);
            result = 0;

            result = personRouteMaster.InsertASMData();

            grdDataMigration.Rows[2].Cells[1].Value = "Completed";
            grdDataMigration.Rows[2].Cells[2].Value = result;

            grdDataMigration.Rows.Add("R.S.M.", "Processing", 0);
            result = 0;

            result = personRouteMaster.InsertRSMData();

            grdDataMigration.Rows[3].Cells[1].Value = "Completed";
            grdDataMigration.Rows[3].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Z.S.M.", "Processing", 0);
            result = 0;

            result = personRouteMaster.InsertZSMData();

            grdDataMigration.Rows[4].Cells[1].Value = "Completed";
            grdDataMigration.Rows[4].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Sales Man", "Processing", 0);
            result = 0;

            //result = personRouteMaster.InsertSalesManData();

            grdDataMigration.Rows[5].Cells[1].Value = "Completed";
            grdDataMigration.Rows[5].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Area", "Processing", 0);
            result = 0;

            result = personRouteMaster.InsertAreaData();

            grdDataMigration.Rows[6].Cells[1].Value = "Completed";
            grdDataMigration.Rows[6].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Route", "Processing", 0);
            result = 0;

            result = personRouteMaster.InsertRouteData();

            grdDataMigration.Rows[7].Cells[1].Value = "Completed";
            grdDataMigration.Rows[7].Cells[2].Value = result;
        }
    }
}
