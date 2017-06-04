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

namespace PharmaUI.ReceiptPayment
{
    public partial class frmPaymentToSupplier : Form
    {
        public frmPaymentToSupplier()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
        }

        private void frmPaymentToSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Payment To Supplier");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                ///Load all the grid 
                ///
                LoadGridPaymentToSupplier();

                ///Grid events
                ///
                dgvPaymentToSupplier.KeyDown += dgvPaymentToSupplier_KeyDown;

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

            dgvPaymentToSupplier.Columns["LedgerTypeName"].Visible = true;
            dgvPaymentToSupplier.Columns["LedgerTypeName"].HeaderText = "Party Name";

            dgvPaymentToSupplier.Columns["PaymentMode"].Visible = true;
            dgvPaymentToSupplier.Columns["PaymentMode"].HeaderText = "Payment Mode";

            dgvPaymentToSupplier.Columns["ChequeNumber"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeNumber"].HeaderText = "Cheque Number";

            dgvPaymentToSupplier.Columns["BankAccountLedgerTypeName"].Visible = true;
            dgvPaymentToSupplier.Columns["BankAccountLedgerTypeName"].HeaderText = "Bank Name";

            dgvPaymentToSupplier.Columns["ChequeDate"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeDate"].HeaderText = "Cheque Date";

            dgvPaymentToSupplier.Columns["Amount"].Visible = true;
            dgvPaymentToSupplier.Columns["Amount"].HeaderText = "Amount";

            dgvPaymentToSupplier.Columns["UnadjustedAmount"].Visible = true;
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].HeaderText = "Unadjusted Amount";

        }

        private void dgvPaymentToSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.SelectedCells[0].ColumnIndex].Name;

                    if (!string.IsNullOrEmpty(Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value)))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if (columnName == "LedgerTypeCode")
                        {
                            e.SuppressKeyPress = true;
                            frmSupplierLedger formSupplierLedgerMaster = new frmSupplierLedger();
                          //  formSupplierLedgerMaster.IsInChildMode = true;
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, formSupplierLedgerMaster, ExtensionMethods.MainPanel);
                            formSupplierLedgerMaster.WindowState = FormWindowState.Maximized;

                            formSupplierLedgerMaster.FormClosed += FormSupplierLedgerMaster_FormClosed;
                            formSupplierLedgerMaster.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormSupplierLedgerMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            SupplierLedgerMaster selectedSupplier = (sender as frmSupplierLedger).LastSelectedSupplier;
            if (selectedSupplier != null)
            {
                ReceiptPaymentItem receiptPaymentForSelectedCust = new ReceiptPaymentItem()
                {
                    LedgerType = Constants.TransactionLedgerType.SupplierLedger,
                    LedgerTypeCode = selectedSupplier.SupplierLedgerCode,
                    LedgerTypeName = selectedSupplier.SupplierLedgerName
                };

                UpdateReceiptPaymentRow(receiptPaymentForSelectedCust);
                LoadGridBillOutstanding();
                LoadGridBillAdjusted();
            }
        }

        private void LoadGridBillOutstanding()
        {

            dgvSupplierBillOS.DataSource = new List<BillOutstanding>();
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillOS);

            dgvSupplierBillOS.Columns["VoucherNumber"].Visible = true;
            dgvSupplierBillOS.Columns["VoucherNumber"].HeaderText = "Bill Number";

            dgvSupplierBillOS.Columns["VoucherDate"].Visible = true;
            dgvSupplierBillOS.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvSupplierBillOS.Columns["OSAmount"].Visible = true;
            dgvSupplierBillOS.Columns["OSAmount"].HeaderText = "Outstanding Amount";

        }

        private void LoadGridBillAdjusted()
        {

            dgvSupplierBillAdjusted.DataSource = new List<BillAdjusted>();
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillAdjusted);

            dgvSupplierBillAdjusted.Columns["VoucherNumber"].Visible = true;
            dgvSupplierBillAdjusted.Columns["VoucherNumber"].HeaderText = "Bill Number";

            dgvSupplierBillAdjusted.Columns["VoucherDate"].Visible = true;
            dgvSupplierBillAdjusted.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvSupplierBillAdjusted.Columns["Amount"].Visible = true;
            dgvSupplierBillAdjusted.Columns["Amount"].HeaderText = "Adjusted Amount";
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
    }
}
