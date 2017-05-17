﻿using System;
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
            Common.asmCodeMap = new List<ASMCodeMap>();
            Common.rsmCodeMap = new List<RSMCodeMap>();
            Common.zsmCodeMap = new List<ZSMCodeMap>();
            Common.salesmanCodeMap = new List<SalesManCodeMap>();
            Common.routeCodeMap = new List<RouteCodeMap>();
            Common.areaCodeMap = new List<AreaCodeMap>();
            Common.personalLedgerCodeMap = new List<PersonalLedgerCodeMap>();
            Common.controlCodeMap = new List<ControlCodeMap>();
            Common.accountLedgerCodeMap = new List<AccountLedgerCodeMap>();
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
                //Common.DataDirectory = txtDataDirectory.Text;
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
            CompanyMaster companyMaster = new CompanyMaster();
            ItemMaster itemMaster = new ItemMaster();
            PersonRouteMaster personRouteMaster = new PersonRouteMaster();
            PersonalLedgerMaster personalLedgerMaster = new PersonalLedgerMaster();
            AccountLedgerMaster accountLedgerMaster = new AccountLedgerMaster();
            int result;

            grdDataMigration.Rows.Add("Company Master", "Processing", 0);
            result = 0;

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

            result = personRouteMaster.InsertSalesManData();

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

            grdDataMigration.Rows.Add("Personal Details", "Processing", 0);
            result = 0;

            result = personalLedgerMaster.InsertPersonalLedgerMasterData();

            grdDataMigration.Rows[8].Cells[1].Value = "Completed";
            grdDataMigration.Rows[8].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Control Codes", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertControlCodesData();

            grdDataMigration.Rows[9].Cells[1].Value = "Completed";
            grdDataMigration.Rows[9].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Income Ledger", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertIncomeLedgerData();

            grdDataMigration.Rows[10].Cells[1].Value = "Completed";
            grdDataMigration.Rows[10].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Expenditure Ledger", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertExpenditureLedgerData();

            grdDataMigration.Rows[11].Cells[1].Value = "Completed";
            grdDataMigration.Rows[11].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Transaction Books", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertTransactionLedgerData();

            grdDataMigration.Rows[12].Cells[1].Value = "Completed";
            grdDataMigration.Rows[12].Cells[2].Value = result;

            grdDataMigration.Rows.Add("General Ledger", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertGeneralLedgerData();

            grdDataMigration.Rows[13].Cells[1].Value = "Completed";
            grdDataMigration.Rows[13].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Purchase Ledger", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertPurchaseLedgerData();

            grdDataMigration.Rows[14].Cells[1].Value = "Completed";
            grdDataMigration.Rows[14].Cells[2].Value = result;

            grdDataMigration.Rows.Add("Sale Ledger", "Processing", 0);
            result = 0;

            result = accountLedgerMaster.InsertSaleLedgerData();

            grdDataMigration.Rows[15].Cells[1].Value = "Completed";
            grdDataMigration.Rows[15].Cells[2].Value = result;
        }
    }
}
