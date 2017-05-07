using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmAccountLedgerMasterAddUpdate : Form
    {
       
        IApplicationFacade applicationFacade;

        public frmAccountLedgerMasterAddUpdate()
        {

            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }


        private void frmAccountLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Text = "Account Ledger Master - ADD";
            panel1.Controls.Add(lbl);

            FillCombo();

        }

        private void FillCombo()
        {
            var accountLedgerTypes = applicationFacade.GetAccountLedgerTypes();
            cbAccountLedgerType.DataSource = accountLedgerTypes;
            cbAccountLedgerType.ValueMember = "AccountLedgerTypeID";
            cbAccountLedgerType.DisplayMember = "AccountLedgerTypeName";

            cbAccountType.DataSource = applicationFacade.GetAccountTypes();
            cbAccountType.ValueMember = "AccountTypeID";
            cbAccountType.DisplayMember = "AccountTypeDisplayName";

            cbDebitCredit.SelectedItem = "C";
            
            if (accountLedgerTypes.FirstOrDefault().AccountLedgerTypeSystemName != "ControlCodes")
            {
                var debitControlCodes = applicationFacade.GetDebitCreditControlCodes();
                var creditControlCodes = applicationFacade.GetDebitCreditControlCodes();

                cbDebitControlCode.DataSource = debitControlCodes;
                cbCreditControlCode.DataSource = creditControlCodes;

                cbDebitControlCode.ValueMember = "AccountLedgerID";
                cbDebitControlCode.DisplayMember = "AccountLedgerCode";

                cbCreditControlCode.ValueMember = "AccountLedgerID";
                cbCreditControlCode.DisplayMember = "AccountLedgerCode";

               gbBalanceSheet.Visible = true;
            }
            else
            {
                cbDebitControlCode.DataSource = null;
                cbCreditControlCode.DataSource = null;
                gbBalanceSheet.Visible = false;
            }

            cbAccountLedgerType.SelectedIndexChanged += CbAccountLedgerType_SelectedIndexChanged;
                 
        }

        private void CbAccountLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {

            var accountLedger = applicationFacade.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == (int)cbAccountLedgerType.SelectedValue).FirstOrDefault();

            if (accountLedger.AccountLedgerTypeSystemName != "ControlCodes")
            {
                var debitControlCodes = applicationFacade.GetDebitCreditControlCodes();
                var creditControlCodes = applicationFacade.GetDebitCreditControlCodes();

                cbDebitControlCode.DataSource = debitControlCodes;
                cbCreditControlCode.DataSource = creditControlCodes;

                cbDebitControlCode.ValueMember = "AccountLedgerID";
                cbDebitControlCode.DisplayMember = "AccountLedgerCode";

                cbCreditControlCode.ValueMember = "AccountLedgerID";
                cbCreditControlCode.DisplayMember = "AccountLedgerCode";

                gbBalanceSheet.Visible = true;
            }
            else
            {
                cbDebitControlCode.DataSource = null;
                cbCreditControlCode.DataSource = null;
                gbBalanceSheet.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbAccountName.Text))
            {
                throw new Exception("Account Name can not be blank");
            }

            if (string.IsNullOrEmpty(tbOpeningBalance.Text))
            {
                throw new Exception("Account Name can not be blank");
            }
            
            AccountLedgerMaster model = new AccountLedgerMaster();
            model.AccountLedgerTypeId = (int)cbAccountLedgerType.SelectedValue;
            model.AccountLedgerName = tbAccountName.Text;            
            model.AccountTypeId = (int)cbAccountType.SelectedValue;
            model.OpeningBalance = Convert.ToDouble(tbOpeningBalance.Text);
            model.CreditDebit = cbDebitCredit.Text;

            if (cbDebitControlCode.DataSource != null)
            {
                model.DebitControlCodeID = (int)cbDebitControlCode.SelectedValue;
                model.CreditControlCodeID = (int)cbCreditControlCode.SelectedValue;
            }

            applicationFacade.AddAccountLedger(model);

            this.Close();
        }
    }
}
