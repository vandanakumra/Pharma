﻿using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmAccountLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private int AccountLedgerId { get; set; }

        public frmAccountLedgerMasterAddUpdate()
        {

            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        public frmAccountLedgerMasterAddUpdate(int accountLedgerId)
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
            this.AccountLedgerId = accountLedgerId;
        }


        private void frmAccountLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            FormLoad();

            if (this.AccountLedgerId > 0)
            {
                //lblAccNo.Visible = true;
                //txtAccountLedgerCode.Visible = true;

                FillFormForUpdate();
            }
            else
            {
                //lblAccNo.Visible = false;
                //txtAccountLedgerCode.Visible = false;
                FillCombo();
            }

        }

        private void FillFormForUpdate()
        {
            cbAccountLedgerType.SelectedIndexChanged -= CbAccountLedgerType_SelectedIndexChanged;

            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            var accountLedgerMaster = applicationFacade.GetAccountLedgerById(this.AccountLedgerId);

            cbAccountLedgerType.DataSource = accountLedgerMaster.AccountLedgerTypeList;
            cbAccountLedgerType.ValueMember = "AccountLedgerTypeID";
            cbAccountLedgerType.DisplayMember = "AccountLedgerTypeName";

            cbAccountType.DataSource = accountLedgerMaster.AccountTypeList;
            cbAccountType.ValueMember = "AccountTypeID";
            cbAccountType.DisplayMember = "AccountTypeDisplayName";

            if (accountLedgerMaster.AccountLedgerTypeSystemName != "ControlCodes")
            {
                var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");
                var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");

                cbDebitControlCode.DataSource = debitControlCodes;
                cbCreditControlCode.DataSource = creditControlCodes;

                cbDebitControlCode.ValueMember = "AccountLedgerID";
                cbDebitControlCode.DisplayMember = "AccountLedgerCode";

                cbCreditControlCode.ValueMember = "AccountLedgerID";
                cbCreditControlCode.DisplayMember = "AccountLedgerCode";

                cbCreditControlCode.SelectedValue = accountLedgerMaster.CreditControlCodeID;
                cbDebitControlCode.SelectedValue = accountLedgerMaster.DebitControlCodeID;

                gbBalanceSheet.Visible = true;
            }
            else
            {
                cbDebitControlCode.DataSource = null;
                cbCreditControlCode.DataSource = null;
                gbBalanceSheet.Visible = false;
            }

            cbAccountLedgerType.SelectedValue = accountLedgerMaster.AccountLedgerTypeId;            
            cbDebitCredit.SelectedItem = accountLedgerMaster.CreditDebit;
            cbxStatus.SelectedItem = accountLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

            tbAccountName.Text = accountLedgerMaster.AccountLedgerName;
            txtAccountLedgerCode.Text = accountLedgerMaster.AccountLedgerCode;
            tbOpeningBalance.Text = Convert.ToString(accountLedgerMaster.OpeningBalance);


        }

        private void FormLoad()
        {
            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));

            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);

            if (this.AccountLedgerId > 0)
            {
                lbl.Text = "Account Ledger Master - Update";
            }
            else
            {
                lbl.Text = "Account Ledger Master - Add";
            }

            panel1.Controls.Add(lbl);
        }

        private void FillCombo()
        {
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

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
                var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");
                var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");

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
                var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");
                var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName("ControlCodes");

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
            if (string.IsNullOrEmpty(tbAccountName.Text))
            {
                throw new Exception("Account Name can not be blank");
            }

            if (string.IsNullOrEmpty(tbOpeningBalance.Text))
            {
                throw new Exception("Account Name can not be blank");
            }

            Status status;

            AccountLedgerMaster model = new AccountLedgerMaster();
            model.AccountLedgerTypeId = (int)cbAccountLedgerType.SelectedValue;
            model.AccountLedgerName = tbAccountName.Text;
            model.AccountTypeId = (int)cbAccountType.SelectedValue;
            model.OpeningBalance = Convert.ToDouble(tbOpeningBalance.Text);
            model.CreditDebit = cbDebitCredit.Text;
            model.AccountLedgerCode = txtAccountLedgerCode.Text;

            if (cbDebitControlCode.DataSource != null)
            {
                model.DebitControlCodeID = (int)cbDebitControlCode.SelectedValue;
                model.CreditControlCodeID = (int)cbCreditControlCode.SelectedValue;
            }
            model.AccountLedgerID = this.AccountLedgerId;

            Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
            model.Status = status == Status.Active;

            var result = this.AccountLedgerId > 0 ? applicationFacade.UpdateAccountLedger(model) : applicationFacade.AddAccountLedger(model);

            if (result > 0)
            {
                this.Close();
            }
        }

        private void tbOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
