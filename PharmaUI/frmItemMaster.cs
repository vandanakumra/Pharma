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
        public PharmaBusinessObjects.Master.ItemMaster LastSelectedItemMaster { get; set; }
        IApplicationFacade applicationFacade;

        private bool isOpenAsChild = false;

        public frmItemMaster(bool _isOpenAsChild = false)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

                isOpenAsChild = _isOpenAsChild;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Item Master");
                GotFocusEventRaised(this);
               // ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadDataGrid();

                dgvItemList.CellDoubleClick += DgvItemList_CellDoubleClick;
                dgvItemList.KeyDown += DgvItemList_KeyDown;
                dgvItemList.SelectionChanged += DgvItemList_SelectionChanged;

                if (isOpenAsChild && dgvItemList.Rows.Count > 0)
                {
                    dgvItemList.Focus();
                    dgvItemList.CurrentCell = dgvItemList.Rows[0].Cells[2];
                }
                else
                    txtSearch.Focus();


                txtSearch.KeyDown += TxtSearch_KeyDown;
                //rdName.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter || e.KeyData == Keys.Tab )
            {
                dgvItemList.Focus();
                dgvItemList.Rows[dgvItemList.SelectedRows[0].Index].Selected = true;
            }
        }

        private void DgvItemList_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenItemAddUpdateForm(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            form.FormClosed += FormItemMasterAddUpdated_FormClosed;
            form.Show();
        }

        private void FormItemMasterAddUpdated_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGrid()
        {
            string searchBy = "Name";

            if(string.IsNullOrEmpty(txtSearch.Text))
            {
               // searchBy = rdCode.Checked ? "Code" : rdMRP.Checked ? "MRP" : rdPack.Checked ? "Pack" : rdLocation.Checked ? "Location" : rdBarCode.Checked ? "BarCode" : string.Empty;

            }

            dgvItemList.DataSource = applicationFacade.GetAllItemsBySearch(txtSearch.Text, searchBy).OrderBy(p=>p.ItemName).ToList();

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

        private void DgvItemList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && isOpenAsChild)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool flag = true;

                foreach (DataGridViewRow row in dgvItemList.Rows)
                {
                    int rowIndex = row.Index;

                    dgvItemList.Rows[rowIndex].Cells["ItemName"].Style = new DataGridViewCellStyle { ForeColor = Color.Black,BackColor = Color.White };
                }

                if (string.IsNullOrEmpty(txtSearch.Text))
                    return;

                int rowIndex1 = 0;

                foreach (DataGridViewRow row in dgvItemList.Rows)
                {
                    if (row.Cells["ItemName"].Value.ToString().ToLower().StartsWith(txtSearch.Text.ToLower()))
                    {
                        int row2 = row.Index;
                        if (flag)
                        {
                            rowIndex1= row.Index;

                            dgvItemList.ClearSelection();
                                                       
                            flag = false;
                        }
                        // dgvItemList.Focus();
                        dgvItemList.Rows[row2].Cells["ItemName"].Style = new DataGridViewCellStyle { ForeColor = Color.White, BackColor = Color.Blue };
                    }
                }


                dgvItemList.Rows[rowIndex1].Selected = true;
                
                dgvItemList.FirstDisplayedScrollingRowIndex = rowIndex1;


                // LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            //else if (keyData == Keys.Escape || keyData == Keys.End)
            //{
            //    this.Close();
            //}
            //else if (keyData == Keys.Enter && isOpenAsChild && this.ActiveControl.Name == "dgvItemList") 
            //{
            //    this.Close();
            //}

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
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmItemMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    this.LastSelectedItemMaster = dgvItemList.CurrentRow.DataBoundItem as PharmaBusinessObjects.Master.ItemMaster;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Set focus for the controls

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
