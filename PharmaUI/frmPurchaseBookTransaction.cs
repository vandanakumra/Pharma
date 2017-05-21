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

        private void Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSupplierLedger ledger = (frmSupplierLedger)sender;
            if (ledger.LastSelectedSupplier != null)
            {
                lblSupplierName.Text = ledger.LastSelectedSupplier.SupplierLedgerName;
                txtSupplierCode.Text = ledger.LastSelectedSupplier.SupplierLedgerCode;
            }
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
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
            else if (keyData == (Keys.F3))
            {
                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    dgvLineItem.BeginEdit(true);
                }
            }
            else if (keyData == Keys.F1)
            {
                switch (this.ActiveControl.Name)
                {
                    case "txtSupplierCode":
                        {
                            frmSupplierLedger ledger = new frmSupplierLedger();
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, ledger, ExtensionMethods.MainPanel);
                            ledger.WindowState = FormWindowState.Maximized;

                            ledger.FormClosed += Ledger_FormClosed;
                            ledger.Show();
                        }
                        break;
                    case "dgvLineItem":
                        {
                            if (dgvLineItem.SelectedCells.Count > 0)
                            {
                                if(dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name == "ItemCode")
                                {
                                    frmItemMaster itemMaster = new frmItemMaster();
                                    //Set Child UI
                                    ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                                    itemMaster.WindowState = FormWindowState.Maximized;

                                    itemMaster.FormClosed += ItemMaster_FormClosed; ;
                                    itemMaster.Show();
                                }
                            }
                        }
                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmItemMaster itemMaster = (frmItemMaster)sender;
            if (itemMaster.LastSelectedItemMaster != null && dgvLineItem.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;

                dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = itemMaster.LastSelectedItemMaster.ItemCode;
                dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = itemMaster.LastSelectedItemMaster.ItemName;
                dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = itemMaster.LastSelectedItemMaster.QtyPerCase;
                dgvLineItem.Rows[rowIndex].Cells["FreeQty"].Value = "0";
                dgvLineItem.Rows[rowIndex].Cells["Rate"].Value = itemMaster.LastSelectedItemMaster.PurchaseRate;
            }
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
        }

        private void frmPurchaseBookTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
