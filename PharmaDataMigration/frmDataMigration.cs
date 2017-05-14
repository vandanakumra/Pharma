using System;
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
            if(string.IsNullOrEmpty(txtDataDirectory.Text))
            {
                return;
            }
            else
            {
                Common.DataDirectory = txtDataDirectory.Text;
            }

            StartMigration();
        }

        private void StartMigration()
        {
            //List<DataMigrationResult> dmResult = new List<DataMigrationResult>();
            //dmResult.Add(new DataMigrationResult { TableName = "", Status = "", NumberOfRecords = 0 });
            ItemMaster itemMaster = new ItemMaster();
            PersonRouteMaster personRouteMaster = new PersonRouteMaster();
            int result = 0;

            grdDataMigration.Rows.Add("Item Master", "Processing", 0);

            result = itemMaster.InsertItemMasterData();

            grdDataMigration.Rows[0].Cells[1].Value = "Completed";
            grdDataMigration.Rows[0].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Person Route Master", "Processing", 0);

            result = 0;

            result = personRouteMaster.InsertASMData();
            result += personRouteMaster.InsertRSMData();
            result += personRouteMaster.InsertZSMData();
            //result += personRouteMaster.InsertSalesManData();
            result += personRouteMaster.InsertAreaData();
            result += personRouteMaster.InsertRouteData();

            grdDataMigration.Rows[1].Cells[1].Value = "Completed";
            grdDataMigration.Rows[1].Cells[2].Value = result;
        }
    }
}
