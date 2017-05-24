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
    public partial class frmPurchaseBookLineItemUpdate : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseBookLineItem purchaseBookLineItem;
        PharmaBusinessObjects.Common.Enums.LineItemUpdateMode updateMode;

        public PurchaseBookLineItem PurchaseBookLinetem { get { return purchaseBookLineItem; } }
        public PharmaBusinessObjects.Common.Enums.LineItemUpdateMode LineItemUpdateMode { get { return updateMode; } }

        public frmPurchaseBookLineItemUpdate(PurchaseBookLineItem lineItem, PharmaBusinessObjects.Common.Enums.LineItemUpdateMode mode)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookLineItem = lineItem;
            updateMode = mode;
        }

        private void frmPurchaseBookLineItemUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, (this.LineItemUpdateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Batch) ? "Batch - Update" : (this.LineItemUpdateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Discount) ? "Discount - Update" : "Scheme Update");

            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);
            FillFormForUpdate();

        }

        private void FillFormForUpdate()
        {

            if (updateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Scheme)
            {
                tblMain.RowStyles[1].Height = 0;
                tblMain.RowStyles[2].Height = 0;
                if (purchaseBookLineItem != null)
                {
                    txtScheme1.Text = Convert.ToString(purchaseBookLineItem.Scheme1);
                    txtScheme2.Text = Convert.ToString(purchaseBookLineItem.Scheme1);
                    chkIsHalfScheme.Checked = purchaseBookLineItem.IsHalfScheme;
                }
            }

            if (updateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Discount)
            {
                tblMain.RowStyles[0].Height = 0;
                tblMain.RowStyles[2].Height = 0;
                if (purchaseBookLineItem != null)
                {
                    txtDiscount.Text = Convert.ToString(purchaseBookLineItem.Discount);
                    txtSpecialDiscount.Text = Convert.ToString(purchaseBookLineItem.SpecialDiscount);
                    txtVolDiscount.Text = Convert.ToString(purchaseBookLineItem.VolumeDiscount);
                    txtMRP.Text = Convert.ToString(purchaseBookLineItem.MRP);
                    txtExcise.Text = Convert.ToString(purchaseBookLineItem.Excise);
                    dtExpiry.Value = purchaseBookLineItem.Expiry == DateTime.MinValue ? dtExpiry.MinDate : purchaseBookLineItem.Expiry;
                }
            }

            if (updateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Batch)
            {
                tblMain.RowStyles[0].Height = 0;
                tblMain.RowStyles[1].Height = 0;
                if (purchaseBookLineItem != null)
                {
                    //txtDiscount.Text = Convert.ToString(purchaseBookLineItem.Discount);
                    //txtSpecialDiscount.Text = Convert.ToString(purchaseBookLineItem.SpecialDiscount);
                    //txtVolDiscount.Text = Convert.ToString(purchaseBookLineItem.VolumeDiscount);
                    //txtMRP.Text = Convert.ToString(purchaseBookLineItem.MRP);
                    //txtExcise.Text = Convert.ToString(purchaseBookLineItem.Excise);
                    //dtExpiry.Value = Convert.ToDateTime(purchaseBookLineItem.Expiry);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmPurchaseBookLineItemUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Scheme)
            {
                if (purchaseBookLineItem != null)
                {
                    int id = 0;
                    Int32.TryParse(txtScheme1.Text, out id);
                    purchaseBookLineItem.Scheme1 = id;

                    Int32.TryParse(txtScheme2.Text, out id);
                    purchaseBookLineItem.Scheme2 = id;
                    purchaseBookLineItem.IsHalfScheme = chkIsHalfScheme.Checked;
                }
            }

            if (updateMode == PharmaBusinessObjects.Common.Enums.LineItemUpdateMode.Discount)
            {
                if (purchaseBookLineItem != null)
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

                    purchaseBookLineItem.Expiry = dtExpiry.Value.Date;
                }
            }
        }

    }
}
