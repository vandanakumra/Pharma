using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.SaleEntry;
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
    public partial class frmSaleEntry : Form
    {
        private bool IsModify = false;
        private bool isDirty = false;
        private bool isBatchUpdate = false;
        private int layoutHeight = 0;
        private int layoutWidth = 0;
        private bool isCellEdit = false;

        IApplicationFacade applicationFacade;
        private PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
        private PurchaseSaleBookLineItem lineItem = new PurchaseSaleBookLineItem();

        private int oldSelectedRowIndex = -1;
        private bool isSetGrid = false;

        public frmSaleEntry(bool isModify)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.IsModify = isModify;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSaleEntry_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Sale Entry Transaction");
                ExtensionMethods.AddFooter(this);
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);
                InitializeGrid();
                dtSaleDate.Focus();
                string format = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                format = format.IndexOf("MM") < 0 ? format.Replace("M", "MM") : format;
                format = format.IndexOf("dd") < 0 ? format.Replace("d", "dd") : format;
                //format = format.IndexOf("yyyy") < 0 ? format.Replace("d", "dd") : format;
                dtSaleDate.Text = DateTime.Now.ToString(format);
                dtSaleDate.Select(0, 0);

                layoutHeight = tableLayoutPanel3.Height;
                layoutWidth = tableLayoutPanel3.Width;
                tableLayoutPanel3.Height = 0;
                tableLayoutPanel3.Width = 0;
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
            dgvLineItem.Columns["SrNo"].Visible = false;

            dgvLineItem.Columns.Add("ItemCode", "Item Code");
            dgvLineItem.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemCode"].FillWeight = 10;
            dgvLineItem.Columns["ItemCode"].ReadOnly = true;

            dgvLineItem.Columns.Add("ItemName", "ItemName");
            dgvLineItem.Columns["ItemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemName"].FillWeight = 15;
            dgvLineItem.Columns["ItemName"].ReadOnly = true;

            dgvLineItem.Columns.Add("Batch", "Batch No");
            dgvLineItem.Columns["Batch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Batch"].FillWeight = 10;
            dgvLineItem.Columns["Batch"].ReadOnly = true;


            dgvLineItem.Columns.Add("Quantity", "Quantity");
            dgvLineItem.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Quantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("FreeQuantity", "Free Quantity");
            dgvLineItem.Columns["FreeQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FreeQuantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("SaleRate", "Rate");
            dgvLineItem.Columns["SaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleRate"].FillWeight = 5;

            dgvLineItem.Columns.Add("Amount", "Amount");
            dgvLineItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Amount"].FillWeight = 5;

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
            
            dgvLineItem.Columns.Add("BatchNew", "BatchNew");
            dgvLineItem.Columns["BatchNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BatchNew"].Visible = false;

            dgvLineItem.Columns.Add("CGST", "CGST");
            dgvLineItem.Columns["CGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CGST"].Visible = false;

            dgvLineItem.Columns.Add("BalanceQuantity", "BalanceQuantiity");
            dgvLineItem.Columns["BalanceQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BalanceQuantity"].Visible = false;
            
            dgvLineItem.Columns.Add("ConversionRate", "ConversionRate");
            dgvLineItem.Columns["ConversionRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ConversionRate"].Visible = false;

            dgvLineItem.Columns.Add("CostAmount", "CostAmount");
            dgvLineItem.Columns["CostAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CostAmount"].Visible = false;

            dgvLineItem.Columns.Add("DiscountQuantity", "DiscountQuantity");
            dgvLineItem.Columns["DiscountQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["DiscountQuantity"].Visible = false;

            dgvLineItem.Columns.Add("EffecivePurchaseSaleRate", "EffecivePurchaseSaleRate");
            dgvLineItem.Columns["EffecivePurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["EffecivePurchaseSaleRate"].Visible = false;
            
            dgvLineItem.Columns.Add("HalfSchemeRate", "HalfSchemeRate");
            dgvLineItem.Columns["HalfSchemeRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["HalfSchemeRate"].Visible = false;

            dgvLineItem.Columns.Add("IGST", "IGST");
            dgvLineItem.Columns["IGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["IGST"].Visible = false;

            dgvLineItem.Columns.Add("LocalCentral", "LocalCentral");
            dgvLineItem.Columns["LocalCentral"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["LocalCentral"].Visible = false;

            dgvLineItem.Columns.Add("MRP", "MRP");
            dgvLineItem.Columns["MRP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["MRP"].Visible = false;
            
            dgvLineItem.Columns.Add("PurchaseBillDate", "PurchaseBillDate");
            dgvLineItem.Columns["PurchaseBillDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseBillDate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTax", "PurchaseSaleTax");
            dgvLineItem.Columns["PurchaseSaleTax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTax"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTypeCode", "PurchaseSaleTypeCode");
            dgvLineItem.Columns["PurchaseSaleTypeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTypeCode"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSrlNo", "PurchaseSrlNo");
            dgvLineItem.Columns["PurchaseSrlNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSrlNo"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseVoucherNumber", "PurchaseVoucherNumber");
            dgvLineItem.Columns["PurchaseVoucherNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseVoucherNumber"].Visible = false;
            
            dgvLineItem.Columns.Add("SGST", "SGST");
            dgvLineItem.Columns["SGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SGST"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("SurCharge", "SurCharge");
            dgvLineItem.Columns["SurCharge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SurCharge"].Visible = false;

            dgvLineItem.Columns.Add("VolumeDiscount", "VolumeDiscount");
            dgvLineItem.Columns["VolumeDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscount"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleRate", "PurchaseSaleRate");
            dgvLineItem.Columns["PurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("ExpiryDate", "ExpiryDate");
            dgvLineItem.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ExpiryDate"].Visible = false;

            dgvLineItem.Columns.Add("FifoID", "FifoID");
            dgvLineItem.Columns["FifoID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FifoID"].Visible = false;


            dgvLineItem.KeyDown += dgvLineItem_KeyDown;
            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
            dgvLineItem.EditingControlShowing += DgvLineItem_EditingControlShowing;
            dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged; ;
        }

        private void DgvLineItem_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;

            if (oldSelectedRowIndex != rowIndex && !isSetGrid && !string.IsNullOrEmpty(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value)))
            {
                long id = 0;
                long.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value), out id);
                SetFooterInfo(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ItemCode"]), id);
            }

            if (oldSelectedRowIndex != rowIndex && !isSetGrid)
                oldSelectedRowIndex = rowIndex;

        }

        private void DgvLineItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                isCellEdit = false;

                if (header.PurchaseSaleBookHeaderID == 0)
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

        private void DgvLineItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                string columnName = dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name;
                if (columnName == "Quantity")
                {
                    double value = 0;
                    double.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value), out value);

                    double balance = 0;
                    double.TryParse(lblBalance.Text, out balance);

                    if (value == 0)
                    {
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                        return;
                    }
                    else if(balance < value)
                    {
                        MessageBox.Show("Quantity entered is out of stock. Please change the quantity");
                        dgvLineItem.BeginEdit(true);
                        return;
                    }
                    else
                    {
                        InsertUpdateLineItemAndsetToGrid(lineItem);
                        OpenDialogAndMoveToNextControl();
                        SetFooterInfo(lineItem.ItemCode, lineItem.FifoID??0);
                    }
                }
                else if (columnName == "SaleRate")
                {
                    ValidateSaleRate(rowIndex, true);
                }
                else
                {
                    InsertUpdateLineItemAndsetToGrid(lineItem);
                    OpenDialogAndMoveToNextControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidateSaleRate(int rowIndex, bool isEdit)
        {

            double value = 0;
            double.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value), out value);

            if (value == 0)
            {
                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                return;
            }
            else
            {
                double purchaseSaleRate = 0;
                double.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value), out purchaseSaleRate);

                if (purchaseSaleRate > value)
                {
                    if (MessageBox.Show(string.Format("Cost of this item {0} is greater than purchase rate. Do you want to continue?", purchaseSaleRate.ToString("#.##")), "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if(isEdit)
                            InsertUpdateLineItemAndsetToGrid(lineItem);
                        OpenDialogAndMoveToNextControl();
                    }
                    else
                    {
                        if (isEdit)
                            dgvLineItem.BeginEdit(true);
                        else
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                    }
                }
                else
                {
                    if(isEdit)
                        InsertUpdateLineItemAndsetToGrid(lineItem);
                    OpenDialogAndMoveToNextControl();
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

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "Quantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "FreeQuantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "SaleRate")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                    }
                    // only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }

                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "SaleRate")
                        {
                            //PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                            //OpenRateDialog(dgvLineItem.CurrentCell.RowIndex, lineItem);
                        }
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
                        case "txtCustomerCode":
                            {
                                if (isDirty && !string.IsNullOrEmpty(txtCustomerCode.Text))
                                {
                                    SetCustomerCodeFields(txtCustomerCode.Text);
                                }
                            }

                            break;
                        case "dtSaleDate":
                            {
                                MaskedTextBox dtPicker = (MaskedTextBox)sender;

                                if (string.IsNullOrWhiteSpace(dtPicker.Text) || dtPicker.Text == "  /  /")
                                {
                                    errFrmSaleEntry.SetError(dtSaleDate, Constants.Messages.RequiredField);
                                    dtSaleDate.Focus();
                                }
                                else
                                {
                                    DateTime dt = new DateTime();
                                    DateTime.TryParse(dtPicker.Text, out dt);
                                    if (dt > DateTime.Today || dt < DateTime.Today)
                                    {
                                        DialogResult result = MessageBox.Show(string.Format("Date is {0} today.", dt > DateTime.Today ? "ahead of" : "less than"));

                                        if (result == DialogResult.No)
                                        {
                                            dtPicker.Text = DateTime.Now.ToString();
                                        }
                                    }
                                }
                            }
                            break;
                        case "txtSalesManCode":
                            {
                                if (isDirty)
                                {
                                    if (!string.IsNullOrEmpty(txtSalesManCode.Text))
                                    {
                                        if (header.PurchaseSaleBookHeaderID > 0)
                                        {
                                            AccountLedgerMaster master = applicationFacade.GetAccountLedgerByCode(txtSalesManCode.Text);

                                            if (master != null && master.AccountLedgerID > 0)
                                            {
                                                header.SalesManId = master.AccountLedgerID;
                                                lblSaleTypeCode.Text = master.AccountLedgerCode;
                                                applicationFacade.InsertUpdateTempPurchaseBookHeader(header);

                                                if (dgvLineItem.Rows.Count == 0)
                                                    AddRowToGrid();
                                                else
                                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                            }
                                            else
                                            {
                                                lblSaleTypeCode.Text = "**No Such Code**";
                                                txtSalesManCode.Focus();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        txtSalesManCode.Focus();
                                    }
                                }
                                else {
                                    if (!string.IsNullOrEmpty(txtSalesManCode.Text))
                                    {
                                        if (dgvLineItem.Rows.Count > 0 && header.PurchaseSaleBookHeaderID > 0)
                                            AddRowToGrid();
                                    }
                                    else
                                    {
                                        txtSalesManCode.Focus();
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
            if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{TAB}");
                return;
            }

            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;

                if (e.KeyCode == Keys.Enter)
                {
                    if (txt.Name == "txtInvoiceNumber" && IsModify && string.IsNullOrEmpty(txtInvoiceNumber.Text))
                    {
                        //Purchase_Entry.frmAllBillForSupplier frm = new Purchase_Entry.frmAllBillForSupplier(txtSupplierCode.Text);
                        //frm.FormClosed += AllBillForSuppier_FormClosed;
                        //frm.ShowDialog();

                    }
                    else if (!string.IsNullOrEmpty(txt.Text))
                    {

                        if (txt.Name == "txtSalesManCode" && dgvLineItem.Rows.Count == 0)
                        {
                            AddRowToGrid();
                        }
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        
                        
                    }
                    else
                    {
                        if (txt.Name == "txtCustomerCode")
                        {
                            frmCustomerLedgerMaster ledger = new frmCustomerLedgerMaster();
                            ledger.IsInChildMode = true;
                            //Set Child UI

                            ExtensionMethods.AddChildFormToPanel(this, ledger, ExtensionMethods.MainPanel);
                            ledger.WindowState = FormWindowState.Maximized;

                            ledger.FormClosed += CustomerLedger_Closed;
                            ledger.Show();

                        }
                        if (txt.Name == "txtSalesManCode")
                        {
                            txtSalesManCode.Focus();
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
            
        }

        private void CustomerLedger_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TextBox tb;

                frmCustomerLedgerMaster ledger = (frmCustomerLedgerMaster)sender;

                if (ledger.LastSelectedCustomerLedger != null)
                {
                    SetCustomerCodeFields(ledger.LastSelectedCustomerLedger.CustomerLedgerCode);
                    tb = txtSalesManCode;
                }
                else
                {
                    tb = txtCustomerCode;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                if (tb != null)
                {
                    tb.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetCustomerCodeFields(string code)
        {

            PharmaBusinessObjects.Master.CustomerLedgerMaster customer = applicationFacade.GetCustomerLedgerByCode(code);
            if (customer == null)
            {
                lblCustomerName.Text = "**No Such Code**";
                txtCustomerCode.Focus();
            }
            else
            {
                lblCustomerName.Text = customer.CustomerLedgerName;
                txtCustomerCode.Text = customer.CustomerLedgerCode;
                lblSaleManName.Text = customer.SalesmanName;
                txtSalesManCode.Text = customer.SalesManCode.ToString();
                lblFRate.Text = customer.RateTypeName;
                lblDueBills.Text = customer.DueBillCount.ToString();
                lblDueBillAmount.Text = (customer.DueBillAmount ?? 0).ToString("#.##");

                DateTime date;
                DateTime.TryParse(dtSaleDate.Text, out date);
                if (date == DateTime.MinValue)
                    header.DueDate = null;
                else
                    header.DueDate = date;
                header.CustomerTypeId = customer.CustomerTypeID;
                header.VoucherDate = header.DueDate??DateTime.Now;
                header.LedgerTypeCode = txtCustomerCode.Text;
                header.LedgerType = Constants.TransactionEntityType.CustomerLedger;
                header.VoucherTypeCode = Constants.VoucherTypeCode.SALEENTRY;

                header.PurchaseSaleBookHeaderID = applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
            }
        }

        private void frmSaleEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Right)
                {
                    string columnName = dgvLineItem.Columns[dgvLineItem.SelectedCells[0].ColumnIndex].Name;

                    if (string.IsNullOrEmpty(Convert.ToString(dgvLineItem.CurrentCell.Value)))
                    {
                        if (columnName == "ItemCode")
                        {
                            e.SuppressKeyPress = true;
                            frmItemMaster itemMaster = new frmItemMaster(true);
                            //Set Child UI
                            ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                            itemMaster.WindowState = FormWindowState.Maximized;

                            itemMaster.FormClosed += ItemMaster_FormClosed;
                            itemMaster.Show();
                        }
                        else if (columnName == "Batch")
                        {
                            MessageBox.Show("Batch cannot be left blank. Please select other item");
                            dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Batch"];
                        }
                        else if (columnName == "Quantity" || columnName == "SaleRate")
                        {
                            dgvLineItem.CurrentCell = dgvLineItem.CurrentCell;
                        }
                        else
                        {
                            OpenDialogAndMoveToNextControl();
                        }
                    }
                    else
                    {
                        
                        if ((columnName == "Quantity" || columnName == "SaleRate"))
                        {
                            decimal value = 0;
                            decimal.TryParse(Convert.ToString(dgvLineItem.CurrentCell.Value), out value);
                            if(value == 0)
                                dgvLineItem.CurrentCell = dgvLineItem.CurrentCell;
                            else
                                OpenDialogAndMoveToNextControl();
                        }
                        else
                            OpenDialogAndMoveToNextControl();
                    }

                    e.Handled = true;
                }
                else if (e.KeyData == Keys.Delete || e.KeyData == Keys.Escape)
                {
                    try
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {

                            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                            int rowIndex = dgvLineItem.CurrentRow.Index;
                            dgvLineItem.Rows.RemoveAt(rowIndex);

                            if (dgvLineItem.Rows.Count == 0)
                            {
                                dgvLineItem.Rows.Add();
                                dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                dgvLineItem.Focus();
                            }
                            else
                            {
                                dgvLineItem.CurrentCell = dgvLineItem.Rows[dgvLineItem.RowCount - 1].Cells["ItemCode"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OpenDialogAndMoveToNextControl()
        {
            int colIndex = dgvLineItem.CurrentCell.ColumnIndex + 1;
            int rowIndex = dgvLineItem.CurrentCell.RowIndex;
            string columnName = dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name;
            if (columnName == "SaleRate")
            {
                PurchaseSaleBookLineItem item = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                frmItemDiscount discount = new frmItemDiscount(item,txtCustomerCode.Text);
                discount.FormClosed += Discount_FormClosed;
                discount.Show();
            }
            else
            {
                if (colIndex <= 8)
                {
                    dgvLineItem.Rows[rowIndex].Selected = true;
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[colIndex];

                }
                else
                {
                    if (rowIndex == dgvLineItem.Rows.Count - 1)
                    {
                        dgvLineItem.Rows.Add();
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                    }
                    else
                    {
                        dgvLineItem.Rows[rowIndex + 1].Selected = true;
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                    }
                }
            }
            
        }

        private void Discount_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmItemDiscount discountForm = sender as frmItemDiscount;
            InsertUpdateLineItemAndsetToGrid(discountForm.SaleLinetem);
            if (dgvLineItem.SelectedCells.Count > 0)
            { 
                dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Selected = true;
                dgvLineItem.CurrentCell = dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Amount"];
            }
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmItemMaster itemMaster = (frmItemMaster)sender;
                int rowIndex = -1;
                int colIndex = -1;

                if (dgvLineItem.SelectedCells.Count > 0 && header .PurchaseSaleBookHeaderID > 0)
                {
                    rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                    colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                    if (itemMaster.LastSelectedItemMaster != null)
                    {
                        isBatchUpdate = true;
                        int lineItemID = 0;
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = applicationFacade.GetNewSaleLineItem(itemMaster.LastSelectedItemMaster.ItemCode, txtCustomerCode.Text);

                        lineItem.PurchaseSaleBookHeaderID = header.PurchaseSaleBookHeaderID;
                        lineItem.PurchaseSaleBookLineItemID = lineItemID;

                        DateTime saleDate = new DateTime();
                        DateTime.TryParse(dtSaleDate.Text, out saleDate);

                        InsertUpdateLineItemAndsetToGrid(lineItem);
                        SetFooterInfo(lineItem.ItemCode, lineItem.FifoID ?? 0);
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                dgvLineItem.Focus();
                if (!string.IsNullOrEmpty(Convert.ToString(dgvLineItem.CurrentRow.Cells["Batch"].Value)))
                    dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Quantity"];
                else
                    dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Batch"];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        }

        private void InsertUpdateLineItemAndsetToGrid(PurchaseSaleBookLineItem lineItem) //,int srno, bool setSrNo = false)
        {
            int rowIndex = -1;
            int colIndex = -1;
            int currentRowIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;
                currentRowIndex = dgvLineItem.SelectedCells[0].RowIndex;

                List<PurchaseSaleBookLineItem> lineItemList = applicationFacade.InsertUpdateTempPurchaseBookLineItemForSale(lineItem);
                var existingIDlist = dgvLineItem.Rows.OfType<DataGridViewRow>()
                                                .Select(r => new {
                                                    LineItemId = Convert.ToString(r.Cells["PurchaseSaleBookLineItemID"].Value),
                                                    RwIndex = r.Index
                                                    })
                                                .ToList();
                isSetGrid = true;
                for (int i = 0; i < lineItemList.Count; i++)
                {
                    if (!existingIDlist.Any(p=>p.LineItemId == lineItemList[i].PurchaseSaleBookLineItemID.ToString()))
                    {
                        if (dgvLineItem.Rows.Count > 0 && dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "ItemCode")
                        {
                            rowIndex = dgvLineItem.CurrentCell.RowIndex;
                            //currentRowIndex = rowIndex;
                            //colIndex = dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Index;
                        }
                        else
                        {
                            dgvLineItem.Rows.Add();
                            rowIndex = dgvLineItem.Rows.Count - 1;
                            //colIndex = 0;
                        }
                    }
                    else
                    {
                        rowIndex = existingIDlist.FirstOrDefault(p=>p.LineItemId == lineItemList[i].PurchaseSaleBookLineItemID.ToString()).RwIndex;
                        //colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;
                    }

                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value = lineItemList[i].PurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value = header.PurchaseSaleBookHeaderID;
                    dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItemList[i].ItemCode;
                    dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItemList[i].ItemName;
                    dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItemList[i].Quantity;
                    dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItemList[i].FreeQuantity;
                    dgvLineItem.Rows[rowIndex].Cells["Batch"].Value = lineItemList[i].Batch;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value = lineItemList[i].PurchaseSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItemList[i].SaleRate;
                    //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleRate"].Value = lineItemList[i].OldPurchaseSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount(Convert.ToString(lineItemList[i].Quantity),Convert.ToString(lineItemList[i].SaleRate));
                    dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItemList[i].Scheme1;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItemList[i].Scheme2;
                    dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItemList[i].IsHalfScheme;
                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItemList[i].Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItemList[i].SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItemList[i].VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItemList[i].MRP;
                    dgvLineItem.Rows[rowIndex].Cells["ExpiryDate"].Value = lineItemList[i].ExpiryDate;

                    dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItemList[i].SpecialRate;
                    dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItemList[i].WholeSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTypeCode"].Value = lineItemList[i].PurchaseSaleTypeCode;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseBillDate"].Value = lineItemList[i].PurchaseBillDate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseVoucherNumber"].Value = lineItemList[i].PurchaseVoucherNumber;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSrlNo"].Value = lineItemList[i].PurchaseSrlNo;
                    dgvLineItem.Rows[rowIndex].Cells["BatchNew"].Value = lineItemList[i].BatchNew;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTax"].Value = lineItemList[i].PurchaseSaleTax;
                    dgvLineItem.Rows[rowIndex].Cells["LocalCentral"].Value = lineItemList[i].LocalCentral;
                    dgvLineItem.Rows[rowIndex].Cells["DiscountQuantity"].Value = lineItemList[i].DiscountQuantity;
                    dgvLineItem.Rows[rowIndex].Cells["HalfSchemeRate"].Value = lineItemList[i].HalfSchemeRate;
                    //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleBookLineItemID"].Value = lineItemList[i].OldPurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value = lineItemList[i].FifoID;
                    dgvLineItem.Rows[rowIndex].Cells["SurCharge"].Value = lineItemList[i].SurCharge;
                    dgvLineItem.Rows[rowIndex].Cells["SGST"].Value = lineItemList[i].SGST;
                    dgvLineItem.Rows[rowIndex].Cells["IGST"].Value = lineItemList[i].IGST;
                    dgvLineItem.Rows[rowIndex].Cells["CGST"].Value = lineItemList[i].CGST;
                    dgvLineItem.Rows[rowIndex].Cells["ConversionRate"].Value = lineItemList[i].ConversionRate;


                }
                isSetGrid = false;
                
            }

            if (currentRowIndex != -1)
            {
                dgvLineItem.Rows[currentRowIndex].Selected = true;
                dgvLineItem.CurrentCell = dgvLineItem.Rows[currentRowIndex].Cells[colIndex];
            }
        }

        private decimal GetLineItemAmount(string qty, string srate)
        {
            decimal dQty = 0;
            decimal.TryParse(qty, out dQty);

            decimal dSaleRate = 0;
            decimal.TryParse(srate, out dSaleRate);

            return dQty * dSaleRate;

        }

        private PurchaseSaleBookLineItem ConvertToPurchaseBookLineItem(DataGridViewRow row)
        {
            PurchaseSaleBookLineItem item = new PurchaseSaleBookLineItem();
            int id = 0;
            decimal dValue = 0L;
            DateTime dDate = new DateTime();

            if (row != null)
            {
                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookLineItemID"].Value), out id);
                item.PurchaseSaleBookLineItemID = id;

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookHeaderID"].Value), out id);
                item.PurchaseSaleBookHeaderID =  header.PurchaseSaleBookHeaderID ;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.Batch = Convert.ToString(row.Cells["Batch"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out dValue);
                item.Quantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["FreeQuantity"].Value), out dValue);
                item.FreeQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Amount"].Value), out dValue);
                item.Amount = (item.Quantity * item.SaleRate) ?? 0;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme1"].Value), out id);
                item.Scheme1 = id;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme2"].Value), out id);
                item.Scheme2 = id;

                item.IsHalfScheme = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialDiscount"].Value), out dValue);
                item.SpecialDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                int.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;
                
                decimal.TryParse(Convert.ToString(row.Cells["BalanceQuantity"].Value), out dValue);
                item.BalanceQuantity = dValue;

                item.BatchNew   = Convert.ToString(row.Cells["BatchNew"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["CGST"].Value), out dValue);
                item.CGST = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["ConversionRate"].Value), out dValue);
                item.ConversionRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["CostAmount"].Value), out dValue);
                item.CostAmount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["DiscountQuantity"].Value), out dValue);
                item.DiscountQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["EffecivePurchaseSaleRate"].Value), out dValue);
                item.EffecivePurchaseSaleRate = dValue;

                DateTime.TryParse(Convert.ToString(row.Cells["ExpiryDate"].Value), out dDate);
                if (dDate == DateTime.MinValue)
                    item.ExpiryDate = null; 
                else
                    item.ExpiryDate = dDate;

                Int32.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;

                decimal.TryParse(Convert.ToString(row.Cells["HalfSchemeRate"].Value), out dValue);
                item.HalfSchemeRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["IGST"].Value), out dValue);
                item.IGST = dValue;

                item.LocalCentral = Convert.ToString(row.Cells["LocalCentral"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["MRP"].Value), out dValue);
                item.MRP = dValue;

                DateTime.TryParse(Convert.ToString(row.Cells["PurchaseBillDate"].Value), out dDate);
                if (dDate == DateTime.MinValue)
                    item.PurchaseBillDate = null;
                else
                    item.PurchaseBillDate = dDate;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleTax"].Value), out dValue);
                item.PurchaseSaleTax = dValue;

                item.PurchaseSaleTypeCode = Convert.ToString(row.Cells["PurchaseSaleTypeCode"].Value);

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSrlNo"].Value), out id);
                item.PurchaseSrlNo = id;

                item.PurchaseVoucherNumber = Convert.ToString(row.Cells["PurchaseVoucherNumber"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["SGST"].Value), out dValue);
                item.SGST = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialRate"].Value), out dValue);
                item.SpecialRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SurCharge"].Value), out dValue);
                item.SurCharge = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["VolumeDiscount"].Value), out dValue);
                item.VolumeDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["WholeSaleRate"].Value), out dValue);
                item.WholeSaleRate = dValue;
            }

            return item;
        }

        private void AddRowToGrid(string columnName = "")
        {
            int rowIndex = 0;
            columnName = string.IsNullOrEmpty(columnName) ? "ItemCode" : columnName;
            if (dgvLineItem.Rows.Count > 0)
            {
                rowIndex = dgvLineItem.CurrentCell.RowIndex;
            }
            dgvLineItem.Focus();
            dgvLineItem.Rows.Add();
            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[columnName];
        }

        private void SetFooterInfo(string code, long fifoID)
        {
            SaleLineItemInfo info = applicationFacade.GetSaleLineItemInfo(code, fifoID);
            lblBalance.Text = info.Balance.ToString("#.##");
            lblPacking.Text = info.Packing;
            lblSaleTypeCode.Text = info.SaleType;
            lblCaseQuantity.Text = info.CaseQty.ToString("#.##");
            lblIsHalf.Text = info.IsHalf ? "Y" : "N";
            lblDiscount.Text = dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Discount"].Value) : "0";
            lblSurharge.Text = info.Surcharge.ToString("#.##");
            lblTaxRate.Text = dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["PurchaseSaleTax"].Value): "0";//info.TaxAmount.ToString("#.##");
            lblScheme.Text = string.Concat(dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Scheme1"].Value) : "0", "+", dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Scheme2"].Value) : "0");

            if(info.LastBillInfo != null && info.LastBillInfo.BillDate != DateTime.MinValue)
            {
                tableLayoutPanel3.Height = layoutHeight;
                tableLayoutPanel3.Width = layoutWidth;

                lblLBBatch.Text = info.LastBillInfo.Batch;
                lblLBRate.Text = info.LastBillInfo.Rate.ToString("#.##");
                lblLBScheme.Text = string.Concat(info.LastBillInfo.Scheme1.ToString("#.##"), "+", info.LastBillInfo.Scheme2.ToString("#.##"));
                lblLBSpLDis.Text = info.LastBillInfo.SpecialDiscount.ToString("#.##");
                lblLBTax.Text = info.LastBillInfo.Tax.ToString("#.##");
                lblLBDis.Text = info.LastBillInfo.Discount.ToString("#.##");
                lblLBDate.Text = info.LastBillInfo.BillDate == DateTime.MinValue ? string.Empty : info.LastBillInfo.BillDate.ToString("dd/mm/yyyy");
            }

        }

    }
}
