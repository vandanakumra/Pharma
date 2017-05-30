﻿using PharmaBusinessObjects;
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
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmLineItemDiscount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookLineItem purchaseBookLineItem;

        public PurchaseSaleBookLineItem PurchaseBookLinetem { get { return purchaseBookLineItem; } }

        public frmLineItemDiscount(PurchaseSaleBookLineItem lineItem)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookLineItem = lineItem;
        }

        private void frmLineItemDiscount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Item {0} {1}", purchaseBookLineItem.ItemCode, purchaseBookLineItem.ItemName));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);

            //Fill half Scheme options
            cbxNewRate.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxNewRate.SelectedItem = Choice.No;

            FillFormForUpdate();

        }

        private void FillFormForUpdate()
        {
            dtLIDate.Value = purchaseBookLineItem.PurchaseBillDate == (DateTime) DateTime.MinValue ? dtLIDate.MinDate : (DateTime)purchaseBookLineItem.PurchaseBillDate;
           // txtExcise.Text = Convert.ToString(purchaseBookLineItem.Excise);
            txtSpecialRate.Text = Convert.ToString(purchaseBookLineItem.SpecialRate);
            txtWholeSaleRate.Text = Convert.ToString(purchaseBookLineItem.WholeSaleRate);
            txtSaleRate.Text = Convert.ToString(purchaseBookLineItem.SaleRate);
            txtMRP.Text = Convert.ToString(purchaseBookLineItem.MRP);
            txtSpecialDiscount.Text = Convert.ToString(purchaseBookLineItem.SpecialDiscount);
            txtDiscount.Text = Convert.ToString(purchaseBookLineItem.Discount);
            txtVolDiscount.Text = Convert.ToString(purchaseBookLineItem.VolumeDiscount);
           // dtLIDate.Value = purchaseBookLineItem.PurchaseDate == DateTime.MinValue ? dtLIDate.MinDate : purchaseBookLineItem.PurchaseDate;
            dtExpiry.Value = purchaseBookLineItem.ExpiryDate == DateTime.MinValue ? (DateTime)dtExpiry.MinDate : (DateTime)purchaseBookLineItem.ExpiryDate;           
           // cbxNewRate.SelectedItem = purchaseBookLineItem.IsNewRate ? Choice.Yes : Choice.No;
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

        private void frmLineItemDiscount_FormClosing(object sender, FormClosingEventArgs e)
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

            //double.TryParse(txtExcise.Text, out value);
            //purchaseBookLineItem.Excise = value;

            double.TryParse(txtSaleRate.Text, out value);
            purchaseBookLineItem.SaleRate = value;

            double.TryParse(txtSpecialRate.Text, out value);
            purchaseBookLineItem.SpecialRate = value;

            double.TryParse(txtWholeSaleRate.Text, out value);
            purchaseBookLineItem.WholeSaleRate = value;

            Choice choice;
            Enum.TryParse<Choice>(cbxNewRate.SelectedValue.ToString(), out choice);

           // purchaseBookLineItem.IsNewRate = choice == Choice.Yes;

            purchaseBookLineItem.ExpiryDate = dtExpiry.Value.Date == dtExpiry.MinDate ? DateTime.MinValue : dtExpiry.Value.Date;
            purchaseBookLineItem.PurchaseBillDate = dtLIDate.Value.Date == dtLIDate.MinDate ? DateTime.MinValue : dtLIDate.Value.Date;
        }

        private void tblDiscount_Paint(object sender, PaintEventArgs e)
        {

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
