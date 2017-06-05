using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
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

namespace PharmaUI
{
    public partial class frmReceiptFromCustomer : Form
    {
        public frmReceiptFromCustomer()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
        }

        private void frmReceiptFromCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Receipt from customer");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                ///Load all the grid 
                ///
                LoadGridReceiptFromCustomer();

                ///Grid events
                ///
                dgvReceiptFromCust.KeyDown += DgvReceiptFromCust_KeyDown;

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

        private void DgvReceiptFromCust_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    string columnName = dgvReceiptFromCust.Columns[dgvReceiptFromCust.SelectedCells[0].ColumnIndex].Name;

                    if (!string.IsNullOrEmpty(Convert.ToString(dgvReceiptFromCust.CurrentCell.Value)))
                    {
                        e.Handled = true;                       
                    }
                    else
                    {
                        if (columnName == "LedgerTypeCode")
                        {
                            e.SuppressKeyPress = true;
                            frmCustomerLedgerMaster formCustomerLedgerMaster = new frmCustomerLedgerMaster();
                            formCustomerLedgerMaster.IsInChildMode = true;
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, formCustomerLedgerMaster, ExtensionMethods.MainPanel);
                            formCustomerLedgerMaster.WindowState = FormWindowState.Maximized;

                            formCustomerLedgerMaster.FormClosed += FormCustomerLedgerMaster_FormClosed;
                            formCustomerLedgerMaster.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCustomerLedgerMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            CustomerLedgerMaster SelectedCustomerLedger = (sender as frmCustomerLedgerMaster).LastSelectedCustomerLedger;
            if (SelectedCustomerLedger != null)
            {
                ReceiptPaymentItem receiptPaymentForSelectedCust = new ReceiptPaymentItem()
                {
                    LedgerType = Constants.TransactionEntityType.CustomerLedger,
                    LedgerTypeCode= SelectedCustomerLedger.CustomerLedgerCode,
                    LedgerTypeName=SelectedCustomerLedger.CustomerLedgerName
                };

                UpdateReceiptPaymentRow(receiptPaymentForSelectedCust);
                LoadGridBillOutstanding();
                LoadGridBillAdjusted();
            }

        }

        ///Load all the Grid data
        ///
        private void LoadGridReceiptFromCustomer()
        {

            dgvReceiptFromCust.Columns.Add("ReceiptPaymentID", "ReceiptPaymentID");
            dgvReceiptFromCust.Columns.Add("VoucherNumber", "VoucherNumber");
            dgvReceiptFromCust.Columns.Add("VoucherTypeCode", "VoucherTypeCode");
            dgvReceiptFromCust.Columns.Add("VoucherDate", "VoucherDate");
            dgvReceiptFromCust.Columns.Add("LedgerType", "LedgerType");
            dgvReceiptFromCust.Columns.Add("LedgerTypeCode", "LedgerTypeCode");
            dgvReceiptFromCust.Columns.Add("LedgerTypeName", "LedgerTypeName");
            dgvReceiptFromCust.Columns.Add("PaymentMode", "PaymentMode");
            dgvReceiptFromCust.Columns.Add("Amount", "Amount");
            dgvReceiptFromCust.Columns.Add("ChequeNumber", "ChequeNumber");
            dgvReceiptFromCust.Columns.Add("BankAccountLedgerTypeCode", "BankAccountLedgerTypeCode");
            dgvReceiptFromCust.Columns.Add("BankAccountLedgerTypeName", "BankAccountLedgerTypeName");
            dgvReceiptFromCust.Columns.Add("ChequeDate", "ChequeDate");
            dgvReceiptFromCust.Columns.Add("ChequeClearDate", "ChequeClearDate");
            dgvReceiptFromCust.Columns.Add("IsChequeCleared", "IsChequeCleared");
            dgvReceiptFromCust.Columns.Add("POST", "POST");
            dgvReceiptFromCust.Columns.Add("PISNumber", "PISNumber");
            dgvReceiptFromCust.Columns.Add("UnadjustedAmount", "UnadjustedAmount");

            dgvReceiptFromCust.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptFromCust.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReceiptFromCust.AllowUserToAddRows = false;

            for (int i = 0; i < dgvReceiptFromCust.Columns.Count; i++)
            {
                dgvReceiptFromCust.Columns[i].Visible = false;
            }

            dgvReceiptFromCust.Columns["LedgerTypeCode"].Visible = true;
            dgvReceiptFromCust.Columns["LedgerTypeCode"].HeaderText = "Party Code";

            dgvReceiptFromCust.Columns["LedgerTypeName"].Visible = true;
            dgvReceiptFromCust.Columns["LedgerTypeName"].HeaderText = "Party Name";

            dgvReceiptFromCust.Columns["PaymentMode"].Visible = true;
            dgvReceiptFromCust.Columns["PaymentMode"].HeaderText = "Payment Mode";

            dgvReceiptFromCust.Columns["ChequeNumber"].Visible = true;
            dgvReceiptFromCust.Columns["ChequeNumber"].HeaderText = "Cheque Number";

            dgvReceiptFromCust.Columns["BankAccountLedgerTypeName"].Visible = true;
            dgvReceiptFromCust.Columns["BankAccountLedgerTypeName"].HeaderText = "Bank Name";

            dgvReceiptFromCust.Columns["ChequeDate"].Visible = true;
            dgvReceiptFromCust.Columns["ChequeDate"].HeaderText = "Cheque Date";

            dgvReceiptFromCust.Columns["Amount"].Visible = true;
            dgvReceiptFromCust.Columns["Amount"].HeaderText = "Amount";

            dgvReceiptFromCust.Columns["UnadjustedAmount"].Visible = true;
            dgvReceiptFromCust.Columns["UnadjustedAmount"].HeaderText = "Unadjusted Amount";
        }

