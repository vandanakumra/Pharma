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
        private bool isBatchUpdate = false;
        private bool isDirty = false;
        private bool isCellEdit = true;
        double oldRate = 0L;

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
            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);
            FillCombo();
            InitializeGrid();
            dtPurchaseDate.Focus();
        }

        private void InitializeGrid()
        {
            dgvLineItem.Columns.Add("ID", "ID");
            dgvLineItem.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ID"].Visible = false;

            dgvLineItem.Columns.Add("SrNo", "SrNo");
            dgvLineItem.Columns["SrNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SrNo"].FillWeight = 5;
            dgvLineItem.Columns["SrNo"].ReadOnly = true;

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

            dgvLineItem.Columns.Add("InvoiceID", "InvoiceID");
            dgvLineItem.Columns["InvoiceID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["InvoiceID"].Visible = false;

            dgvLineItem.Columns.Add("Scheme1", "Scheme1");
            dgvLineItem.Columns["Scheme1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Scheme1"].Visible = false;

            dgvLineItem.Columns.Add("Scheme2", "Scheme2");
            dgvLineItem.Columns["Scheme2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Scheme2"].Visible = false;

            dgvLineItem.Columns.Add("IsHalfScheme", "IsHalfScheme");
            dgvLineItem.Columns["IsHalfScheme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["IsHalfScheme"].Visible = false;

            dgvLineItem.Columns.Add("Discount", "Discount");
            dgvLineItem.Columns["Discount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Discount"].Visible = false;

            dgvLineItem.Columns.Add("SpecialDiscount", "SpecialDiscount");
            dgvLineItem.Columns["SpecialDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialDiscount"].Visible = false;

            dgvLineItem.Columns.Add("VolumeDiscount", "VolumeDiscount");
            dgvLineItem.Columns["VolumeDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscount"].Visible = false;

            dgvLineItem.Columns.Add("MRP", "MRP");
            dgvLineItem.Columns["MRP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["MRP"].Visible = false;

            dgvLineItem.Columns.Add("Excise", "Excise");
            dgvLineItem.Columns["Excise"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Excise"].Visible = false;

            dgvLineItem.Columns.Add("Expiry", "Expiry");
            dgvLineItem.Columns["Expiry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Expiry"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseDate", "PurchaseDate");
            dgvLineItem.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseDate"].Visible = false;

            dgvLineItem.Columns.Add("IsNewRate", "IsNewRate");
            dgvLineItem.Columns["IsNewRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["IsNewRate"].Visible = false;

            dgvLineItem.Columns.Add("SaleRate", "SaleRate");
            dgvLineItem.Columns["SaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleRate"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseTaxType", "PurchaseTaxType");
            dgvLineItem.Columns["PurchaseTaxType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseTaxType"].Visible = false;

            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
            dgvLineItem.CellLeave += DgvLineItem_CellLeave;
            dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged;
        }

        private void DgvLineItem_SelectionChanged(object sender, EventArgs e)
        {
            isCellEdit = false;
            if (dgvLineItem.SelectedCells.Count > 0)
            {
                string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;
                if (columnName == "Rate")
                {
                    double.TryParse(Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells[dgvLineItem.SelectedCells[0].ColumnIndex].Value), out oldRate);
                }
            }
        }

        private void DgvLineItem_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvLineItem.Columns[e.ColumnIndex].Name;
            string itemCode = Convert.ToString(dgvLineItem.CurrentRow.Cells["ItemCode"].Value);
            if (columnName == "Rate" && !isCellEdit)
            {
                double newRate = 0L;
                double.TryParse(Convert.ToString(dgvLineItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), out newRate);
                PurchaseBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.Rows[e.RowIndex]);

                if (oldRate != newRate)
                {
                    frmLineItemDiscount updateForm = new frmLineItemDiscount(lineItem);
                    updateForm.FormClosed += frmLineItemDiscount_FormClosed;
                    updateForm.ShowDialog();
                }
                else
                {
                    if (!string.IsNullOrEmpty(itemCode))
                    {
                        frmLineItemBriefDiscount updateForm = new frmLineItemBriefDiscount(lineItem);
                        updateForm.FormClosed += frmLineItemBriefDiscount_FormClosed;
                        updateForm.ShowDialog();
                    }
                }

            }
            
        }

        private void DgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isBatchUpdate)
            {
                isCellEdit = true;
            }
        }

        private void DgvLineItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
            PurchaseBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
            string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

            if (isCellEdit && !isBatchUpdate && lineItem.ID > 0)
                {
                if (columnName == "Quantity" || columnName == "Rate")
                {
                    double amount = GetLineItemAmount(lineItem);
                    dgvLineItem.CurrentRow.Cells["Amount"].Value = amount;
                    lineItem.Amount = amount;
                }
                applicationFacade.UpdateTempPurchaseLineItem(lineItem);
            }

            if (columnName == "FreeQty")
            {
                PharmaUI.Purchase_Entry.frmLineItemScheme updateForm = new PharmaUI.Purchase_Entry.frmLineItemScheme(lineItem);
                updateForm.FormClosed += frmLineItemScheme_FormClosed;
                updateForm.ShowDialog();
            }

            if (columnName == "Rate")
            {
                if (oldRate != lineItem.Rate)
                {
                    frmLineItemDiscount updateForm = new frmLineItemDiscount(lineItem);
                    updateForm.FormClosed += frmLineItemDiscount_FormClosed;
                    updateForm.ShowDialog();
                }
                else
                {
                    frmLineItemBriefDiscount updateForm = new frmLineItemBriefDiscount(lineItem);
                    updateForm.FormClosed += frmLineItemBriefDiscount_FormClosed;
                    updateForm.ShowDialog();
                }
            }
        }

        private void DgvLineItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isCellEdit = false;

            if (invoiceID == 0)
            {
                MessageBox.Show("Please enter invoice number before adding the items");
                dgvLineItem.CancelEdit();
            }

            string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

            //oldRate = 0L;

            //if (columnName == "Rate")
            //{
            //    Double.TryParse(Convert.ToString(dgvLineItem.SelectedCells[0].Value), out oldRate);
            //}
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


        private void cbxPurchaseFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invoiceID > 0)
            {
                PurchaseBookHeader header = new PurchaseBookHeader();
                bool result = GetPurchaseBookHeader(ref header);

                if (result)
                {
                    applicationFacade.UpdateTempPurchaseHeader(header);
                }
            }
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
                        tb1.TextChanged += Tb1_TextChanged;
                        tb1.Leave += Tb1_Leave;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                    else if (c is DateTimePicker)
                    {
                        DateTimePicker tb1 = (DateTimePicker)c;
                        tb1.GotFocus += C_GotFocus;
                        tb1.ValueChanged += Tb1_TextChanged;
                        tb1.LostFocus += Tb1_Leave;

                    }
                }
            }
        }

        private void Tb1_Leave(object sender, EventArgs e)
        {
            if (isDirty)
            {
                Control text = (Control)sender;

                switch (text.Name)
                {
                    case "txtInvoiceNumber":
                        {
                            PurchaseBookHeader header = new PurchaseBookHeader();
                            bool result = GetPurchaseBookHeader(ref header);

                            if (result && isDirty)
                            {
                                invoiceID = invoiceID == 0 ? applicationFacade.InsertTempPurchaseHeader(header) : applicationFacade.UpdateTempPurchaseHeader(header);
                            }
                        }

                        break;
                    case "txtSupplierCode":
                        {
                            if (invoiceID > 0 && isDirty)
                            {
                                PurchaseBookHeader header = new PurchaseBookHeader();
                                bool result = GetPurchaseBookHeader(ref header);

                                if (result)
                                {
                                    applicationFacade.UpdateTempPurchaseHeader(header);
                                }
                            }
                        }

                        break;
                    case "dtPurchaseDate":
                        {
                            DateTimePicker dtPicker = (DateTimePicker)sender;
                            if (string.IsNullOrWhiteSpace(dtPicker.Text))
                            {
                                errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.RequiredField);
                                dtPurchaseDate.Focus();
                            }
                            else if (dtPicker.Value.Date > DateTime.Today || dtPicker.Value < DateTime.Today)
                            {
                                DialogResult result = MessageBox.Show(string.Format("Date is {0} today.", dtPicker.Value > DateTime.Today ? "ahead of" : "less than"));

                                if (result == DialogResult.No)
                                    dtPicker.Value = DateTime.Now;

                            }
                        }
                        break;
                }

                isDirty = false;
            }
        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
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
            txtSupplierCode.Focus();
        }

        private bool GetPurchaseBookHeader(ref PurchaseBookHeader header)
        {
            if (dtPurchaseDate.Value.Date == DateTime.MinValue)
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

                        }
                        break;

                }
            }
            else if (keyData == Keys.End)
            {
                if (invoiceID > 0 && dgvLineItem.Rows.Count > 0)
                {
                    PurchaseBookHeader header = new PurchaseBookHeader();
                    GetPurchaseBookHeader(ref header);
                    frmPurchaseHeaderAmount amount = new frmPurchaseHeaderAmount(header);
                    amount.ShowDialog();
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmLineItemScheme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Purchase_Entry.frmLineItemScheme lineItemScheme = (Purchase_Entry.frmLineItemScheme)sender;
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                if (lineItemScheme.PurchaseBookLinetem != null)
                {
                    isBatchUpdate = true;
                    int lineItemID = 0;
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ID"].Value), out lineItemID);

                    PurchaseBookLineItem lineItem = lineItemScheme.PurchaseBookLinetem;
                    lineItem.ID = lineItemID == 0 ? applicationFacade.InsertTempPurchaseLineItem(lineItem) : applicationFacade.UpdateTempPurchaseLineItem(lineItem);
                    
                    dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                    dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                    
                }
                isBatchUpdate = false;
            }

            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmItemMaster itemMaster = (frmItemMaster)sender;
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                if (itemMaster.LastSelectedItemMaster != null)
                {
                    isBatchUpdate = true;
                    int lineItemID = 0;
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ID"].Value), out lineItemID);

                    PurchaseBookLineItem lineItem = itemMaster.LastSelectedItemMaster.ToPurchaseBookLineItem();
                    lineItem.InvoiceID = invoiceID;
                    lineItem.ID = lineItemID == 0 ? applicationFacade.InsertTempPurchaseLineItem(lineItem) : applicationFacade.UpdateTempPurchaseLineItem(lineItem);

                    int srno = dgvLineItem.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["SrNo"].Value));

                    dgvLineItem.Rows[rowIndex].Cells["ID"].Value = lineItem.ID;
                    dgvLineItem.Rows[rowIndex].Cells["SrNo"].Value = srno + 1;
                    dgvLineItem.Rows[rowIndex].Cells["InvoiceID"].Value = invoiceID;
                    dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItem.ItemCode;
                    dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItem.ItemName;
                    dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = "0";
                    dgvLineItem.Rows[rowIndex].Cells["FreeQty"].Value = "0";
                    dgvLineItem.Rows[rowIndex].Cells["InvoiceID"].Value = lineItem.InvoiceID;
                    dgvLineItem.Rows[rowIndex].Cells["BatchNumber"].Value = lineItem.BatchNumber;
                    dgvLineItem.Rows[rowIndex].Cells["Rate"].Value = lineItem.Rate;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount(lineItem);
                    dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                    dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                    dgvLineItem.Rows[rowIndex].Cells["Excise"].Value = lineItem.Excise;
                    dgvLineItem.Rows[rowIndex].Cells["Expiry"].Value = lineItem.Expiry;
                    dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItem.SaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItem.SpecialRate;
                    dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItem.WholeSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseDate"].Value = dtPurchaseDate.Value;
                }
                isBatchUpdate = false;
            }

            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            if (rowIndex != -1 && colIndex != -1)
            {
                dgvLineItem.BeginEdit(false);
                dgvLineItem.Rows[rowIndex].Cells[colIndex].Selected = true;
            }

        }

        private void frmLineItemBriefDiscount_FormClosed (object sender, FormClosedEventArgs e)
        {
            frmLineItemBriefDiscount lineItemUpdate = (frmLineItemBriefDiscount)sender;
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                if (lineItemUpdate.PurchaseBookLinetem != null)
                {
                    isBatchUpdate = true;
                    int lineItemID = 0;
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ID"].Value), out lineItemID);

                    PurchaseBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;
                    lineItem.ID = lineItemID == 0 ? applicationFacade.InsertTempPurchaseLineItem(lineItem) : applicationFacade.UpdateTempPurchaseLineItem(lineItem);

                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                    dgvLineItem.Rows[rowIndex].Cells["Excise"].Value = lineItem.Excise;
                    dgvLineItem.Rows[rowIndex].Cells["Expiry"].Value = lineItem.Expiry;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount(lineItem);
                }
                isBatchUpdate = false;
            }

            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            dgvLineItem.Rows[rowIndex].Cells["Amount"].Selected = true;
            
        }

        private void frmLineItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLineItemDiscount lineItemUpdate = (frmLineItemDiscount)sender;
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                if (lineItemUpdate.PurchaseBookLinetem != null)
                {
                    isBatchUpdate = true;
                    int lineItemID = 0;
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ID"].Value), out lineItemID);

                    PurchaseBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;
                    lineItem.ID = lineItemID == 0 ? applicationFacade.InsertTempPurchaseLineItem(lineItem) : applicationFacade.UpdateTempPurchaseLineItem(lineItem);

                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                    dgvLineItem.Rows[rowIndex].Cells["Excise"].Value = lineItem.Excise;
                    dgvLineItem.Rows[rowIndex].Cells["Expiry"].Value = lineItem.Expiry;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount(lineItem);
                    dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItem.WholeSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItem.SaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItem.SpecialRate;
                    dgvLineItem.Rows[rowIndex].Cells["IsNewRate"].Value = lineItem.IsNewRate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseDate"].Value = lineItem.PurchaseDate;

                }
                isBatchUpdate = false;
            }

            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            dgvLineItem.Rows[rowIndex].Cells["Amount"].Selected = true;
        }


        private void frmPurchaseBookTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private PurchaseBookLineItem ConvertToPurchaseBookLineItem(DataGridViewRow row)
        {
            PurchaseBookLineItem item = new PurchaseBookLineItem();
            int id = 0;
            double dValue = 0L;

            if (row != null)
            {
                Int32.TryParse(Convert.ToString(row.Cells["ID"].Value), out id);
                item.ID = id;

                Int32.TryParse(Convert.ToString(row.Cells["InvoiceID"].Value), out id);
                item.InvoiceID = id;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.BatchNumber = Convert.ToString(row.Cells["BatchNumber"].Value);

                Int32.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out id);
                item.Quantity = id;

                Int32.TryParse(Convert.ToString(row.Cells["FreeQty"].Value), out id);
                item.FreeQty = id;

                double.TryParse(Convert.ToString(row.Cells["Rate"].Value), out dValue);
                item.Rate = dValue;

                double.TryParse(Convert.ToString(row.Cells["Amount"].Value), out dValue);
                item.Amount = dValue;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme1"].Value), out id);
                item.Scheme1 = id;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme2"].Value), out id);
                item.Scheme2 = id;

                item.IsHalfScheme = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value);

                double.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                double.TryParse(Convert.ToString(row.Cells["SpecialDiscount"].Value), out dValue);
                item.SpecialDiscount = dValue;

                double.TryParse(Convert.ToString(row.Cells["VolumeDiscount"].Value), out dValue);
                item.VolumeDiscount = dValue;

                double.TryParse(Convert.ToString(row.Cells["MRP"].Value), out dValue);
                item.MRP = dValue;

                double.TryParse(Convert.ToString(row.Cells["Excise"].Value), out dValue);
                item.Excise = dValue;

                DateTime date = DateTime.MinValue;
                DateTime.TryParse(Convert.ToString(row.Cells["Expiry"].Value), out date);
                item.Expiry = date;

                double.TryParse(Convert.ToString(row.Cells["WholeSaleRate"].Value), out dValue);
                item.WholeSaleRate = dValue;

                double.TryParse(Convert.ToString(row.Cells["SpecialRate"].Value), out dValue);
                item.SpecialRate = dValue;

                double.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;

                item.IsNewRate = oldRate == item.Rate;
                item.PurchaseDate = dtPurchaseDate.Value;
                item.PurchaseTaxType = Convert.ToString(row.Cells["PurchaseTaxType"].Value);

            }

            return item;
        }

        private double GetLineItemAmount(PurchaseBookLineItem item)
        {
            double? amount = 0L;
            amount = item.Quantity * item.Rate;
            return amount ?? 0;
        }

        private void dgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "ItemCode")
                {
                    frmItemMaster itemMaster = new frmItemMaster();
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                    itemMaster.WindowState = FormWindowState.Maximized;

                    itemMaster.FormClosed += ItemMaster_FormClosed; ;
                    itemMaster.Show();
                }
                else if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "BatchNumber")
                {
                     frmLastNBatchNo form = new frmLastNBatchNo();
                    //Set Child UI
                  
                    form.ShowDialog();
                }

            }
        }
    }
}
