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
                LoadGridBillOutstanding();
                LoadGridBillAdjusted();


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

        ///Load all the Grid data
        ///
        private void LoadGridReceiptFromCustomer()
        {
           
            dgvReceiptFromCust.DataSource = new List<ReceiptPayment>();
            ExtensionMethods.SetGridDefaultProperty(dgvReceiptFromCust);

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

        private void dtReceiptPayment_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dtReceiptPayment_Validated(object sender, EventArgs e)
        {

        }
    }
}
