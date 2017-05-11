using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Common;
namespace PharmaUI
{
    public partial class frmItemMaster : Form
    {
        IApplicationFacade applicationFacade;
        public frmItemMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Item Master");

            //splitContainerItemMaster.Dock = DockStyle.Fill;

            LoadDataGrid();

            dgvItemList.CellDoubleClick += DgvItemList_CellDoubleClick;
            dgvItemList.KeyDown += DgvCompanyList_KeyDown;
            dgvItemList.SelectionChanged += DgvItemList_SelectionChanged;
        }

        private void DgvItemList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItemList.SelectedRows.Count > 0)
            {
                ItemMaster selectedItem = (ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;
                //Display selected Item data
                lblItemNameVal.Text = selectedItem.ItemName;
                lblComanyCodeVal.Text = selectedItem.CompanyCode;
                lblPackingVal.Text = selectedItem.Packing;
                lblPurchaseRateVal.Text = Convert.ToString(selectedItem.PurchaseRate);
                lblMRPVal.Text = Convert.ToString(selectedItem.MRP);
                lblSaleRateVal.Text = Convert.ToString(selectedItem.SaleRate);
                lblSpecialRateVal.Text = Convert.ToString(selectedItem.SpecialRate);
                lblTaxOnSaleVal.Text = Convert.ToString(selectedItem.TaxOnSale);
                lblUPCVal.Text = selectedItem.UPC;
                lblMaxQtyVal.Text = Convert.ToString(selectedItem.MaximumQty);
            }
        }

        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmItemMasterAddUpdate form = new frmItemMasterAddUpdate(true);
                ItemMaster existingItem = (ItemMaster)dgvItemList.CurrentRow.DataBoundItem;
                form.frmItemMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmItemMasterAddUpdate();
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dgvItemList.DataSource = applicationFacade.GetAllItemsBySearch(txtSearch.Text);

            for (int i = 0; i < dgvItemList.Columns.Count; i++)
            {
                dgvItemList.Columns[i].Visible = false;
            }

            dgvItemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItemList.AllowUserToAddRows = false;
            dgvItemList.AllowUserToDeleteRows = false;
            dgvItemList.ReadOnly = true;

            dgvItemList.Columns["ItemCode"].Visible = true;
            dgvItemList.Columns["ItemName"].Visible = true;
            dgvItemList.Columns["CompanyCode"].Visible = true;
            dgvItemList.Columns["ShortName"].Visible = true;
            dgvItemList.Columns["MRP"].Visible = true;
            dgvItemList.Columns["Packing"].Visible = true;
            dgvItemList.Columns["SaleRate"].Visible = true;
            dgvItemList.Columns["Scheme1"].Visible = true;
            dgvItemList.Columns["Scheme2"].Visible = true;
            dgvItemList.Columns["Location"].Visible = true;
            dgvItemList.Columns["MaximumStock"].Visible = true;
            dgvItemList.Columns["MinimumStock"].Visible = true;
        }

        private void DgvCompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvItemList.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    ItemMaster itemToBeRemoved = (ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;
                    applicationFacade.DeleteItem(itemToBeRemoved);
                    LoadDataGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
    }
}
