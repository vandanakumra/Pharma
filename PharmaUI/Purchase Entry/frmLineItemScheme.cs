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

namespace PharmaUI.Purchase_Entry
{
    public partial class frmLineItemScheme : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseBookLineItem purchaseBookLineItem;

        public PurchaseBookLineItem PurchaseBookLinetem { get { return purchaseBookLineItem; } }

        public frmLineItemScheme(PurchaseBookLineItem lineItem)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookLineItem = lineItem;
        }

        private void frmLineItemScheme_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Item - {0} Update",purchaseBookLineItem.ItemName));

            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);
            FillFormForUpdate();

        }

        private void FillFormForUpdate()
        {
            if (purchaseBookLineItem != null)
            {
                txtScheme1.Text = Convert.ToString(purchaseBookLineItem.Scheme1);
                txtScheme2.Text = Convert.ToString(purchaseBookLineItem.Scheme1);
                chkIsHalfScheme.Checked = purchaseBookLineItem.IsHalfScheme;
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


    }
}
