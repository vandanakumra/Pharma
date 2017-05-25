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
    
    public partial class frmPurchaseHeaderAmount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseBookHeader purchaseBookHeader;

        public PurchaseBookHeader PurchaseBookHeader { get { return purchaseBookHeader; } }

        public frmPurchaseHeaderAmount(PurchaseBookHeader header)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);

            purchaseBookHeader = applicationFacade.GetFinalAmountWithTaxForPurchase(header.InvoiceID);
            purchaseBookHeader.InvoiceNumber = header.InvoiceNumber;
            purchaseBookHeader.PurchaseDate = header.PurchaseDate;
            purchaseBookHeader.PurchaseFormTypeID = header.PurchaseFormTypeID;
            purchaseBookHeader.SupplierCode = header.SupplierCode;

            //TableLayoutPanel panel = new TableLayoutPanel();
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.Location = new Point(0, 60);
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = purchaseBookHeader.PurchaseAmountList.Count + 5;
            tableLayoutPanel1.Size = new Size(this.Width, this.Height);

            int i = 0;
            for (i = 0; i < purchaseBookHeader.PurchaseAmountList.Count; i++)
            {
                Label lbl11 = new Label();
                lbl11.Text = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType;
                lbl11.Anchor = AnchorStyles.Left;
                tableLayoutPanel1.Controls.Add(lbl11, 0, i);

                TextBox box11 = new TextBox();
                box11.Text = purchaseBookHeader.PurchaseAmountList[i].Amount.ToString("#.##");
                box11.Name = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType;
                tableLayoutPanel1.Controls.Add(box11, 1, i);

                Label lbl12 = new Label();
                lbl12.Text = "VAT";
                lbl12.Anchor = AnchorStyles.Left;
                tableLayoutPanel1.Controls.Add(lbl12, 2, i);

                TextBox box12 = new TextBox();
                box12.Text = purchaseBookHeader.PurchaseAmountList[i].TaxOnPurchase.ToString("#.##");
                box12.Name = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType + "_VAT";
                tableLayoutPanel1.Controls.Add(box12, 3, i);

                //index = index + 4;
            }

            Label lbl = new Label();
            lbl.Text = "Exempted Amount";
            lbl.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl,0, i);

            TextBox box = new TextBox();
            box.Text = purchaseBookHeader.ExemptedAmount.ToString("#.##");
            box.Name = "txtExemptedAmount";
            tableLayoutPanel1.Controls.Add(box, 1, i);
            

            Label lbl1 = new Label();
            lbl1.Text = "Other Amount";
            lbl1.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl1, 2, i);

            TextBox box1 = new TextBox();
            box1.Text = purchaseBookHeader.OtherAmount.ToString("#.##");
            box1.Name = "txtOtherAmount";
            tableLayoutPanel1.Controls.Add(box1, 3, i);
           

            Label lbl2 = new Label();
            lbl2.Text = "Invoice Amount";
            lbl2.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl2, 0, i+1);

            TextBox box2 = new TextBox();
            box2.Text = purchaseBookHeader.InvoiceAmount.ToString("#.##");
            box2.Name = "txtInvoiceAmount";
            tableLayoutPanel1.Controls.Add(box2, 1, i+1);
            tableLayoutPanel1.SetColumnSpan(box2, 2);

            Label lbl3 = new Label();
            lbl3.Text = "Narration";
            lbl3.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl3, 0 , i + 2);

            TextBox box3 = new TextBox();
            box3.Text = purchaseBookHeader.Narration1;
            box3.Name = "txtNarration1";
            box3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.Controls.Add(box3, 1, i+2);
            tableLayoutPanel1.SetColumnSpan(box3, 3);

            Label lbl4 = new Label();
            lbl4.Text = "Narration";
            lbl4.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl4, 0,i+3);

            TextBox box4 = new TextBox();
            box4.Text = purchaseBookHeader.Narration1;
            box4.Name = "txtNarration2";
            box4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.Controls.Add(box4, 1,i+3);
            tableLayoutPanel1.SetColumnSpan(box4, 3);

            Label lbl5 = new Label();
            lbl5.Text = "Amount";
            lbl5.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl5, 0,i+4);

            Label lbl6 = new Label();
            lbl6.Text = purchaseBookHeader.InvoiceAmount.ToString("#.##");
            lbl6.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.Controls.Add(lbl6, 1, i + 4);

            TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
            foreach (RowStyle style in styles)
            {
                // Set the row height to 20 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 50;
            }
            //this.Controls.Add(panel);
        }
        private void frmPurchaseHeaderAmount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Purchase Entry Amount");

            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

            //Fill half Scheme options
            FillFormForUpdate();

            string controlName = purchaseBookHeader.PurchaseAmountList.Select(p => p.PurchaseTaxType).FirstOrDefault();

            if (string.IsNullOrEmpty(controlName))
            {
                controlName = "txtExemptedAmount";
            }
            TextBox box = ((TextBox)tableLayoutPanel1.Controls["TxtBox1"]);
            if (box != null)
            {
                box.Focus();
            }

        }

        private void FillFormForUpdate()
        {
            
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
