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

namespace PharmaUI
{
    public partial class frmLineItemBriefDiscount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseBookLineItem purchaseBookLineItem;

        public PurchaseBookLineItem PurchaseBookLinetem { get { return purchaseBookLineItem; } }

        public frmLineItemBriefDiscount(PurchaseBookLineItem lineItem)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookLineItem = lineItem;
        }


        private void frmLineItemBriefDiscount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Item {0} {1}", purchaseBookLineItem.ItemCode, purchaseBookLineItem.ItemName));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);
            FillFormForUpdate();

            txtDiscount.Focus();

        }

        private void FillFormForUpdate()
        {
            txtExcise.Text = Convert.ToString(purchaseBookLineItem.Excise);
            txtMRP.Text = Convert.ToString(purchaseBookLineItem.MRP);
            txtSpecialDiscount.Text = Convert.ToString(purchaseBookLineItem.SpecialDiscount);
            txtDiscount.Text = Convert.ToString(purchaseBookLineItem.Discount);
            txtVolDiscount.Text = Convert.ToString(purchaseBookLineItem.VolumeDiscount);
            dtExpiry.Value = purchaseBookLineItem.Expiry == DateTime.MinValue ? dtExpiry.MinDate : purchaseBookLineItem.Expiry;
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
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }


        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape || keyData == Keys.End)
        //    {
        //        this.Close();

        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void frmPurchaseBookLineItemUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            double value = 0L;
            double.TryParse(txtDiscount.Text, out value);
            purchaseBookLineItem.Discount = value;

            double.TryParse(txtSpecialDiscount.Text, out value);
            purchaseBookLineItem.SpecialDiscount = value;

            double.TryParse(txtVolDiscount.Text, out value);
            purchaseBookLineItem.VolumeDiscount = value;

            double.TryParse(txtMRP.Text, out value);
            purchaseBookLineItem.MRP = value;

            double.TryParse(txtExcise.Text, out value);
            purchaseBookLineItem.Excise = value;

            purchaseBookLineItem.Expiry = dtExpiry.Value.Date == dtExpiry.MinDate ? DateTime.MinValue : dtExpiry.Value.Date;
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
                if (ctl.Name == "dtExpiry")
                {
                    this.Close();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

    }
}
