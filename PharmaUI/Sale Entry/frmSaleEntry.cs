using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
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
    public partial class frmSaleEntry : Form
    {
        private bool IsModify = false;
        private bool isDirty = false;
        private int saleBookHeaderID = 0;
        private bool isBatchUpdate = false;

        IApplicationFacade applicationFacade;
        private PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
        private PurchaseSaleBookLineItem lineItem = new PurchaseSaleBookLineItem();

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

            dgvLineItem.Columns.Add("PurchaseRate", "PurchaseRate");
            dgvLineItem.Columns["PurchaseRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseRate"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("SaleTypeCode", "SaleTypeCode");
            dgvLineItem.Columns["SaleTypeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleTypeCode"].Visible = false;

            
            dgvLineItem.Columns.Add("Discount", "Discount");
            dgvLineItem.Columns["Discount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Discount"].Visible = false;
            
            //dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            //dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            //dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
            //dgvLineItem.EditingControlShowing += DgvLineItem_EditingControlShowing;
            //dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged;
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
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Quantity"];
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertUpdateLineItemAndsetToGrid(PurchaseSaleBookLineItem lineItem) //,int srno, bool setSrNo = false)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvLineItem.SelectedCells.Count > 0)
            {
                rowIndex = dgvLineItem.SelectedCells[0].RowIndex;
                colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;

                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value = lineItem.PurchaseSaleBookLineItemID;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value = header.PurchaseSaleBookHeaderID;
                dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItem.ItemCode;
                dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItem.ItemName;
                dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItem.Quantity;
                dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItem.FreeQuantity;
                dgvLineItem.Rows[rowIndex].Cells["Batch"].Value = lineItem.Batch;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value = lineItem.PurchaseSaleRate;
                //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleRate"].Value = lineItem.OldPurchaseSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount();
                //dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                //dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                //dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                //dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                //dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                //dgvLineItem.Rows[rowIndex].Cells["ExpiryDate"].Value = lineItem.ExpiryDate;
                dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItem.SaleRate;
                dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItem.SpecialRate;
                dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItem.WholeSaleRate;
                //dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTypeCode"].Value = lineItem.PurchaseSaleTypeCode;
                //dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTax"].Value = lineItem.PurchaseSaleTax;
                //dgvLineItem.Rows[rowIndex].Cells["LocalCentral"].Value = lineItem.LocalCentral;
                //dgvLineItem.Rows[rowIndex].Cells["UsedQuantity"].Value = lineItem.UsedQuantity;
                //dgvLineItem.Rows[rowIndex].Cells["BalanceQuantity"].Value = lineItem.BalanceQuantity;
                //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleBookLineItemID"].Value = lineItem.OldPurchaseSaleBookLineItemID;
                dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value = lineItem.FifoID;

                
            }
        }

        private double GetLineItemAmount()
        {
            double dQty = 0;
            double.TryParse(Convert.ToString(dgvLineItem.CurrentRow.Cells["Quantity"].Value), out dQty);

            double dSaleRate = 0;
            double.TryParse(Convert.ToString(dgvLineItem.CurrentRow.Cells["SaleRate"].Value), out dSaleRate);

            return dQty * dSaleRate;

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
                item.PurchaseSaleBookHeaderID = id == 0 ? header.PurchaseSaleBookHeaderID : lineItem.PurchaseSaleBookHeaderID;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.Batch = Convert.ToString(row.Cells["Batch"].Value);

                double.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out dValue);
                item.Quantity = dValue;

                double.TryParse(Convert.ToString(row.Cells["FreeQuantity"].Value), out dValue);
                item.FreeQuantity = dValue;

                double.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;

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

                double.TryParse(Convert.ToString(row.Cells["PurchaseRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                int.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;

            }

            return item;
        }

    }
}
