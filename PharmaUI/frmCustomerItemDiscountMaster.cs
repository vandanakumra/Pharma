using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
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
    public partial class frmCustomerItemDiscountMaster : Form
    {
        IApplicationFacade applicationFacade;
        public CustomerCopanyDiscount retCustomerCopanyDiscount { get; set; }

        private List<CustomerCopanyDiscount> companyItemSelectedList { get; set; }


        public frmCustomerItemDiscountMaster(CustomerCopanyDiscount CustomerCopanyDiscount)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            ExtensionMethods.FormLoad(this, "Customer Item Discount");

            this.retCustomerCopanyDiscount = CustomerCopanyDiscount;
            
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

           
        }

        private void frmCustomerItemDiscountMaster_Load(object sender, EventArgs e)
        {
            ///Display Company name
            ///
            this.lblSelectedCompanyName.Text = retCustomerCopanyDiscount.CompanyName;
            LoadGrid();
        }

        private void LoadGrid()
        {
            dgvCustomerItemDiscount.DataSource = GetMergedItemDiscountList();

            for (int i = 0; i < dgvCustomerItemDiscount.Columns.Count; i++)
            {
                dgvCustomerItemDiscount.Columns[i].Visible = false;
            }

            dgvCustomerItemDiscount.Columns["ItemName"].Visible = true;
            dgvCustomerItemDiscount.Columns["ItemName"].HeaderText = "Item Name";
            dgvCustomerItemDiscount.Columns["ItemName"].ReadOnly = true;


            dgvCustomerItemDiscount.Columns["Normal"].Visible = true;
            dgvCustomerItemDiscount.Columns["Normal"].HeaderText = "Normal";

            dgvCustomerItemDiscount.Columns["Breakage"].Visible = true;
            dgvCustomerItemDiscount.Columns["Breakage"].HeaderText = "Breakage";

            dgvCustomerItemDiscount.Columns["Expired"].Visible = true;
            dgvCustomerItemDiscount.Columns["Expired"].HeaderText = "Expired";


            dgvCustomerItemDiscount.Columns["IsLessEcise"].Visible = true;
            dgvCustomerItemDiscount.Columns["IsLessEcise"].HeaderText = "LessEcise";

            dgvCustomerItemDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerItemDiscount.AllowUserToAddRows = false;
            dgvCustomerItemDiscount.AllowUserToDeleteRows = false;
            dgvCustomerItemDiscount.ReadOnly = false;

        }

        private List<CustomerCopanyDiscount> GetMergedItemDiscountList()
        {
            try
            {
                List<CustomerCopanyDiscount> allItemDiscountList = applicationFacade.GetAllCompanyItemDiscountByCompanyID(retCustomerCopanyDiscount.CompanyID);

                allItemDiscountList.ForEach(p => {
                    p.Normal = retCustomerCopanyDiscount.Normal;
                    p.Breakage = retCustomerCopanyDiscount.Breakage;
                    p.Expired = retCustomerCopanyDiscount.Expired;
                    p.IsLessEcise = retCustomerCopanyDiscount.IsLessEcise;
                });

                companyItemSelectedList = this.retCustomerCopanyDiscount.CustomerItemDiscountMapping;

                List<CustomerCopanyDiscount> mappedItemDiscountList = this.retCustomerCopanyDiscount.CustomerItemDiscountMapping;

                if (mappedItemDiscountList!=null)
                {
                    allItemDiscountList.RemoveAll(x => mappedItemDiscountList.Any(y => y.ItemID == x.ItemID));
                    allItemDiscountList.AddRange(mappedItemDiscountList);
                }

                return allItemDiscountList.OrderBy(x => x.ItemName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmCustomerItemDiscountMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.retCustomerCopanyDiscount.CustomerItemDiscountMapping = companyItemSelectedList;

                //dgvCustomerItemDiscount.Rows
                //                                                                            .Cast<DataGridViewRow>()
                //                                                                            .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                //                                                                                        || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                //                                                                                        || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                //                                                                            ).Select(x => new CustomerCopanyDiscount()
                //                                                                            {
                //                                                                                CompanyID = (x.DataBoundItem as CustomerCopanyDiscount).CompanyID,
                //                                                                                ItemID = (x.DataBoundItem as CustomerCopanyDiscount).ItemID,
                //                                                                                ItemName = (x.DataBoundItem as CustomerCopanyDiscount).ItemName,
                //                                                                                Normal = (x.DataBoundItem as CustomerCopanyDiscount).Normal,
                //                                                                                Breakage = (x.DataBoundItem as CustomerCopanyDiscount).Breakage,
                //                                                                                Expired = (x.DataBoundItem as CustomerCopanyDiscount).Expired,
                //                                                                                IsLessEcise = (x.DataBoundItem as CustomerCopanyDiscount).IsLessEcise

                //                                                                            }).ToList();

                this.Close();
            }
            catch (Exception)
            {

            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void dgvCustomerItemDiscount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomerItemDiscount.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close on escape
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvCustomerItemDiscount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PharmaBusinessObjects.Master.CustomerCopanyDiscount model = (PharmaBusinessObjects.Master.CustomerCopanyDiscount)dgvCustomerItemDiscount.Rows[e.RowIndex].DataBoundItem;

            var existing = companyItemSelectedList.Where(x => x.CompanyID == model.CompanyID && x.ItemID == model.ItemID).FirstOrDefault();

            if (existing != null)
            {
                companyItemSelectedList.Remove(existing);
            }

            companyItemSelectedList.Add(model);
        }
    }
}
