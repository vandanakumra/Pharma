using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
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
    public partial class frmPurchaseBookTransaction : Form
    {
        private int invoiceID = 0;
        private bool isInvoiceNumberChanged = false;
        List<PurchaseBookLineItem> lineItemList = new List<PurchaseBookLineItem>();

        IApplicationFacade applicationFacade;
        public frmPurchaseBookTransaction()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmPurchaseBookTransaction_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Purchase Book Transaction");
            dtPurchaseDate.Focus();
            FillCombo();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            dgvLineItem.Columns.Add("SrNo", "SrNo");
            dgvLineItem.Columns["SrNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SrNo"].FillWeight = 5;

            dgvLineItem.Columns.Add("ItemCode", "Item Code");
            dgvLineItem.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemCode"].FillWeight = 10;

            dgvLineItem.Columns.Add("ItemName", "ItemName");
            dgvLineItem.Columns["ItemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemName"].FillWeight = 15;

            dgvLineItem.Columns.Add("BatchNumber", "Batch No");
            dgvLineItem.Columns["BatchNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BatchNumber"].FillWeight = 10;

            dgvLineItem.Columns.Add("Quantity", "Quantity");
            dgvLineItem.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Quantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("FreeQty", "Free Quantity");
            dgvLineItem.Columns["FreeQty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FreeQty"].FillWeight = 5;

            dgvLineItem.Columns.Add("Rate", "Rate");
            dgvLineItem.Columns["Rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Rate"].FillWeight = 5;

            dgvLineItem.Columns.Add("Amount", "Amount");
            dgvLineItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Amount"].FillWeight = 5;

            dgvLineItem.KeyDown += DgvLineItem_KeyDown;

            dgvLineItem.Rows.Clear();
        }

        private void FillCombo()
        {
            
            cbxPurchaseType.DataSource = applicationFacade.GetPurchaseEntryTypes();
            cbxPurchaseType.DisplayMember = "PurchaseTypeName";
            cbxPurchaseType.ValueMember = "ID";
            cbxPurchaseType.SelectedIndexChanged += cbxPurchaseType_SelectedIndexChanged;
            cbxPurchaseType.SelectedIndex = 0;
        }

        private void cbxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int purchaseTypeID = 0;
            Int32.TryParse(Convert.ToString(cbxPurchaseType.SelectedValue), out purchaseTypeID);
            cbxPurchaseFormType.DataSource = applicationFacade.GetPurchaseFormTypes(purchaseTypeID);
            cbxPurchaseFormType.DisplayMember = "FormTypeName";
            cbxPurchaseFormType.ValueMember = "ID";

            PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
            if (type != null && type.PurchaseTypeName.ToLower() == "central")
            {
                cbxPurchaseFormType.Visible = true;
            }
        }

        private void DgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (invoiceID != 0)
                {
                    int srNo = lineItemList.Max(p => p.SrNo);
                    lineItemList.Add(new PurchaseBookLineItem { InvoiceID = invoiceID, SrNo = srNo + 1 });
                   
                    dgvLineItem.Rows.Add(lineItemList);
                }
                else
                {
                    MessageBox.Show("Please add header information first");
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

                    if (columnName == "ItemCode")
                    {

                    }
                }
            }
        }

        private void dtPurchaseDate_Validated(object sender, EventArgs e)
        {
            DateTimePicker dtPicker = (DateTimePicker)sender;
            if (dtPicker.Value.Date > DateTime.Today || dtPicker.Value < DateTime.Today)
            {
                DialogResult result = MessageBox.Show(string.Format("Date is {0} today. Do you want to continue?", dtPicker.Value > DateTime.Today ? "ahead of" : "less than"), "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    dtPicker.Value = DateTime.Now;

            }
        }

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                frmSupplierLedger ledger = new frmSupplierLedger(true);
                ledger.FormClosed += Ledger_FormClosed;
                ledger.ShowDialog();
            }
        }

        private void Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSupplierLedger ledger = (frmSupplierLedger)sender;
            lblSupplierName.Text = ledger.SupplierName;
            txtSupplierCode.Text = ledger.SupplierCode;
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
        }


        private void txtInvoiceNumber_TextChanged(object sender, System.EventArgs e)
        {
            isInvoiceNumberChanged = true;
        }

        private bool GetPurchaseBookHeader(ref PurchaseBookHeader header)
        {
            if(dtPurchaseDate.Value.Date == DateTime.MinValue)
            {
                errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.RequiredField);
                dtPurchaseDate.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text))
            {
                errFrmPurchaseBookHeader.SetError(txtSupplierCode, Constants.Messages.RequiredField);
                txtSupplierCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                errFrmPurchaseBookHeader.SetError(txtInvoiceNumber, Constants.Messages.RequiredField);
                txtInvoiceNumber.Focus();
                return false;
            }
            int purchaseFormTypeID = 0;

            header = new PurchaseBookHeader();
            header.InvoiceID = invoiceID;
            header.PurchaseDate = dtPurchaseDate.Value.Date;
            header.InvoiceNumber = txtInvoiceNumber.Text;
            header.SupplierCode = txtSupplierCode.Text;

            Int32.TryParse(Convert.ToString(cbxPurchaseFormType.SelectedValue), out purchaseFormTypeID);
            header.PurchaseFormTypeID = purchaseFormTypeID;

            return true;
        }

        private void txtInvoiceNumber_Validated(object sender, EventArgs e)
        {
            PurchaseBookHeader header = new PurchaseBookHeader();
            bool result = GetPurchaseBookHeader(ref header);

            if (result && isInvoiceNumberChanged)
            {
                invoiceID = invoiceID == 0 ? applicationFacade.InsertTempPurchaseHeader(header) : applicationFacade.UpdateTempPurchaseHeader(header);
            }

        }
    }
}
