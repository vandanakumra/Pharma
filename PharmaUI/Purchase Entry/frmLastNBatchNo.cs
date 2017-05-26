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

        public frmLastNBatchNo()
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmLastNBatchNo_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Last 5 Batch No.");
            List<PharmaBusinessObjects.Transaction.PurchaseBookLineItem> list = applicationFacade.GetLastNBatchNoForSupplierItem(SupplierCode,ItemCode);
            this.FormClosing += FrmLastNBatchNo_FormClosing;
            dgvLastBatch.DataSource = list;

            if (list.Count == 0)
            {
                this.Close();
            }
            else
            {
                dgvLastBatch.CurrentCell = dgvLastBatch.Rows[0].Cells[1];
            }
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
