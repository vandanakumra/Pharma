using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
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
    public partial class frmPurchaseBookTransaction : Form
    {
        private long purchaseSaleBookHeaderID = 0;
        private bool isBatchUpdate = false;
        private bool isDirty = false;
        private bool isCellEdit = true;
      
        IApplicationFacade applicationFacade;
        public frmPurchaseBookTransaction()
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPurchaseBookTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Purchase Book Transaction");
                ExtensionMethods.AddFooter(this);
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);
                FillCombo();
                InitializeGrid();
                dtPurchaseDate.Focus();
                string format = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                format = format.IndexOf("MM") < 0 ? format.Replace("M", "MM") : format;
                format = format.IndexOf("dd") < 0 ? format.Replace("d", "dd") : format;
                //format = format.IndexOf("yyyy") < 0 ? format.Replace("d", "dd") : format;
                dtPurchaseDate.Text = DateTime.Now.ToString(format);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeGrid()
        {
            dgvLineItem.Columns.Add("PurchaseSaleBookLineItemID", "PurchaseSaleBookLineItemID");
            dgvLineItem.Columns["PurchaseSaleBookLineItemID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleBookLineItemID"].Visible = false;

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

            dgvLineItem.Columns.Add("Batch", "Batch No");
            dgvLineItem.Columns["Batch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Batch"].FillWeight = 10;

            dgvLineItem.Columns.Add("Quantity", "Quantity");
            dgvLineItem.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Quantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("FreeQuantity", "Free Quantity");
            dgvLineItem.Columns["FreeQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FreeQuantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("PurchaseSaleRate", "Rate");
            dgvLineItem.Columns["PurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleRate"].FillWeight = 5;

            dgvLineItem.Columns.Add("Amount", "Amount");
            dgvLineItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Amount"].FillWeight = 5;


            dgvLineItem.Columns.Add("OldPurchaseSaleRate", "OldPurchaseSaleRate");
            dgvLineItem.Columns["OldPurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["OldPurchaseSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleBookHeaderID", "PurchaseSaleBookHeaderID");
            dgvLineItem.Columns["PurchaseSaleBookHeaderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleBookHeaderID"].Visible = false;

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

            dgvLineItem.Columns.Add("ExpiryDate", "ExpiryDate");
            dgvLineItem.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ExpiryDate"].Visible = false;

            dgvLineItem.Columns.Add("SaleRate", "SaleRate");
            dgvLineItem.Columns["SaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleRate"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTypeCode", "PurchaseSaleTypeCode");
            dgvLineItem.Columns["PurchaseSaleTypeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTypeCode"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTax", "PurchaseSaleTax");
            dgvLineItem.Columns["PurchaseSaleTax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTax"].Visible = false;

            dgvLineItem.Columns.Add("LocalCentral", "LocalCentral");
            dgvLineItem.Columns["LocalCentral"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["LocalCentral"].Visible = false;


            dgvLineItem.Columns.Add("ConversionRate", "ConversionRate");
            dgvLineItem.Columns["ConversionRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ConversionRate"].Visible = false;

            dgvLineItem.Columns.Add("TotalDiscountAmount", "TotalDiscountAmount");
            dgvLineItem.Columns["TotalDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["TotalDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("SurchargeAmount", "SurchargeAmount");
            dgvLineItem.Columns["SurchargeAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SurchargeAmount"].Visible = false;

            dgvLineItem.Columns.Add("SchemeAmount", "SchemeAmount");
            dgvLineItem.Columns["SchemeAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SchemeAmount"].Visible = false;

            dgvLineItem.Columns.Add("TaxAmount", "TaxAmount");
            dgvLineItem.Columns["TaxAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["TaxAmount"].Visible = false;

            dgvLineItem.Columns.Add("GrossAmount", "GrossAmount");
            dgvLineItem.Columns["GrossAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["GrossAmount"].Visible = false;

            dgvLineItem.Columns.Add("VolumeDiscountAmount", "VolumeDiscountAmount");
            dgvLineItem.Columns["VolumeDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("SpecialDiscountAmount", "SpecialDiscountAmount");
            dgvLineItem.Columns["SpecialDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("DiscountAmount", "DiscountAmount");
            dgvLineItem.Columns["DiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["DiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("CostAmount", "CostAmount");
            dgvLineItem.Columns["CostAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CostAmount"].Visible = false;           

            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;            
            dgvLineItem.EditingControlShowing += DgvLineItem_EditingControlShowing;
            dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged;
        }

        private void DgvLineItem_SelectionChanged(object sender, EventArgs e)
        {
            SetLables();
        }

        private void DgvLineItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "Quantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "FreeQuantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "PurchaseSaleRate")
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

                    if(e.KeyChar == (char)Keys.Enter)
                    {
                        if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "FreeQuantity")
                        {
                            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                            OpenSchemeDialog(lineItem);
                        }
                        else if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "PurchaseSaleRate")
                        {
                            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                            OpenRateDialog(dgvLineItem.CurrentCell.RowIndex, lineItem);
                        }
                    }
                }
                //if(!string.IsNullOrWhiteSpace(Convert.ToString(dgvLineItem.CurrentCell.Value)) && e.KeyChar == (char)Keys.Enter)
                //{
                //    dgvLineItem.EndEdit();
                //    e.Handled = true;
                //}
                //if (string.IsNullOrWhiteSpace(Convert.ToString(dgvLineItem.CurrentCell.Value)) && e.KeyChar == (char)Keys.Enter)
                //{
                //    e.Handled = true;
                //    int rowIndex = dgvLineItem.CurrentCell.RowIndex;
                //    int colIndex = dgvLineItem.CurrentCell.ColumnIndex;
                //    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[colIndex + 1];
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

                if (isCellEdit && !isBatchUpdate && lineItem.PurchaseSaleBookLineItemID > 0)
                {
                    if (columnName == "Quantity" || columnName == "PurchaseSaleRate")
                    {
                        double amount = GetLineItemAmount(lineItem);
                        dgvLineItem.CurrentRow.Cells["Amount"].Value = amount;
                        lineItem.Amount = amount;
                    }

                    double value = 0L;
                    double.TryParse(Convert.ToString(dgvLineItem.CurrentCell.Value), out value);

                    if (value == 0 && (columnName == "Quantity" || columnName == "PurchaseSaleRate"))
                    {
                        dgvLineItem.CurrentCell = dgvLineItem.CurrentCell;
                        dgvLineItem.BeginEdit(true);
                    }
                    else
                    {
                        InsertUpdateLineItemAndsetToGrid(lineItem,0);
                    }
                }

                OpenDialogAndMoveToNextControl(columnName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenRateDialog(int rowIndex, PurchaseSaleBookLineItem lineItem)
        {
            double newRate = 0L;
            double oldRate = 0L;


            double.TryParse(Convert.ToString(dgvLineItem["OldPurchaseSaleRate", rowIndex].Value), out oldRate);
            double.TryParse(Convert.ToString(dgvLineItem["PurchaseSaleRate", rowIndex].Value), out newRate);

            if (oldRate != newRate)
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

        private void OpenSchemeDialog(PurchaseSaleBookLineItem lineItem)
        {
            PharmaUI.Purchase_Entry.frmLineItemScheme updateForm = new PharmaUI.Purchase_Entry.frmLineItemScheme(lineItem);
            updateForm.FormClosed += frmLineItemScheme_FormClosed;
            updateForm.ShowDialog();
        }

        private void DgvLineItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                isCellEdit = false;

                if (purchaseSaleBookHeaderID == 0)
                {
                    MessageBox.Show("Please enter invoice number before adding the items");
                    dgvLineItem.CancelEdit();
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Batch_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmLastNBatchNo batch = (frmLastNBatchNo)sender;

                int rowIndex = -1;
                int colIndex = -1;

                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    isBatchUpdate = true;
                    rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                    colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                    PurchaseSaleBookLineItem item = batch.PurchaseBookLineItem;
                    // dgvLineItem.CurrentRow.Cells[dgvLineItem.CurrentRow.Cells["Batch"].ColumnIndex].Value = batch.BatchNumber;
                    InsertUpdateLineItemAndsetToGrid(item, 0);

                }
                isBatchUpdate = false;

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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
            try
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
                else
                {
                    cbxPurchaseFormType.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbxPurchaseFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (purchaseSaleBookHeaderID > 0)
                {
                    PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                    bool result = GetPurchaseBookHeader(ref header);

                    if (result)
                    {
                        applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    else if (c is MaskedTextBox)
                    {
                        MaskedTextBox tb1 = (MaskedTextBox)c;
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
            try
            {
                if (isDirty)
                {
                    Control text = (Control)sender;

                    switch (text.Name)
                    {
                        case "txtInvoiceNumber":
                            {
                                PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                                bool result = GetPurchaseBookHeader(ref header);

                                if (result && isDirty)
                                {
                                    purchaseSaleBookHeaderID = applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                                }

                                dgvLineItem.Rows.Add();
                                dgvLineItem.CurrentCell = null;
                                cbxPurchaseType.Focus();
                            }

                            break;
                        case "txtSupplierCode":
                            {
                                if (isDirty && !string.IsNullOrEmpty(txtSupplierCode.Text))
                                {
                                    PharmaBusinessObjects.Master.SupplierLedgerMaster master = applicationFacade.GetSupplierLedgerByName(txtSupplierCode.Text);

                                    if (master == null)
                                    {
                                        lblSupplierName.Text = "**No Such Code**";
                                        txtSupplierCode.Focus();
                                    }
                                    else
                                    {
                                        lblSupplierName.Text = master.SupplierLedgerName;

                                        if (purchaseSaleBookHeaderID > 0)
                                        {
                                            PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                                            bool result = GetPurchaseBookHeader(ref header);

                                            if (result)
                                            {
                                                applicationFacade.InsertUpdateTempPurchaseBookHeader(header);

                                            }
                                        }
                                    }
                                }
                            }

                            break;
                        case "dtPurchaseDate":
                            {
                                MaskedTextBox dtPicker = (MaskedTextBox)sender;

                                if (string.IsNullOrWhiteSpace(dtPicker.Text) || dtPicker.Text == "  /  /")
                                {
                                    errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.RequiredField);
                                    dtPurchaseDate.Focus();
                                }
                                else
                                {
                                    DateTime dt = new DateTime();
                                    DateTime.TryParse(dtPicker.Text, out dt);
                                    if (dt > DateTime.Today || dt < DateTime.Today)
                                    {
                                        DialogResult result = MessageBox.Show(string.Format("Date is {0} today.", dt > DateTime.Today ? "ahead of" : "less than"));

                                        if (result == DialogResult.No)
                                            dtPicker.Text = DateTime.Now.ToShortDateString();

                                    }
                                }
                            }
                            break;
                    }

                    isDirty = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TextBox tb;

                frmSupplierLedger ledger = (frmSupplierLedger)sender;

                if (ledger.LastSelectedSupplier != null)
                {
                    lblSupplierName.Text = ledger.LastSelectedSupplier.SupplierLedgerName;
                    txtSupplierCode.Text = ledger.LastSelectedSupplier.SupplierLedgerCode;
                    tb = txtInvoiceNumber;
                }
                else
                {
                    tb = txtSupplierCode;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                if(tb != null)
                {
                    tb.Focus();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetPurchaseBookHeader(ref PurchaseSaleBookHeader header)
        {
            DateTime purchaseDate = new DateTime();
            DateTime.TryParse(dtPurchaseDate.Text, out purchaseDate);
            if (purchaseDate == DateTime.MinValue)
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

            header = new PurchaseSaleBookHeader();
            header.PurchaseSaleBookHeaderID = purchaseSaleBookHeaderID;

            header.VoucherDate = purchaseDate;
            header.PurchaseBillNo = txtInvoiceNumber.Text;
            header.LedgerTypeCode = txtSupplierCode.Text;
            header.LedgerType = Constants.TransactionLedgerType.SupplierLedger;
            header.VoucherTypeCode = Constants.VoucherTypeCode.PURCHASEENTRY;
            header.TotalTaxAmount = 0;

            PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
            header.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

            Int32.TryParse(Convert.ToString(cbxPurchaseFormType.SelectedValue), out purchaseFormTypeID);
            header.PurchaseEntryFormID = purchaseFormTypeID;

            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.End)
                {
                    if (purchaseSaleBookHeaderID > 0 && dgvLineItem.Rows.Count > 0)
                    {
                        PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                        GetPurchaseBookHeader(ref header);

                        if (header.LocalCentral == "L")
                        {
                            frmPurchaseHeaderAmount amount = new frmPurchaseHeaderAmount(header);
                            amount.FormClosed += Amount_FormClosed;
                            amount.ShowDialog();
                        }
                        else {
                            frmPurchaseHeaderCentralAmount amount = new frmPurchaseHeaderCentralAmount(header);
                            amount.FormClosed += Amount_FormClosed;
                            amount.ShowDialog();
                        }
                    }

                }

                else if (keyData == Keys.F5)
                {
                    frmPurchaseBookTransaction form = new frmPurchaseBookTransaction();
                    ExtensionMethods.AddTrasanctionFormToPanel(form, ExtensionMethods.MainPanel);
                    form.Show();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Amount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //frmPurchaseHeaderAmount amount = (frmPurchaseHeaderAmount)sender;
                dgvLineItem.CurrentCell = dgvLineItem.CurrentCell;
                var result = MessageBox.Show("Are you sure you want to save the purchase entry", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    applicationFacade.SavePurchaseData(purchaseSaleBookHeaderID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemScheme_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
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
                        PurchaseSaleBookLineItem lineItem = lineItemScheme.PurchaseBookLinetem;
                        InsertUpdateLineItemAndsetToGrid(lineItem, 0);


                    }
                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
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
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = itemMaster.LastSelectedItemMaster.ToPurchaseBookLineItem();
                        lineItem.PurchaseSaleBookHeaderID = purchaseSaleBookHeaderID;
                        lineItem.PurchaseSaleBookLineItemID = lineItemID;

                        DateTime purchaseDate = new DateTime();
                        DateTime.TryParse(dtPurchaseDate.Text, out purchaseDate);
                      
                        PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                        lineItem.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

                        int srno = dgvLineItem.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["SrNo"].Value));

                        InsertUpdateLineItemAndsetToGrid(lineItem, srno, true);
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                if (rowIndex != -1 && colIndex != -1)
                {
                    dgvLineItem.Focus();
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Batch"];
                    OpenBatchDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemBriefDiscount_FormClosed (object sender, FormClosedEventArgs e)
        {
            try
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
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;

                        InsertUpdateLineItemAndsetToGrid(lineItem, 0);                      
                  
                    }
                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                double rate = 0;
                double.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value), out rate);
                if (rate == 0L)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];
                }
                else
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Amount"];
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
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
                       
                        PurchaseSaleBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;

                        InsertUpdateLineItemAndsetToGrid(lineItem, 0);

                        dgvLineItem.CurrentRow.Cells["OldPurchaseSaleRate"].Value = lineItem.PurchaseSaleRate;
                    }
                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                double rate = 0;
                double.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value), out rate);
                if (rate == 0)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];
                }
                else
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Amount"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void frmPurchaseBookTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private PurchaseSaleBookLineItem ConvertToPurchaseBookLineItem(DataGridViewRow row)
        {
            PurchaseSaleBookLineItem item = new PurchaseSaleBookLineItem();
            int id = 0;
            double dValue = 0L;

            if (row != null)
            {
                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookLineItemID"].Value), out id);
                item.PurchaseSaleBookLineItemID = id;

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookHeaderID"].Value), out id);
                item.PurchaseSaleBookHeaderID = id;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.Batch = Convert.ToString(row.Cells["Batch"].Value);

                Int32.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out id);
                item.Quantity = id;

                Int32.TryParse(Convert.ToString(row.Cells["FreeQuantity"].Value), out id);
                item.FreeQuantity = id;

                double.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                double.TryParse(Convert.ToString(row.Cells["OldPurchaseSaleRate"].Value), out dValue);
                item.OldPurchaseSaleRate = dValue;

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

                DateTime date = DateTime.MinValue;
                DateTime.TryParse(Convert.ToString(row.Cells["ExpiryDate"].Value), out date);
                if (date == DateTime.MinValue)
                    item.ExpiryDate = null;
                else
                    item.ExpiryDate = date;

                double.TryParse(Convert.ToString(row.Cells["WholeSaleRate"].Value), out dValue);
                item.WholeSaleRate = dValue;

                double.TryParse(Convert.ToString(row.Cells["SpecialRate"].Value), out dValue);
                item.SpecialRate = dValue;

                double.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;
                
                item.PurchaseSaleTypeCode = Convert.ToString(row.Cells["PurchaseSaleTypeCode"].Value);

                double.TryParse(Convert.ToString(row.Cells["PurchaseSaleTax"].Value), out dValue);
                item.PurchaseSaleTax = dValue;

                //---------------------------------------
                double.TryParse(Convert.ToString(row.Cells["CostAmount"].Value), out dValue);
                item.CostAmount = dValue;

                double.TryParse(Convert.ToString(row.Cells["DiscountAmount"].Value), out dValue);
                item.DiscountAmount = dValue;

                double.TryParse(Convert.ToString(row.Cells["SpecialDiscountAmount"].Value), out dValue);
                item.SpecialDiscountAmount = dValue;
                
                double.TryParse(Convert.ToString(row.Cells["VolumeDiscountAmount"].Value), out dValue);
                item.VolumeDiscountAmount = dValue;
                
                double.TryParse(Convert.ToString(row.Cells["GrossAmount"].Value), out dValue);
                item.GrossAmount = dValue;
                
                double.TryParse(Convert.ToString(row.Cells["TaxAmount"].Value), out dValue);
                item.TaxAmount = dValue;
                
                double.TryParse(Convert.ToString(row.Cells["SchemeAmount"].Value), out dValue);
                item.SchemeAmount = dValue;
                
                double.TryParse(Convert.ToString(row.Cells["TotalDiscountAmount"].Value), out dValue);
                item.TotalDiscountAmount = dValue;

                double.TryParse(Convert.ToString(row.Cells["SurchargeAmount"].Value), out dValue);
                item.SurchargeAmount = dValue;

                
                PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                item.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

               

            }

            return item;
        }

        private double GetLineItemAmount(PurchaseSaleBookLineItem item)
        {
            double? amount = 0L;
            amount = item.Quantity * item.PurchaseSaleRate;
            return amount ?? 0;
        }

        private void dgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

                    if (!string.IsNullOrEmpty(Convert.ToString(dgvLineItem.CurrentCell.Value)) || columnName == "SrNo")
                    {
                        e.Handled = true;
                        double val = 0L;
                        double.TryParse(Convert.ToString(dgvLineItem.CurrentCell.Value), out val);

                        OpenDialogAndMoveToNextControl(columnName);                     
                    }
                    else
                    {
                        if (columnName == "ItemCode")
                        {
                            e.SuppressKeyPress = true;
                            frmItemMaster itemMaster = new frmItemMaster(true);
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                            itemMaster.WindowState = FormWindowState.Maximized;

                            itemMaster.FormClosed += ItemMaster_FormClosed; ;
                            itemMaster.Show();
                        }
                        else if (columnName == "Batch")
                        {
                            e.SuppressKeyPress = true;
                            OpenBatchDialog();
                            
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            
        }

        private void OpenBatchDialog()
        {
            var list = applicationFacade.GetLastNBatchNoForSupplierItem(txtSupplierCode.Text, Convert.ToString(dgvLineItem.CurrentRow.Cells["ItemCode"].Value));

            if (list != null && list.Count > 0)
            {
                PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                frmLastNBatchNo batch = new frmLastNBatchNo(list, lineItem);
                batch.FormClosed += Batch_FormClosed;
                batch.ShowDialog();
            }
        }

        private void OpenDialogAndMoveToNextControl(string columnName)
        {
            if (columnName == "FreeQuantity")
            {
                int qty = 0;
                Int32.TryParse(Convert.ToString(dgvLineItem.CurrentCell.Value), out qty);

                if (qty > 0)
                {
                    PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                    OpenSchemeDialog(lineItem);
                }
                else {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[dgvLineItem.CurrentCell.RowIndex].Cells["PurchaseSaleRate"];
                }
            }
            else if (columnName == "PurchaseSaleRate")
            {
                PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                OpenRateDialog(dgvLineItem.CurrentCell.RowIndex, lineItem);
            }
            else if (columnName == "ItemCode")
            {
                OpenBatchDialog();
            }
            else //if ((columnName != "Quantity" && columnName != "PurchaseSaleRate") || (val != 0 && (columnName == "Quantity" || columnName == "PurchaseSaleRate")))
            {
                int colIndex = dgvLineItem.CurrentCell.ColumnIndex + 1;
                int rowIndex = dgvLineItem.CurrentCell.RowIndex;

                if (colIndex <= 8)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells[colIndex];
                }
                else
                {
                    if (rowIndex == dgvLineItem.Rows.Count - 1)
                    {
                        dgvLineItem.Rows.Add();
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells[2];
                    }
                    else
                    {
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells[2];
                    }
                }

                if (columnName == "Quantity")
                {
                    int val = 0;
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value), out val);

                    if(val == 0)
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseBookTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;

                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txt.Text))
                    {
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    else
                    {
                        if (txt.Name == "txtSupplierCode")
                        {
                            frmSupplierLedger ledger = new frmSupplierLedger(true);
                            //Set Child UI

                            ExtensionMethods.AddChildFormToPanel(this, ledger, ExtensionMethods.MainPanel);
                            ledger.WindowState = FormWindowState.Maximized;

                            ledger.FormClosed += Ledger_FormClosed;
                            ledger.Show();

                        }
                    }
                }
            }

            else if (sender is MaskedTextBox)
            {
                MaskedTextBox txt = (MaskedTextBox)sender;

                if (e.KeyCode == Keys.Enter && txt.Text != "  /  /")
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
            else if (sender is ComboBox)
            {
                ComboBox bx = sender as ComboBox;

                if (bx.Name == "cbxPurchaseFormType" || (cbxPurchaseFormType.Visible == false && bx.Name== "cbxPurchaseType"))
                {
                    if (dgvLineItem.Rows.Count > 0)
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells[2];
                }
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
           
        }



        private void SetLables()
        {
            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);

            lblSaleRate.Text = lineItem.SaleRate.ToString();
            lblDiscountPercente.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.Discount)));
            lblDiscountAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.DiscountAmount)));
            lblMRP.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.MRP)));           
            lblTaxPercent.Text = lineItem.PurchaseSaleTax.ToString();
            lblTaxAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.TaxAmount)));
            lblInvoiceAmount.Text = lineItem.Amount.ToString();
            lblBonus.Text = lineItem.Scheme1.ToString() + " + " + lineItem.Scheme2.ToString();
            lblSplDiscountPercent.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.SpecialDiscount)));
            lblSplDisAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.SpecialDiscountAmount)));
            lblVolumeDis.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.VolumeDiscount)));
            lblVolumeDiscountAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDouble(Convert.ToString(lineItem.VolumeDiscountAmount)));
        }

        private void InsertUpdateLineItemAndsetToGrid(PurchaseSaleBookLineItem lineItem,int srno, bool setSrNo = false)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                double amt = GetLineItemAmount(lineItem);
                lineItem.Amount = amt;

                List<PurchaseBookAmount>  amounts = applicationFacade.InsertUpdateTempPurchaseBookLineItem(lineItem);

                if (amounts != null && amounts.Count > 0)
                {
                    lineItem.PurchaseSaleBookLineItemID = amounts.Where(p => p.PurchaseSaleBookLineItemID > 0).FirstOrDefault().PurchaseSaleBookLineItemID;


                    PurchaseBookAmount amountTotal = amounts.Where(p => p.PurchaseSaleBookLineItemID == 0).FirstOrDefault();
                    if (amountTotal == null)
                    {
                        amountTotal = new PurchaseBookAmount();
                    }

                    PurchaseBookAmount amountLineItem = amounts.Where(p => p.PurchaseSaleBookLineItemID > 0).FirstOrDefault();

                    if (amountLineItem == null)
                    {
                        amountLineItem = new PurchaseBookAmount();
                    }

                    dgvLineItem.Rows[rowIndex].Cells["CostAmount"].Value = amountLineItem.CostAmount;
                    dgvLineItem.Rows[rowIndex].Cells["DiscountAmount"].Value = amountLineItem.DiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscountAmount"].Value = amountLineItem.SpecialDiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscountAmount"].Value = amountLineItem.VolumeDiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["GrossAmount"].Value = amountLineItem.GrossAmount;
                    dgvLineItem.Rows[rowIndex].Cells["TaxAmount"].Value = amountLineItem.TaxAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SchemeAmount"].Value = amountLineItem.SchemeAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SurchargeAmount"].Value = lineItem.SurchargeAmount;
                    dgvLineItem.Rows[rowIndex].Cells["TotalDiscountAmount"].Value = amountLineItem.TotalDiscountAmount;


                    lblTotalDiscountAmt.Text = Convert.ToString(amountTotal.TotalDiscountAmount);
                    lblTotalSchemeAmt.Text = Convert.ToString(amountTotal.SchemeAmount);
                    lblTotalTaxAmount.Text = Convert.ToString(amountTotal.TaxAmount);
                    lblTotalAmount.Text = Convert.ToString(amountTotal.GrossAmount);
                }


                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value = lineItem.PurchaseSaleBookLineItemID;
                if (setSrNo)
                {
                    dgvLineItem.Rows[rowIndex].Cells["SrNo"].Value = srno + 1;
                }
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value = purchaseSaleBookHeaderID;
                dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItem.ItemCode;
                dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItem.ItemName;
                dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItem.Quantity;
                dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItem.FreeQuantity;
                dgvLineItem.Rows[rowIndex].Cells["Batch"].Value = lineItem.Batch;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value = lineItem.PurchaseSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleRate"].Value = lineItem.OldPurchaseSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = amt;
                dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                dgvLineItem.Rows[rowIndex].Cells["ExpiryDate"].Value = lineItem.ExpiryDate;
                dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItem.SaleRate;
                dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItem.SpecialRate;
                dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItem.WholeSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTypeCode"].Value = lineItem.PurchaseSaleTypeCode;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTax"].Value = lineItem.PurchaseSaleTax;
                dgvLineItem.Rows[rowIndex].Cells["LocalCentral"].Value = lineItem.LocalCentral;
                

            }
        }

        private void frmPurchaseBookTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (purchaseSaleBookHeaderID > 0)
            {
                bool result = applicationFacade.IsTempPurchaseHeaderExists(purchaseSaleBookHeaderID);

                if (result)
                {
                    DialogResult isConfirm = MessageBox.Show("There are some unsaved changes. Do you want to close the screen", "Warning", MessageBoxButtons.YesNo);

                    if (isConfirm == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            
            }
        }
    }
}
