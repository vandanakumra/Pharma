﻿using System;
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

            rdName.Checked = true;
        }

        private void DgvItemList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItemList.SelectedRows.Count > 0)
            {
               ItemMaster selectedItem = (ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;
                //Display selected Item data
                lblCodeVal.Text = selectedItem.ItemCode;
                lblStatusVal.Text = selectedItem.Status ? "ACTIVE" : "INACTIVE";
                lblStatusVal.ForeColor = selectedItem.Status ? Color.MidnightBlue : Color.Red;
                lblPackVal.Text = selectedItem.Packing;
                lblLocationVal.Text = selectedItem.Location;
                lblUPCVal.Text = selectedItem.UPC;

                lblMRPVal.Text = Convert.ToString(selectedItem.MRP);
                lblSchemeVal.Text = Convert.ToString(selectedItem.Scheme1) + " + " + Convert.ToString(selectedItem.Scheme2);
                lblHalfSchemeVal.Text = selectedItem.IsHalfScheme ? "Y" : "N";
                lblQtrSchemeVal.Text = selectedItem.IsQTRScheme ? "Y" : "N";
                lblMaxQtyVal.Text = Convert.ToString(selectedItem.MaximumQty);
                lblMaxDiscountVal.Text = Convert.ToString(selectedItem.MaximumDiscount);
                
                lblSaleRateVal.Text = Convert.ToString(selectedItem.SaleRate);
                lblSpecialRateVal.Text = Convert.ToString(selectedItem.SpecialRate);
                lblWSRateVal.Text = Convert.ToString(selectedItem.WholeSaleRate);
                lblExciseVal.Text = Convert.ToString(selectedItem.SaleExcise);
                lblVATVal.Text = Convert.ToString(selectedItem.TaxOnSale);
                lblSpecialDiscountVal.Text = Convert.ToString(selectedItem.SpecialDiscountOnQty);
                lblFixedDiscountVal.Text = Convert.ToString(selectedItem.FixedDiscountRate);
                lblSurchargeVal.Text = Convert.ToString(selectedItem.SurchargeOnSale);

                lblPurchaseRateVal.Text = Convert.ToString(selectedItem.PurchaseRate);
                lblPExciseVal.Text = Convert.ToString(selectedItem.SaleExcise);
                lblPVATVal.Text = Convert.ToString(selectedItem.TaxOnPurchase);
                lblPDiscountVal.Text = Convert.ToString(selectedItem.DiscountRecieved);
                lblPSpecialDiscountVal.Text = Convert.ToString(selectedItem.SpecialDiscountRecieved);
                lblPSurchargeVal.Text = Convert.ToString(selectedItem.SurchargeOnPurchase);

                //lblPurchaseRateVal.Text = Convert.ToString(selectedItem.PurchaseRate);
                //lblPExciseVal.Text = Convert.ToString(selectedItem.SaleExcise);
                //lblPVATVal.Text = Convert.ToString(selectedItem.TaxOnPurchase);
                //lblPDiscountVal.Text = Convert.ToString(selectedItem.DiscountRecieved);
                lblMaxStockVal.Text = Convert.ToString(selectedItem.MaximumStock);
                lblMinStockVal.Text = Convert.ToString(selectedItem.MinimumStock);

            }
        }

        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditItem();
            }
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenItemAddUpdateForm(0);
            }
            catch (Exception)
            {

            }
        }

        private void OpenItemAddUpdateForm(int itemId)
        {
            frmItemMasterAddUpdated form = new frmItemMasterAddUpdated(itemId,txtSearch.Text);
            ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
            form.WindowState = FormWindowState.Maximized; 
            

            if (itemId > 0 && dgvItemList.SelectedRows[0] != null)
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
            string searchBy = "Name";

            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                searchBy = rdCode.Checked ? "Code" : rdMRP.Checked ? "MRP" : rdPack.Checked ? "Pack" : rdLocation.Checked ? "Location" : rdBarCode.Checked ? "BarCode" : string.Empty;

            }

            dgvItemList.DataSource = applicationFacade.GetAllItemsBySearch(txtSearch.Text, searchBy);

            for (int i = 0; i < dgvItemList.Columns.Count; i++)
            {
                dgvItemList.Columns[i].Visible = false;
            }

            dgvItemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItemList.AllowUserToAddRows = false;
            dgvItemList.AllowUserToDeleteRows = false;
            dgvItemList.ReadOnly = true;

            
            dgvItemList.Columns["ItemName"].Visible = true;
            dgvItemList.Columns["ItemName"].HeaderText = "Item";

            dgvItemList.Columns["CompanyName"].Visible = true;
            dgvItemList.Columns["CompanyName"].HeaderText = "Company";

            dgvItemList.Columns["Packing"].Visible = true;
            dgvItemList.Columns["Packing"].HeaderText = "Pack";

            dgvItemList.Columns["QtyPerCase"].Visible = true;
            dgvItemList.Columns["QtyPerCase"].HeaderText = "Qty";
        }

        private void DgvCompanyList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                OpenItemAddUpdateForm(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {                
                EditItem();
              
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EditItem()
        {
            if (dgvItemList.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.ItemMaster model = (PharmaBusinessObjects.Master.ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;           

            OpenItemAddUpdateForm(model.ItemID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditItem();
           
        }
    }
}
