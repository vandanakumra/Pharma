using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class ucSupplierCustomerInfo : UserControl
    {
        #region Properties
        public string Code {
            get {
                return txtCode.Text;
            } set {
                txtCode.Text = value;
            }
        }

        public string Name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string ShortName
        {
            get
            {
                return txtShortName.Text;
            }
            set
            {
                txtShortName.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return txtAddress.Text;
            }
            set
            {
                txtAddress.Text = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return txtContactPerson.Text;
            }
            set
            {
                txtContactPerson.Text = value;
            }
        }

        public string Mobile
        {
            get
            {
                return txtMobile.Text;
            }
            set
            {
                txtMobile.Text = value;
            }
        }

        public string Fax
        {
            get
            {
                return txtFax.Text;
            }
            set
            {
                txtFax.Text = value;
            }
        }

        public string Pager
        {
            get
            {
                return txtPager.Text;
            }
            set
            {
                txtPager.Text = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return txtEmailAddress.Text;
            }
            set
            {
                txtEmailAddress.Text = value;
            }
        }

        public string OfficePhone
        {
            get
            {
                return txtPhoneO.Text;
            }
            set
            {
                txtPhoneO.Text = value;
            }
        }

        public string ResidentPhone
        {
            get
            {
                return txtPhoneR.Text;
            }
            set
            {
                txtPhoneR.Text = value;
            }
        }

        public string OpeningBal
        {
            get
            {
                return txtOpeningBal.Text;
            }
            set
            {
                txtOpeningBal.Text = value;
            }
        }

        public string CreditDebit
        {
            get
            {
                return cbxCreditDebit.SelectedItem.ToString();
            }
            set
            {
                cbxCreditDebit.SelectedItem = value;
            }
        }

        public string TaxRetail
        {
            get
            {
                return cbxTaxRetail.SelectedItem.ToString();
            }
            set
            {
                cbxTaxRetail.SelectedItem = value;
            }
        }

        public object Status
        {
            get
            {
                return cbxStatus.SelectedValue.ToString();
            }
            set
            {
                cbxStatus.SelectedItem = value;
            }
        }

        public object StatusDataSource
        {
            set
            {
                cbxStatus.DataSource = value;
            }
        }
        #endregion

        public ucSupplierCustomerInfo()
        {
            InitializeComponent();
            
        }
    }
}
