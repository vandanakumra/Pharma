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
            //FillFormForUpdate();

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
    }
}
