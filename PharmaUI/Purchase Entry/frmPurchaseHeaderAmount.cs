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
           
            int i = 0;

            for (i = 0; i < purchaseBookHeader.PurchaseAmountList.Count; i++)
            {
                Label lbl11 = new Label();
                lbl11.Text = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType;
                lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
                lbl11.Margin = new Padding(3);
                lbl11.AutoSize = true;
                tableLayoutPanel1.Controls.Add(lbl11, 0, i);


                TextBox box11 = new TextBox();
                box11.Text = purchaseBookHeader.PurchaseAmountList[i].Amount.ToString("#.##");
                box11.Name = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType;
                box11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                tableLayoutPanel1.Controls.Add(box11, 1, i);

                Label lbl12 = new Label();
                lbl12.Text = "VAT";
                lbl12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
                lbl12.Margin = new Padding(3);
                lbl12.AutoSize = true;
                tableLayoutPanel1.Controls.Add(lbl12, 2, i);


                TextBox box12 = new TextBox();
                box12.Text = purchaseBookHeader.PurchaseAmountList[i].TaxOnPurchase.ToString("#.##");
                box12.Name = purchaseBookHeader.PurchaseAmountList[i].PurchaseTaxType + "_VAT";
                box12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                tableLayoutPanel1.Controls.Add(box12, 3, i);

                //index = index + 4;
            }

            Label lbl = new Label();
            lbl.Text = "Exempted Amount";
            lbl.AutoSize = true;
            lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl, 0, i);

            TextBox box = new TextBox();
            box.Text = purchaseBookHeader.ExemptedAmount.ToString("#.##");
            box.Name = "txtExemptedAmount";
            box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.Controls.Add(box, 1, i);


            Label lbl1 = new Label();
            lbl1.Text = "Other Amount";
            lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl1, 2, i);

            TextBox box1 = new TextBox();
            box1.Text = purchaseBookHeader.OtherAmount.ToString("#.##");
            box1.Name = "txtOtherAmount";
            box1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.Controls.Add(box1, 3, i);


            Label lbl2 = new Label();
            lbl2.Text = "Invoice Amount";
            lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl2, 0, i + 1);

            TextBox box2 = new TextBox();
            box2.Text = purchaseBookHeader.InvoiceAmount.ToString("#.##");
            box2.Name = "txtInvoiceAmount";
            box2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.Controls.Add(box2, 1, i + 1);
            //tableLayoutPanel1.SetColumnSpan(box2, 2);

            Label lbl3 = new Label();
            lbl3.Text = "Narration 1";
            lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl3, 0, i + 2);

            TextBox box3 = new TextBox();
            box3.Text = purchaseBookHeader.Narration1;
            box3.Name = "txtNarration1";
            box3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.Controls.Add(box3, 1, i + 2);
            tableLayoutPanel1.SetColumnSpan(box3, 3);

            Label lbl4 = new Label();
            lbl4.Text = "Narration 2";
            lbl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl4, 0, i + 3);

            TextBox box4 = new TextBox();
            box4.Text = purchaseBookHeader.Narration1;
            box4.Name = "txtNarration2";
            box4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.Controls.Add(box4, 1, i + 3);
            tableLayoutPanel1.SetColumnSpan(box4, 3);

            Label lbl5 = new Label();
            lbl5.Text = "Amount";
            lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl5, 0, i + 4);

            Label lbl6 = new Label();
            lbl6.Text = purchaseBookHeader.InvoiceAmount.ToString("#.##");            
            lbl6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            tableLayoutPanel1.Controls.Add(lbl6, 1, i + 4);

            //TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
            //foreach (RowStyle style in styles)
            //{
            //    // Set the row height to 20 pixels.
            //    style.SizeType = SizeType.Absolute;
            //    style.Height = 50;
            //}
            //this.Controls.Add(panel);


            tableLayoutPanel1.RowCount = purchaseBookHeader.PurchaseAmountList.Count + 5;

            float rowHeight = (100 / (purchaseBookHeader.PurchaseAmountList.Count + 5));
           
            for (int j = 1; j <= (purchaseBookHeader.PurchaseAmountList.Count + 5); j++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowHeight));
            }

            tableLayoutPanel1.Size = new Size(this.Width - 50, (purchaseBookHeader.PurchaseAmountList.Count + 5) * 30);


        }

        private void frmPurchaseHeaderAmount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Purchase Entry Amount");

            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

            //Fill half Scheme options
            this.FormClosing += FrmPurchaseHeaderAmount_FormClosing;

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

        private void FrmPurchaseHeaderAmount_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var purchaseBookAmount in purchaseBookHeader.PurchaseAmountList)
            {
                var control = tableLayoutPanel1.Controls[purchaseBookAmount.PurchaseTaxType];

                double value = 0L;

                if (control != null)
                {
                    double.TryParse(control.Text, out value);
                    purchaseBookAmount.Amount = value;
                }

                control = tableLayoutPanel1.Controls[purchaseBookAmount.PurchaseTaxType + "_VAT"];
                if (control != null)
                {
                    double.TryParse(control.Text, out value);
                    purchaseBookAmount.TaxOnPurchase = value;
                } 
            }
            double doubleVal = 0L;
            purchaseBookHeader.Narration1 = tableLayoutPanel1.Controls["txtNarration1"].Text;
            purchaseBookHeader.Narration2 = tableLayoutPanel1.Controls["txtNarration2"].Text;
            double.TryParse(tableLayoutPanel1.Controls["txtInvoiceAmount"].Text, out doubleVal);
            purchaseBookHeader.InvoiceAmount = doubleVal;

            double.TryParse(tableLayoutPanel1.Controls["txtOtherAmount"].Text, out doubleVal);
            purchaseBookHeader.OtherAmount = doubleVal;

            double.TryParse(tableLayoutPanel1.Controls["txtExemptedAmount"].Text, out doubleVal);
            purchaseBookHeader.ExemptedAmount = doubleVal;

            applicationFacade.UpdateTempPurchaseHeader(purchaseBookHeader);
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
