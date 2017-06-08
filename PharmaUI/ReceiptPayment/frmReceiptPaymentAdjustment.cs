using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmReceiptPaymentAdjustment : Form
    {
        IApplicationFacade applicationFacade;
        public TransactionEntity CurrentTransactionEntity;
        public ReceiptPaymentState ReceiptPaymentState;


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

                dgvReceiptPaymentAdjustment.CellEndEdit += DgvReceiptPaymentAdjustment_CellEndEdit;
                LoadGridBillAdjustment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvReceiptPaymentAdjustment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    string columnName = dgvReceiptPaymentAdjustment.Columns[dgvReceiptPaymentAdjustment.SelectedCells[0].ColumnIndex].Name;

                    if (columnName == "Amount")
                    {

                        double enteredAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value)) ?? default(double);
                        double correspondingOSAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvReceiptPaymentAdjustment.CurrentRow.Cells["OSAmount"].Value)) ?? default(double);

                        double utilizedAmount = GetTotallUtilizedAmount();
                        double tempBalance= CurrentTransactionEntity.EntityTotalAmount - utilizedAmount;
                
                        if (enteredAmount > tempBalance)
                        {
                            MessageBox.Show("Balance amount is less !");
                            dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value = 0;

                        }
                        else if (enteredAmount > correspondingOSAmount)
                        {
                            MessageBox.Show("Entered amount is greater than OS amount !");
                            dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value = 0;
                        }
                        else if (enteredAmount > 0)
                        {
                            CurrentTransactionEntity.EntityBalAmount = CurrentTransactionEntity.EntityTotalAmount - utilizedAmount - enteredAmount;
                            lblBalAmountVal.Text = this.CurrentTransactionEntity.EntityBalAmount.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvReceiptPaymentAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private double GetTotallUtilizedAmount()
        {
            double utilizedAmount = 0;
            for (int i = 0; i < dgvReceiptPaymentAdjustment.Rows.Count; ++i)
            {
                if (i == dgvReceiptPaymentAdjustment.CurrentRow.Index)
                    continue;

                utilizedAmount += Convert.ToDouble(dgvReceiptPaymentAdjustment.Rows[i].Cells["Amount"].Value);
            }
            return utilizedAmount;
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
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].DisplayIndex = 1;

            dgvReceiptPaymentAdjustment.Columns["OSAmount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].DisplayIndex = 2;

            dgvReceiptPaymentAdjustment.Columns["Amount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["Amount"].HeaderText = "Amount";
            dgvReceiptPaymentAdjustment.Columns["Amount"].DisplayIndex = 3;
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

            if(keyData == Keys.End)
            {
                if (dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    List<BillAdjusted> listBillAdjustment = dgvReceiptPaymentAdjustment.Rows
                                                                             .Cast<DataGridViewRow>()
                                                                             .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Amount"].Value)) && Convert.ToDouble(r.Cells["Amount"].Value) > 0)
                                                                             .Select(x => new BillAdjusted()
                                                                             {
                                                                                 ReceiptPaymentID = CurrentTransactionEntity.ReceiptPaymentID,
                                                                                 PurchaseSaleBookHeaderID = (x.DataBoundItem as BillAdjusted).PurchaseSaleBookHeaderID,
                                                                                 BillOutStandingsID = (x.DataBoundItem as BillAdjusted).BillOutStandingsID,
                                                                                 AdjustmentVoucherNumber = (x.DataBoundItem as BillAdjusted).VoucherNumber,
                                                                                 AdjustmentVoucherTypeCode = (x.DataBoundItem as BillAdjusted).VoucherTypeCode,
                                                                                 AdjustmentVoucherDate = (x.DataBoundItem as BillAdjusted).VoucherDate,
                                                                                 LedgerType = (x.DataBoundItem as BillAdjusted).LedgerType,
                                                                                 LedgerTypeCode = (x.DataBoundItem as BillAdjusted).LedgerTypeCode,
                                                                                 Amount = (x.DataBoundItem as BillAdjusted).Amount,

                                                                             }).ToList();

                    applicationFacade.InsertTempBillAdjustment(listBillAdjustment);

                    ReceiptPaymentState = ReceiptPaymentState.Save;
                    this.Close();
                }            
            }
            else if (keyData == Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show(Constants.Messages.UnsavedDataWarning, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    ReceiptPaymentState = ReceiptPaymentState.Cancel;
                    applicationFacade.ClearTempBillAdjustment(CurrentTransactionEntity);
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
