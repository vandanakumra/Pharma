﻿using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmPaymentToSupplier : Form
    {

        IApplicationFacade applicationFacade;

        public frmPaymentToSupplier()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmPaymentToSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Payment To Supplier");
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);

                ///Load all the grid 
                ///
                LoadGridPaymentToSupplier();

                ///Grid events
                ///
                dgvPaymentToSupplier.KeyDown += dgvPaymentToSupplier_KeyDown;
               // dgvPaymentToSupplier.EditingControlShowing += dgvCustomerItemDiscount_EditingControlShowing;

                string format = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                format = format.IndexOf("MM") < 0 ? format.Replace("M", "MM") : format;
                format = format.IndexOf("dd") < 0 ? format.Replace("d", "dd") : format;
                dtReceiptPayment.Text = DateTime.Now.ToString(format);
                dtReceiptPayment.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridPaymentToSupplier()
        {
            ///Add All the columns as its not a Data Bound data source
            ///
            {
                dgvPaymentToSupplier.Columns.Add("ReceiptPaymentID", "ReceiptPaymentID");
                dgvPaymentToSupplier.Columns.Add("VoucherNumber", "VoucherNumber");
                dgvPaymentToSupplier.Columns.Add("VoucherTypeCode", "VoucherTypeCode");
                dgvPaymentToSupplier.Columns.Add("VoucherDate", "VoucherDate");
                dgvPaymentToSupplier.Columns.Add("LedgerType", "LedgerType");
                dgvPaymentToSupplier.Columns.Add("LedgerTypeCode", "LedgerTypeCode");
                dgvPaymentToSupplier.Columns.Add("LedgerTypeName", "LedgerTypeName");
                dgvPaymentToSupplier.Columns.Add("PaymentMode", "PaymentMode");
                dgvPaymentToSupplier.Columns.Add("Amount", "Amount");
                dgvPaymentToSupplier.Columns.Add("ChequeNumber", "ChequeNumber");
                dgvPaymentToSupplier.Columns.Add("BankAccountLedgerTypeCode", "BankAccountLedgerTypeCode");
                dgvPaymentToSupplier.Columns.Add("BankAccountLedgerTypeName", "BankAccountLedgerTypeName");
                dgvPaymentToSupplier.Columns.Add("ChequeDate", "ChequeDate");
                dgvPaymentToSupplier.Columns.Add("ChequeClearDate", "ChequeClearDate");
                dgvPaymentToSupplier.Columns.Add("IsChequeCleared", "IsChequeCleared");
                dgvPaymentToSupplier.Columns.Add("POST", "POST");
                dgvPaymentToSupplier.Columns.Add("PISNumber", "PISNumber");
                dgvPaymentToSupplier.Columns.Add("UnadjustedAmount", "UnadjustedAmount");
            }


            dgvPaymentToSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaymentToSupplier.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPaymentToSupplier.AllowUserToAddRows = false;

            for (int i = 0; i < dgvPaymentToSupplier.Columns.Count; i++)
            {
                dgvPaymentToSupplier.Columns[i].Visible = false;
            }

            dgvPaymentToSupplier.Columns["LedgerTypeCode"].Visible = true;
            dgvPaymentToSupplier.Columns["LedgerTypeCode"].HeaderText = "Party Code";
            dgvPaymentToSupplier.Columns["LedgerTypeCode"].DisplayIndex = 0;

            dgvPaymentToSupplier.Columns["LedgerTypeName"].Visible = true;
            dgvPaymentToSupplier.Columns["LedgerTypeName"].HeaderText = "Party Name";
            dgvPaymentToSupplier.Columns["LedgerTypeName"].DisplayIndex = 1;

            dgvPaymentToSupplier.Columns["ChequeNumber"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeNumber"].HeaderText = "Cheque Number";
            dgvPaymentToSupplier.Columns["ChequeNumber"].DisplayIndex = 2;

            dgvPaymentToSupplier.Columns["ChequeDate"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeDate"].HeaderText = "Cheque Date";
            dgvPaymentToSupplier.Columns["ChequeDate"].DisplayIndex = 3;

            dgvPaymentToSupplier.Columns["Amount"].Visible = true;
            dgvPaymentToSupplier.Columns["Amount"].HeaderText = "Amount";
            dgvPaymentToSupplier.Columns["Amount"].DisplayIndex = 4;

            dgvPaymentToSupplier.Columns["UnadjustedAmount"].Visible = true;
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].HeaderText = "Unadjusted Amount";
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].DisplayIndex = 5;

        }

        private void dgvPaymentToSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter && dgvPaymentToSupplier.Rows.Count > 0)
                {
                    string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.SelectedCells[0].ColumnIndex].Name;

                    if (columnName == "LedgerTypeCode")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value)))
                        {
                            frmSupplierLedger formSupplierLedgerMaster = new frmSupplierLedger();
                            formSupplierLedgerMaster.IsInChildMode = true;
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, formSupplierLedgerMaster, ExtensionMethods.MainPanel);
                            formSupplierLedgerMaster.WindowState = FormWindowState.Maximized;

                            formSupplierLedgerMaster.FormClosed += FormSupplierLedgerMaster_FormClosed;
                            formSupplierLedgerMaster.Show();
                        }
                        else
                        {
                            dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["ChequeNumber"];
                        }
                    }
                    else if (columnName == "LedgerTypeName")
                    {
                        dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["ChequeNumber"];
                    }
                    else if (columnName == "ChequeNumber")
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value)))
                        {
                            dgvPaymentToSupplier.CurrentCell.Value = Constants.PaymentMode.CASHTEXT;
                            dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["Amount"];
                        }
                        else
                        {
                            dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["ChequeDate"];
                        }
                    }
                    else if (columnName == "ChequeDate")
                    {
                        dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["Amount"];
                    }
                    else if (columnName == "Amount")
                    {
                        double enteredAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["Amount"].Value)) ?? default(double);
                        if (enteredAmount > 0)
                        {
                            frmReceiptPaymentAdjustment formReceiptPaymentAdjustment = new frmReceiptPaymentAdjustment();
                            TransactionEntity transactionEntity = new TransactionEntity()
                            {
                                ReceiptPaymentID=(long)dgvPaymentToSupplier.CurrentRow.Cells["ReceiptPaymentID"].Value,
                                EntityType = Constants.TransactionEntityType.SupplierLedger,
                                EntityCode = Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["LedgerTypeCode"].Value),
                                EntityName = Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["LedgerTypeName"].Value),
                                EntityTotalAmount = enteredAmount,
                                EntityBalAmount = enteredAmount
                            };

                            formReceiptPaymentAdjustment.ConfigureReceiptPaymentAdjustment(transactionEntity);
                            formReceiptPaymentAdjustment.FormClosed += FormReceiptPaymentAdjustment_FormClosed;
                            formReceiptPaymentAdjustment.Show();
                        }
                    }
                    else if (columnName == "UnadjustedAmount")
                    {
                        dgvPaymentToSupplier.Rows.Add();
                        dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex + 1].Cells["LedgerTypeCode"];
                        dgvPaymentToSupplier.BeginEdit(true);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormReceiptPaymentAdjustment_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransactionEntity currentTransactionEntity =(sender as frmReceiptPaymentAdjustment).CurrentTransactionEntity;

            dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["UnadjustedAmount"];
            dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["UnadjustedAmount"].Value = currentTransactionEntity.EntityBalAmount;

            LoadGridBillAdjusted(currentTransactionEntity);

        }

        private void FormSupplierLedgerMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            SupplierLedgerMaster selectedSupplier = (sender as frmSupplierLedger).LastSelectedSupplier;
            if (selectedSupplier != null)
            {
                ReceiptPaymentItem receiptPaymentForSelectedCust = new ReceiptPaymentItem()
                {
                    VoucherTypeCode=Constants.VoucherTypeCode.PAYMENTTOSUPPLIER,
                    VoucherDate=Convert.ToDateTime(dtReceiptPayment.Text),
                    LedgerType = Constants.TransactionEntityType.SupplierLedger,
                    LedgerTypeCode = selectedSupplier.SupplierLedgerCode,
                    LedgerTypeName = selectedSupplier.SupplierLedgerName,
                    PaymentMode=Constants.PaymentMode.CASH,
                    BankAccountLedgerTypeCode=Convert.ToString(txtTransactAccount.Tag)
                };

                TransactionEntity transactionEntity = new TransactionEntity()
                {
                    EntityType= Constants.TransactionEntityType.SupplierLedger,
                    EntityCode= selectedSupplier.SupplierLedgerCode
                };

                UpdateReceiptPaymentRow(receiptPaymentForSelectedCust);
                LoadGridBillOutstanding(transactionEntity);

                dgvPaymentToSupplier.Focus();
                dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["ChequeNumber"];
            }
        }

        private void LoadGridBillOutstanding(TransactionEntity transactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> allOutstandings= applicationFacade.GetAllBillOutstandingForLedger(transactionEntity);
            dgvSupplierBillOS.DataSource = allOutstandings;
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillOS);

            dgvSupplierBillOS.Columns["InvoiceNumber"].Visible = true;
            dgvSupplierBillOS.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvSupplierBillOS.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvSupplierBillOS.Columns["InvoiceDate"].Visible = true;
            dgvSupplierBillOS.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvSupplierBillOS.Columns["InvoiceDate"].DisplayIndex = 1;

            dgvSupplierBillOS.Columns["BillAmount"].Visible = true;
            dgvSupplierBillOS.Columns["BillAmount"].HeaderText = "Bill Amount";
            dgvSupplierBillOS.Columns["BillAmount"].DisplayIndex = 2;

            dgvSupplierBillOS.Columns["OSAmount"].Visible = true;
            dgvSupplierBillOS.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvSupplierBillOS.Columns["OSAmount"].DisplayIndex = 3;

            //Display totall of outstanding amount
            double totallOutstanding = 0;
            allOutstandings.ForEach(x => totallOutstanding += x.OSAmount);
            lblAmtOSVal.Text =Convert.ToString(totallOutstanding);


        }

        private void LoadGridBillAdjusted(TransactionEntity currentTransactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> allAdjustment= applicationFacade.GetAllBillAdjustmentForLedger(currentTransactionEntity);
            dgvSupplierBillAdjusted.DataSource = allAdjustment;
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillAdjusted);

            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].Visible = true;
            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvSupplierBillAdjusted.Columns["InvoiceDate"].Visible = true;
            dgvSupplierBillAdjusted.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvSupplierBillAdjusted.Columns["InvoiceDate"].DisplayIndex = 1;

            dgvSupplierBillAdjusted.Columns["OSAmount"].Visible = true;
            dgvSupplierBillAdjusted.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvSupplierBillAdjusted.Columns["OSAmount"].DisplayIndex = 2;

            dgvSupplierBillAdjusted.Columns["Amount"].Visible = true;
            dgvSupplierBillAdjusted.Columns["Amount"].HeaderText = "Adjusted Amount";
            dgvSupplierBillAdjusted.Columns["Amount"].DisplayIndex = 3;

            //Display totall of adjusted amount
            double totallAdjusted = 0;
            allAdjustment.ForEach(x => totallAdjusted += x.Amount);
            lblAmtAdjVal.Text = Convert.ToString(totallAdjusted);
        }

        public void GotFocusEventRaised(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    GotFocusEventRaised(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb1 = (TextBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void UpdateReceiptPaymentRow(ReceiptPaymentItem receiptPayment)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvPaymentToSupplier.SelectedCells.Count > 0)
            {
                rowIndex = dgvPaymentToSupplier.SelectedCells[0].RowIndex;
                colIndex = dgvPaymentToSupplier.SelectedCells[0].ColumnIndex;
                receiptPayment.ReceiptPaymentID= applicationFacade.InsertUpdateTempReceiptPayment(receiptPayment);

                dgvPaymentToSupplier.Rows[rowIndex].Cells["ReceiptPaymentID"].Value = receiptPayment.ReceiptPaymentID;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeCode"].Value = receiptPayment.LedgerTypeCode;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeName"].Value = receiptPayment.LedgerTypeName;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["PaymentMode"].Value = receiptPayment.PaymentMode;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeNumber"].Value = receiptPayment.ChequeNumber;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["BankAccountLedgerTypeName"].Value = receiptPayment.BankAccountLedgerTypeName;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeDate"].Value = receiptPayment.ChequeDate;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"].Value = receiptPayment.Amount;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"].Value = receiptPayment.UnadjustedAmount;
            }
        }


        private void EnterKeyDownForTabEvents(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    EnterKeyDownForTabEvents(c);
                }
                else
                {

                    c.KeyDown -= C_KeyDown;
                    c.KeyDown += C_KeyDown;
                }
            }
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    TextBox activeControl = (sender as TextBox);
                   

                    if (activeControl.Name == "txtTransactAccount" && String.IsNullOrWhiteSpace(activeControl.Text))
                    {
                        AccountLedgerType accountLedgerMaster = new AccountLedgerType()
                        {
                           AccountLedgerTypeName =Constants.AccountLedgerTypeText.TransactionBooks
                        };

                        frmAccountLedgerMaster formTransactionBook = new frmAccountLedgerMaster();
                        //Set Child UI
                        ExtensionMethods.AddChildFormToPanel(this, formTransactionBook, ExtensionMethods.MainPanel);
                        formTransactionBook.WindowState = FormWindowState.Maximized;
                        formTransactionBook.FormClosed += FormTransactionBook_FormClosed;
                        formTransactionBook.Show();
                        formTransactionBook.IsInChildMode = true;
                        formTransactionBook.ConfigureAccountLedger(accountLedgerMaster);
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void FormTransactionBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                AccountLedgerMaster lastSelectedTransactionBook = (sender as frmAccountLedgerMaster).LastSelectedAccountLedger;

                if (lastSelectedTransactionBook != null)
                {
                    if (lastSelectedTransactionBook.AccountLedgerID > 0)
                    {
                        txtTransactAccount.Text = lastSelectedTransactionBook.AccountLedgerName;
                        txtTransactAccount.Tag = lastSelectedTransactionBook.AccountLedgerCode;
                        dgvPaymentToSupplier.Focus();
                    }

                    if (dgvPaymentToSupplier.Rows.Count == 0)
                    {
                        dgvPaymentToSupplier.Rows.Add();
                    }

                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[0].Cells["LedgerTypeCode"];
                    dgvPaymentToSupplier.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///Checks for Ammount entered
        ///
        private void dgvCustomerItemDiscount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.CurrentCell.ColumnIndex].Name;
                if (columnName.Equals("Amount"))
                {
                    e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
