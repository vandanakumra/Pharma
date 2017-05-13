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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Common.LoggedInUser = new PharmaBusinessObjects.Master.UserMaster(){ Username = "admin" };
        }

        private ItemMaster itemMaster = new ItemMaster();

        private void Form1_Load(object sender, EventArgs e)
        {
            StartMigration();
        }        

        private void  StartMigration()
        {
            bool result = itemMaster.InsertItemMasterData();
        }
    }
}