        private void LoadGridBillOutstanding()
        {
           
            dgvCustBillOS.DataSource = new List<BillOutstanding>();
            ExtensionMethods.SetGridDefaultProperty(dgvCustBillOS);

            dgvCustBillOS.Columns["VoucherNumber"].Visible = true;
            dgvCustBillOS.Columns["VoucherNumber"].HeaderText = "Bill Number";

            dgvCustBillOS.Columns["VoucherDate"].Visible = true;
            dgvCustBillOS.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvCustBillOS.Columns["OSAmount"].Visible = true;
            dgvCustBillOS.Columns["OSAmount"].HeaderText = "Outstanding Amount";

        }

        private void LoadGridBillAdjusted()
        {
           
            dgvCustBillAdjusted.DataSource = new List<BillAdjusted>();
            ExtensionMethods.SetGridDefaultProperty(dgvCustBillAdjusted);

            dgvCustBillAdjusted.Columns["VoucherNumber"].Visible = true;
            dgvCustBillAdjusted.Columns["VoucherNumber"].HeaderText = "Bill Number";

            dgvCustBillAdjusted.Columns["VoucherDate"].Visible = true;
            dgvCustBillAdjusted.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvCustBillAdjusted.Columns["Amount"].Visible = true;
            dgvCustBillAdjusted.Columns["Amount"].HeaderText = "Adjusted Amount";
        }


        //Set focus for the controls

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

        private void dtReceiptPayment_Validated(object sender, EventArgs e)
        {
            try
            {
                if(dgvReceiptFromCust.Rows.Count == 0)
                {
                    dgvReceiptFromCust.Rows.Add();
                }

                dgvReceiptFromCust.CurrentCell = dgvReceiptFromCust.Rows[0].Cells["LedgerTypeCode"];
                dgvReceiptFromCust.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtReceiptPayment_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime Test;
                if (!DateTime.TryParseExact(dtReceiptPayment.Text, "dd/mm/yyyy", null, DateTimeStyles.None, out Test))
                {
                    dtReceiptPayment.Focus();
                    errorProviderReceiptPayment.SetError(dtReceiptPayment, "Please enter correct date");
                }
                else
                {
                    errorProviderReceiptPayment.SetError(dtReceiptPayment, String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }


        private void UpdateReceiptPaymentRow(ReceiptPaymentItem receiptPayment)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvReceiptFromCust.SelectedCells.Count > 0)
            {
                rowIndex = dgvReceiptFromCust.SelectedCells[0].RowIndex;
                colIndex = dgvReceiptFromCust.SelectedCells[0].ColumnIndex;

                dgvReceiptFromCust.Rows[rowIndex].Cells["LedgerTypeCode"].Value = receiptPayment.LedgerTypeCode;
                dgvReceiptFromCust.Rows[rowIndex].Cells["LedgerTypeName"].Value = receiptPayment.LedgerTypeName;
                dgvReceiptFromCust.Rows[rowIndex].Cells["PaymentMode"].Value = receiptPayment.PaymentMode;
                dgvReceiptFromCust.Rows[rowIndex].Cells["ChequeNumber"].Value = receiptPayment.ChequeNumber;
                dgvReceiptFromCust.Rows[rowIndex].Cells["BankAccountLedgerTypeName"].Value = receiptPayment.BankAccountLedgerTypeName;
                dgvReceiptFromCust.Rows[rowIndex].Cells["ChequeDate"].Value = receiptPayment.ChequeDate;
                dgvReceiptFromCust.Rows[rowIndex].Cells["Amount"].Value = receiptPayment.Amount;
                dgvReceiptFromCust.Rows[rowIndex].Cells["UnadjustedAmount"].Value = receiptPayment.UnadjustedAmount;
            }
        }
    }
}
