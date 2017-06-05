using PharmaBusinessObjects;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmReceiptPaymentAdjustment : Form
    {
        IApplicationFacade applicationFacade;
        TransactionEntity CurrentTransactionEntity;

        public frmReceiptPaymentAdjustment()
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmReceiptPaymentAdjustment_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Receipt Payment Adjustment");
                LoadGridBillAdjustment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridBillAdjustment()
        {
            dgvReceiptPaymentAdjustment.DataSource = applicationFacade.GetAllInitialBillAdjustmentForLedger(CurrentTransactionEntity);

            dgvReceiptPaymentAdjustment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptPaymentAdjustment.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReceiptPaymentAdjustment.AllowUserToAddRows = false;

            for (int i = 0; i < dgvReceiptPaymentAdjustment.Columns.Count; i++)
            {
                dgvReceiptPaymentAdjustment.Columns[i].Visible = false;
            }

            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].HeaderText = "Bill Number";

            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].HeaderText = "Bill Date";

            dgvReceiptPaymentAdjustment.Columns["OSAmount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].HeaderText = "Outstanding Amount";

            dgvReceiptPaymentAdjustment.Columns["Amount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["Amount"].HeaderText = "Amount";

        }

        public void ConfigureReceiptPaymentAdjustment(TransactionEntity transactionEntity)
        {
            this.CurrentTransactionEntity = transactionEntity;

            this.lblPartyCodeVal.Text = transactionEntity.EntityCode;
            this.lblPartyNameVal.Text = transactionEntity.EntityName;
            this.lblTotalAmountVal.Text = Convert.ToString(transactionEntity.EntityTotalAmount);
            this.lblBalAmountVal.Text = Convert.ToString(transactionEntity.EntityBalAmount);          
        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F9))
            {

            }
            else if (keyData == (Keys.F3))
            {
              
            }
            else if (keyData == Keys.F1)
            {

            }
            else if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
