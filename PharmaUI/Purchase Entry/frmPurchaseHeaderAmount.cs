using PharmaBusinessObjects;
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
using static PharmaBusinessObjects.Common.Constants;

namespace PharmaUI
{
    
    public partial class frmPurchaseHeaderAmount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookHeader purchaseBookHeader;
        bool isDirty = false;

        public PurchaseSaleBookHeader PurchaseBookHeader { get { return purchaseBookHeader; } }

        public frmPurchaseHeaderAmount(PurchaseSaleBookHeader header)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookHeader = header;

        }

        private void frmPurchaseHeaderAmount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Header Amount Update"));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);

            FillFormForUpdate();

            txtAmount1.Focus();

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
            if (e.KeyCode == Keys.Enter)
            {
                Control ctl = sender as Control;

                if (ctl.Name == "txtTotalBillAmount")
                {
                    this.Close();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

        private void FrmPurchaseHeaderAmount_FormClosing(object sender, FormClosingEventArgs e)
        {
            double amount = 0;
            double.TryParse(txtAmount1.Text, out amount);

            purchaseBookHeader.Amount01 = amount;

            double.TryParse(txtAmount2.Text, out amount);
            purchaseBookHeader.Amount02 = amount;

            double.TryParse(txtAmount3.Text, out amount);
            purchaseBookHeader.Amount03 = amount;

            double.TryParse(txtAmount4.Text, out amount);
            purchaseBookHeader.Amount04 = amount;

            double.TryParse(txtAmount5.Text, out amount);
            purchaseBookHeader.Amount05 = amount;

            double.TryParse(txtAmount6.Text, out amount);
            purchaseBookHeader.Amount06 = amount;

            double.TryParse(txtAmount7.Text, out amount);
            purchaseBookHeader.Amount07 = amount;

            double.TryParse(txtIGST1.Text, out amount);
            purchaseBookHeader.IGST01 = amount;

            double.TryParse(txtIGST2.Text, out amount);
            purchaseBookHeader.IGST02 = amount;

            double.TryParse(txtIGST3.Text, out amount);
            purchaseBookHeader.IGST03 = amount;

            double.TryParse(txtIGST4.Text, out amount);
            purchaseBookHeader.IGST04 = amount;

            double.TryParse(txtIGST5.Text, out amount);
            purchaseBookHeader.IGST05 = amount;

            double.TryParse(txtIGST6.Text, out amount);
            purchaseBookHeader.IGST06 = amount;

            double.TryParse(txtIGST7.Text, out amount);
            purchaseBookHeader.IGST07 = amount;

            double.TryParse(txtSGST1.Text, out amount);
            purchaseBookHeader.SGST01 = amount;

            double.TryParse(txtSGST2.Text, out amount);
            purchaseBookHeader.SGST02 = amount;

            double.TryParse(txtSGST3.Text, out amount);
            purchaseBookHeader.SGST03 = amount;

            double.TryParse(txtSGST4.Text, out amount);
            purchaseBookHeader.SGST04 = amount;

            double.TryParse(txtSGST5.Text, out amount);
            purchaseBookHeader.SGST05 = amount;

            double.TryParse(txtSGST6.Text, out amount);
            purchaseBookHeader.SGST06 = amount;

            double.TryParse(txtSGST7.Text, out amount);
            purchaseBookHeader.SGST07 = amount;

            double.TryParse(txtOtherAmt.Text, out amount);
            purchaseBookHeader.OtherAmount = amount;

            double.TryParse(txtTotalBillAmount.Text, out amount);
            purchaseBookHeader.TotalBillAmount = amount;

            applicationFacade.InsertUpdateTempPurchaseBookHeader(purchaseBookHeader);

        }

        private void FillFormForUpdate()
        {
            List<PurchaseBookAmount> amountList = applicationFacade.GetFinalAmountWithTaxForPurchase(purchaseBookHeader.PurchaseSaleBookHeaderID);

            PurchaseBookAmount amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType1);

            if (amount != null)
            {
                lblAmount1.Text = amount.PurchaseSaleTypeName;
                txtAmount1.Text = amount.Amount.ToString("#.##");
                txtAmount1.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST1.Text = amount.IGST.ToString("#.##");
                txtSGST1.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType2);

            if (amount != null)
            {
                lblAmount2.Text = amount.PurchaseSaleTypeName;
                txtAmount2.Text = amount.Amount.ToString("#.##");
                txtAmount2.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST2.Text = amount.IGST.ToString("#.##");
                txtSGST2.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType3);

            if (amount != null)
            {
                lblAmount3.Text = amount.PurchaseSaleTypeName;
                txtAmount3.Text = amount.Amount.ToString("#.##");
                txtAmount3.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST3.Text = amount.IGST.ToString("#.##");
                txtSGST3.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType4);

            if (amount != null)
            {
                lblAmount4.Text = amount.PurchaseSaleTypeName;
                txtAmount4.Text = amount.Amount.ToString("#.##");
                txtAmount4.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST4.Text = amount.IGST.ToString("#.##");
                txtSGST4.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType5);

            if (amount != null)
            {
                lblAmount5.Text = amount.PurchaseSaleTypeName;
                txtAmount5.Text = amount.Amount.ToString("#.##");
                txtAmount5.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST5.Text = amount.IGST.ToString("#.##");
                txtSGST5.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType6);

            if (amount != null)
            {
                lblAmount6.Text = amount.PurchaseSaleTypeName;
                txtAmount6.Text = amount.Amount.ToString("#.##");
                txtAmount6.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST6.Text = amount.IGST.ToString("#.##");
                txtSGST6.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType7);

            if (amount != null)
            {
                lblAmount7.Text = amount.PurchaseSaleTypeName;
                txtAmount7.Text = amount.Amount.ToString("#.##");
                txtAmount7.Tag = amount.TaxApplicable.ToString("#.##");
                txtIGST7.Text = amount.IGST.ToString("#.##");
                txtSGST7.Text = amount.SGST.ToString("#.##");
            }

            SetTotalBillAmount();
        }

        private void SetTotalBillAmount()
        {
            double amount1 = 0;
            Double.TryParse(txtAmount1.Text, out amount1);

            double amount2 = 0;
            Double.TryParse(txtAmount2.Text, out amount2);

            double amount3 = 0;
            Double.TryParse(txtAmount3.Text, out amount3);

            double amount4 = 0;
            Double.TryParse(txtAmount4.Text, out amount4);

            double amount5 = 0;
            Double.TryParse(txtAmount5.Text, out amount5);

            double amount6 = 0;
            Double.TryParse(txtAmount6.Text, out amount6);

            double amount7 = 0;
            Double.TryParse(txtAmount7.Text, out amount7);

            double igst1 = 0;
            Double.TryParse(txtIGST1.Text, out igst1);

            double igst2 = 0;
            Double.TryParse(txtIGST2.Text, out igst2);

            double igst3 = 0;
            Double.TryParse(txtIGST3.Text, out igst3);

            double igst4 = 0;
            Double.TryParse(txtIGST4.Text, out igst4);

            double igst5 = 0;
            Double.TryParse(txtIGST5.Text, out igst5);

            double igst6 = 0;
            Double.TryParse(txtIGST6.Text, out igst6);

            double igst7 = 0;
            Double.TryParse(txtIGST7.Text, out igst7);

            double sgst1 = 0;
            Double.TryParse(txtSGST1.Text, out sgst1);

            double sgst2 = 0;
            Double.TryParse(txtSGST2.Text, out sgst2);

            double sgst3 = 0;
            Double.TryParse(txtSGST3.Text, out sgst3);

            double sgst4 = 0;
            Double.TryParse(txtSGST4.Text, out sgst4);

            double sgst5 = 0;
            Double.TryParse(txtSGST5.Text, out sgst5);

            double sgst6 = 0;
            Double.TryParse(txtSGST6.Text, out sgst6);

            double sgst7 = 0;
            Double.TryParse(txtSGST7.Text, out sgst7);

            double otherAmount = 0;
            Double.TryParse(txtOtherAmt.Text, out otherAmount);

            txtTotalBillAmount.Text = (amount1 + amount2 + amount3 + amount4 + amount5 + amount6 + amount7 + igst1 + igst2 + igst3
                + igst3 + igst4 + igst5 + igst6 + igst7 + sgst1 + sgst2 + sgst3 + sgst4 + sgst5 + sgst6 + sgst7).ToString("#.##");
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
                        tb1.Leave += Tb1_Leave;
                        tb1.TextChanged += Tb1_TextChanged;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void Tb1_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            double tax = 0;

            double.TryParse(Convert.ToString(txt.Tag), out tax);

            double amount = 0;
            double.TryParse(txt.Text, out amount);

            if (isDirty)
            {
                switch (txt.Name)
                {
                    case "txtAmount1":
                        {
                            txtIGST1.Text = tax == 0L ? "0.00" : (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST1.Text = tax == 0L ? "0.00" : (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount2":
                        {
                            txtIGST2.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST2.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount3":
                        {
                            txtIGST3.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST3.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount4":
                        {
                            txtIGST4.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST4.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount5":
                        {
                            txtIGST5.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST5.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount6":
                        {
                            txtIGST6.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST6.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount7":
                        {
                            txtIGST7.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                            txtSGST7.Text = (amount * tax * .01 * 0.5).ToString("#.##");
                        }
                        break;
                }

                if (txt.Name != "txtTotalBillAmount")
                {
                    SetTotalBillAmount();
                }
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
