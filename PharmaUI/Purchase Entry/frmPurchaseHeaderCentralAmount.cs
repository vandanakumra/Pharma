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
    public partial class frmPurchaseHeaderCentralAmount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookHeader purchaseBookHeader;
        bool isDirty = false;

        public PurchaseSaleBookHeader PurchaseBookHeader { get { return purchaseBookHeader; } }

        public frmPurchaseHeaderCentralAmount(PurchaseSaleBookHeader header)
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
            decimal amount = 0;
            decimal.TryParse(txtAmount1.Text, out amount);

            purchaseBookHeader.Amount01 = amount;

            decimal.TryParse(txtAmount2.Text, out amount);
            purchaseBookHeader.Amount02 = amount;

            decimal.TryParse(txtAmount3.Text, out amount);
            purchaseBookHeader.Amount03 = amount;

            decimal.TryParse(txtAmount4.Text, out amount);
            purchaseBookHeader.Amount04 = amount;

            decimal.TryParse(txtAmount5.Text, out amount);
            purchaseBookHeader.Amount05 = amount;

            decimal.TryParse(txtAmount6.Text, out amount);
            purchaseBookHeader.Amount06 = amount;

            decimal.TryParse(txtAmount7.Text, out amount);
            purchaseBookHeader.Amount07 = amount;

            decimal.TryParse(txtCGST1.Text, out amount);
            purchaseBookHeader.CGST01 = amount;

            decimal.TryParse(txtCGST2.Text, out amount);
            purchaseBookHeader.CGST02 = amount;

            decimal.TryParse(txtCGST3.Text, out amount);
            purchaseBookHeader.CGST03 = amount;

            decimal.TryParse(txtCGST4.Text, out amount);
            purchaseBookHeader.CGST04 = amount;

            decimal.TryParse(txtCGST5.Text, out amount);
            purchaseBookHeader.CGST05 = amount;

            decimal.TryParse(txtCGST6.Text, out amount);
            purchaseBookHeader.CGST06 = amount;

            decimal.TryParse(txtCGST7.Text, out amount);
            purchaseBookHeader.CGST07 = amount;

            decimal.TryParse(txtOtherAmt.Text, out amount);
            purchaseBookHeader.OtherAmount = amount;

            decimal.TryParse(txtTotalBillAmount.Text, out amount);
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
                txtCGST1.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType2);

            if (amount != null)
            {
                lblAmount2.Text = amount.PurchaseSaleTypeName;
                txtAmount2.Text = amount.Amount.ToString("#.##");
                txtAmount2.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST2.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType3);

            if (amount != null)
            {
                lblAmount3.Text = amount.PurchaseSaleTypeName;
                txtAmount3.Text = amount.Amount.ToString("#.##");
                txtAmount3.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST3.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType4);

            if (amount != null)
            {
                lblAmount4.Text = amount.PurchaseSaleTypeName;
                txtAmount4.Text = amount.Amount.ToString("#.##");
                txtAmount4.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST4.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType5);

            if (amount != null)
            {
                lblAmount5.Text = amount.PurchaseSaleTypeName;
                txtAmount5.Text = amount.Amount.ToString("#.##");
                txtAmount5.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST5.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType6);

            if (amount != null)
            {
                lblAmount6.Text = amount.PurchaseSaleTypeName;
                txtAmount6.Text = amount.Amount.ToString("#.##");
                txtAmount6.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST6.Text = amount.CGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType7);

            if (amount != null)
            {
                lblAmount7.Text = amount.PurchaseSaleTypeName;
                txtAmount7.Text = amount.Amount.ToString("#.##");
                txtAmount7.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST7.Text = amount.CGST.ToString("#.##");
            }

            SetTotalBillAmount();
        }

        private void SetTotalBillAmount()
        {
            decimal amount1 = 0;
            decimal.TryParse(txtAmount1.Text, out amount1);

            decimal amount2 = 0;
            decimal.TryParse(txtAmount2.Text, out amount2);

            decimal amount3 = 0;
            decimal.TryParse(txtAmount3.Text, out amount3);

            decimal amount4 = 0;
            decimal.TryParse(txtAmount4.Text, out amount4);

            decimal amount5 = 0;
            decimal.TryParse(txtAmount5.Text, out amount5);

            decimal amount6 = 0;
            decimal.TryParse(txtAmount6.Text, out amount6);

            decimal amount7 = 0;
            decimal.TryParse(txtAmount7.Text, out amount7);

            decimal cgst1 = 0;
            decimal.TryParse(txtCGST1.Text, out cgst1);

            decimal cgst2 = 0;
            decimal.TryParse(txtCGST2.Text, out cgst2);

            decimal cgst3 = 0;
            decimal.TryParse(txtCGST3.Text, out cgst3);

            decimal cgst4 = 0;
            decimal.TryParse(txtCGST4.Text, out cgst4);

            decimal cgst5 = 0;
            decimal.TryParse(txtCGST5.Text, out cgst5);

            decimal cgst6 = 0;
            decimal.TryParse(txtCGST6.Text, out cgst6);

            decimal cgst7 = 0;
            decimal.TryParse(txtCGST7.Text, out cgst7);

            decimal otherAmount = 0;
            decimal.TryParse(txtOtherAmt.Text, out otherAmount);

            txtTotalBillAmount.Text = (amount1 + amount2 + amount3 + amount4 + amount5 + amount6 + amount7 + cgst1 + cgst2 + cgst3
                + cgst3 + cgst4 + cgst5 + cgst6 + cgst7 + otherAmount).ToString("#.##");
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

            decimal tax = 0;
            decimal.TryParse(Convert.ToString(txt.Tag), out tax);

            decimal amount = 0;
            decimal.TryParse(txt.Text, out amount);

            if (isDirty)
            {
                switch (txt.Name)
                {
                    case "txtAmount1":
                        {
                            txtCGST1.Text = amount != 0L && tax == 0L ? "0.00" : (amount * tax * (decimal)0.01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount2":
                        {
                            txtCGST2.Text = (amount * tax * (decimal).01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount3":
                        {
                            txtCGST3.Text = (amount * tax * (decimal).01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount4":
                        {
                            txtCGST4.Text = (amount * tax * (decimal).01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount5":
                        {
                            txtCGST5.Text = (amount * tax * (decimal).01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount6":
                        {
                            txtCGST6.Text = (amount * tax * (decimal).01 ).ToString("#.##");
                        }
                        break;
                    case "txtAmount7":
                        {
                            txtCGST7.Text = (amount * tax * (decimal).01 ).ToString("#.##");
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

    }
}
