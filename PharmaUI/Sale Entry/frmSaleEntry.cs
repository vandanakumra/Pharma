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

namespace PharmaUI.Sale_Entry
{
    public partial class frmSaleEntry : Form
    {
        private bool IsModify = false;
        private bool isDirty = false;
        private int saleBookHeaderID = 0;

        IApplicationFacade applicationFacade;
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

            dgvLineItem.Columns.Add("PurchaseSaleRate", "Rate");
            dgvLineItem.Columns["PurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleRate"].FillWeight = 5;

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
                                    PharmaBusinessObjects.Master.CustomerLedgerMaster master = applicationFacade.GetCustomerLedgerByName(txtCustomerCode.Text);

                                    if (master == null)
                                    {
                                        lblCustomerName.Text = "**No Such Code**";
                                        txtCustomerCode.Focus();
                                    }
                                    else
                                    {
                                        lblCustomerName.Text = master.CustomerLedgerName;

                                        if (saleBookHeaderID > 0)
                                        {
                                            PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                                            /*bool result = GetPurchaseBookHeader(ref header);

                                            if (result)
                                            {
                                                applicationFacade.InsertUpdateTempPurchaseBookHeader(header);

                                            }*/
                                        }
                                    }
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
                    lblCustomerName.Text = ledger.LastSelectedCustomerLedger.CustomerLedgerName;
                    txtCustomerCode.Text = ledger.LastSelectedCustomerLedger.CustomerLedgerCode;
                    lblSaleManName.Text = ledger.LastSelectedCustomerLedger.SalesmanName;
                    //TODO
                    txtSalesManCode.Text = ledger.LastSelectedCustomerLedger.SalesManId.ToString();

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
    }
}
