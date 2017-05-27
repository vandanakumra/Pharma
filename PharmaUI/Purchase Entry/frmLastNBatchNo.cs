using PharmaBusiness;
using PharmaBusinessObjects;
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
    public partial class frmLastNBatchNo : Form
    {
        IApplicationFacade applicationFacade;

        public string SupplierCode { get; set; }
        public string ItemCode { get; set; }
        public string BatchNumber { get; set; }

        private List<PharmaBusinessObjects.Transaction.PurchaseBookLineItem> list;

        public frmLastNBatchNo(List<PharmaBusinessObjects.Transaction.PurchaseBookLineItem> _list)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            list = _list;
        }

        private void frmLastNBatchNo_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Last 5 Batch No.");      
            
            dgvLastBatch.DataSource = list;

            for (int i = 0; i < dgvLastBatch.Columns.Count; i++)
            {
                dgvLastBatch.Columns[i].Visible = false;
            }



            //ItemCode = p.ItemCode,
            //             = p.Rate,
            //             = p.Discount,
            //             = p.SpecialDiscount,
            //            VolumeDiscount = p.VolumeDiscount,
            //            TaxOnPurchase = p.TaxOnPurchase,
            //            PurchaseDate = p.PurchaseBookHeader.PurchaseDate,
            //             = p.BatchNo

            dgvLastBatch.Columns["ItemCode"].Visible = true;
            dgvLastBatch.Columns["ItemCode"].HeaderText = "Item";

            dgvLastBatch.Columns["Rate"].Visible = true;
            dgvLastBatch.Columns["Rate"].HeaderText = "Rate";

            dgvLastBatch.Columns["BatchNumber"].Visible = true;
            dgvLastBatch.Columns["BatchNumber"].HeaderText = "Batch No";


            dgvLastBatch.Columns["Discount"].Visible = true;
            dgvLastBatch.Columns["Discount"].HeaderText = "Discount";


            dgvLastBatch.Columns["SpecialDiscount"].Visible = true;
            dgvLastBatch.Columns["SpecialDiscount"].HeaderText = "Spl Discount";


            dgvLastBatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLastBatch.AllowUserToAddRows = false;
            dgvLastBatch.AllowUserToDeleteRows = false;
            dgvLastBatch.ReadOnly = true;
            dgvLastBatch.KeyDown += DgvLastBatch_KeyDown;

            if (list.Count == 0)
            {
                this.Close();
            }
            else
            {
                dgvLastBatch.Rows[0].Selected = true;
            }


            this.FormClosing += FrmLastNBatchNo_FormClosing;
        }

        private void DgvLastBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
                if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
                else
                    base.OnKeyDown(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FrmLastNBatchNo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvLastBatch.SelectedCells.Count > 0)
            {
                BatchNumber = Convert.ToString(dgvLastBatch.CurrentRow.Cells["BatchNumber"].Value);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
