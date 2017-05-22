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

            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
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
            PurchaseBookLineItem lineItem = (PurchaseBookLineItem)dgvLineItem.CurrentRow.DataBoundItem;

            if (isCellEdit && !isBatchUpdate && lineItem.ID > 0)
            {
                applicationFacade.UpdateTempPurchaseLineItem(lineItem);
            }

            string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

            if (columnName == "FreeQty")
            {
                frmPurchaseBookLineItemUpdate updateForm = new frmPurchaseBookLineItemUpdate(lineItem, Enums.LineItemUpdateMode.Scheme);
                updateForm.FormClosed += frmPurchaseBookLineItemUpdate_FormClosed;
                updateForm.ShowDialog();
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
                            if(invoiceID > 0 && isDirty)
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

                    dgvLineItem.Rows[rowIndex].Cells["ID"].Value = lineItemID;
                    dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItem.ItemCode;
                    dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItem.ItemName;
                    dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItem.Quantity;
                    dgvLineItem.Rows[rowIndex].Cells["FreeQty"].Value = lineItem.FreeQty;
                    dgvLineItem.Rows[rowIndex].Cells["InvoiceID"].Value = lineItem.InvoiceID;
                    dgvLineItem.Rows[rowIndex].Cells["BatchNumber"].Value = lineItem.BatchNumber;
                    dgvLineItem.Rows[rowIndex].Cells["Rate"].Value = lineItem.Rate;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = lineItem.Amount;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                    dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                    dgvLineItem.Rows[rowIndex].Cells["Excise"].Value = lineItem.Excise;
                    dgvLineItem.Rows[rowIndex].Cells["Expiry"].Value = lineItem.Expiry;

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


        private void frmPurchaseBookLineItemUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
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
