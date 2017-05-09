﻿using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmCompanyAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private int CompanyId { get; set; }

        public frmCompanyAddUpdate()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        public frmCompanyAddUpdate(int companyId)
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
            this.CompanyId = companyId;
        }

        private void frmCompanyAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, (this.CompanyId > 0) ? "Company Master - Update" : "Company Master - Add");

            FillCombo();

            if (this.CompanyId > 0)
            {
                FillFormForUpdate();
            }
            
        }

        private void FillFormForUpdate()
        {
            CompanyMaster company = applicationFacade.GetCompanyById(this.CompanyId);

            if(company != null)
            {
                txtCompanyCode.Text = company.CompanyCode;
                txtCompanyName.Text = company.CompanyName;
                txtBillingPrefRating.Text = company.BillingPreferenceRating.ToString();
                txtOrderPrefRating.Text = company.OrderPreferenceRating.ToString();
                cbxDI.SelectedItem = company.IsDirect ? Enums.DI.Direct : Enums.DI.Indirect;
                cbxSSRequired.SelectedItem = company.StockSummaryRequired ? Enums.Choice.Yes : Enums.Choice.No;
                cbxStatus.SelectedItem = company.Status ? Enums.Status.Active : Enums.Status.Inactive;

            }
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill Yes/No option
            cbxSSRequired.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxSSRequired.SelectedItem = Enums.Choice.Yes;

            //Fill Direct/Indirect option
            cbxDI.DataSource = Enum.GetValues(typeof(Enums.DI));
            cbxDI.SelectedItem = Enums.DI.Direct;
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                throw new Exception("Company Name can not be blank");
            }
            Status status;
            Choice choice;
            DI di;

            CompanyMaster company = new CompanyMaster();
            company.CompanyCode = txtCompanyCode.Text;
            company.CompanyId = this.CompanyId;
            company.CompanyName = txtCompanyName.Text;
            company.OrderPreferenceRating = string.IsNullOrEmpty(txtOrderPrefRating.Text) ? 0 : Convert.ToInt32(txtOrderPrefRating.Text);
            company.BillingPreferenceRating = string.IsNullOrEmpty(txtBillingPrefRating.Text) ? 0 : Convert.ToInt32(txtBillingPrefRating.Text);
            Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
            company.Status = status == Status.Active;
            Enum.TryParse<Choice>(cbxSSRequired.SelectedValue.ToString(), out choice);
            company.StockSummaryRequired = choice == Choice.Yes;
            Enum.TryParse<DI>(cbxDI.SelectedValue.ToString(), out di);
            company.IsDirect = di == DI.Direct;

            int result = CompanyId > 0 ? applicationFacade.UpdateCompany(company) : applicationFacade.AddCompany(company);

            //Close this form if operation is successful
            if (result > 0)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOrderPrefRating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtBillingPrefRating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
