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
            lblSearchBy.ForeColor = Color.MidnightBlue;
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
                lblCodeVal.Text = selectedItem.ItemCode;
                lblLocation.Text = selectedItem.Location;
                //nlblBoxVal.Text = selectedItem.box
                lblStatusVal.Text = selectedItem.Status ? "Active" : "InActive";
                lblStatusVal.ForeColor = selectedItem.Status ? Color.MidnightBlue : Color.Red;

                lblMRPVal.Text = Convert.ToString(selectedItem.MRP);
               // lblMarginVal.Text = Convert.ToString(selectedItem.Ma)
                lblUnitsInPackVal.Text = selectedItem.Packing;
                lblPurRateVal.Text = Convert.ToString(selectedItem.PurchaseRate);
                lblMRPVal.Text = Convert.ToString(selectedItem.MRP);
                lblSaleRateVal.Text = Convert.ToString(selectedItem.SaleRate);
                lblSplRateVal.Text = Convert.ToString(selectedItem.SpecialRate);
                lblVATVal.Text = Convert.ToString(selectedItem.TaxOnSale);
                lblBarCodeVal.Text = selectedItem.UPC;
                lblMaxQtyVal.Text = Convert.ToString(selectedItem.MaximumQty);
                //lblMinQtyVal.Text = Convert.ToString(selectedItem.M);
                

            }
        }

        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                OpenItemAddUpdateForm(true);
            }
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenItemAddUpdateForm(false);
            }
            catch (Exception)
            {

            }
        }

        private void OpenItemAddUpdateForm(bool isEdit)
        {
            frmItemMasterAddUpdated form = new frmItemMasterAddUpdated(isEdit);
            ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
            form.WindowState = FormWindowState.Maximized; 
            

            if (isEdit && dgvItemList.SelectedRows[0] != null)
            {
                ItemMaster existingItem = (ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;
                form.frmItemMasterAddUpdate_Fill_UsingExistingItem(existingItem);
            }
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
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

            //dgvItemList.Columns["ItemCode"].Visible = true;
            dgvItemList.Columns["ItemName"].Visible = true;
            dgvItemList.Columns["CompanyName"].Visible = true;
            //dgvItemList.Columns["ShortName"].Visible = true;
            //dgvItemList.Columns["MRP"].Visible = true;
            dgvItemList.Columns["Packing"].Visible = true;
            dgvItemList.Columns["Quantity"].Visible = true;
            //dgvItemList.Columns["SaleRate"].Visible = true;
            //dgvItemList.Columns["Scheme1"].Visible = true;
            //dgvItemList.Columns["Scheme2"].Visible = true;
            //dgvItemList.Columns["Location"].Visible = true;
            //dgvItemList.Columns["MaximumStock"].Visible = true;
            //dgvItemList.Columns["MinimumStock"].Visible = true;
        }

        private void DgvCompanyList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void frmItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            //add item master
            if(e.KeyCode == Keys.F9)
            {
                OpenItemAddUpdateForm(false);
            }
            else if (e.KeyCode == Keys.F3) // edit item master
            {
                if (dgvItemList.SelectedRows.Count == 0)
                    MessageBox.Show("Please select atleast one row to edit");

                OpenItemAddUpdateForm(true);
            }
            else if(e.KeyCode == Keys.Delete)
            {

            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (dgvItemList.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            OpenItemAddUpdateForm(true);
        }
    }
}
