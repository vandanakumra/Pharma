using PharmaBusiness;
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
    public partial class frmPersonalLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private bool isInEditMode{get;set;}

        public frmPersonalLedgerMasterAddUpdate(bool isInEditMode=false)
        {
            this.isInEditMode = isInEditMode;
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            InitializeComponent();
            LoadCombo();

        }

        private void LoadCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Status.Active;
        }

        private void frmPersonalLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, isInEditMode ? "Personal Diary - Update" : "Personal Diary - Add");
           
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbxPersonalLedgerName.Text))
                {
                    errorProviderPerLedger.SetError(tbxPersonalLedgerName, Constants.Messages.RequiredField);
                    tbxPersonalLedgerName.SelectAll();
                    tbxPersonalLedgerName.Focus();
                    return;
                }

                Status status;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                
                PersonalLedgerMaster personalLedgerMaster = new PersonalLedgerMaster()
                {
                    PersonalLedgerName=tbxPersonalLedgerName.Text,
                    PersonalLedgerShortName=tbxPersonalLedgerShortName.Text,
                    Address=tbxAddress.Text,
                    ContactPerson=tbxContactPerson.Text,
                    Mobile=tbxMobile.Text,
                    Pager=tbxPager.Text,
                    Fax=tbxFax.Text,
                    OfficePhone=tbxOfficePhone.Text,
                    ResidentPhone=tbxResidentPhone.Text,
                    EmailAddress=tbxEmailAddress.Text,
                    Status = status == Status.Active
                };

                int actionResult = 0;
                // if form is in Edit mode then udate item , else add item 
                if (!isInEditMode)
                {
                    actionResult = applicationFacade.AddPersonalLedger(personalLedgerMaster);
                }
                else
                {
                    actionResult = applicationFacade.UpdatePersonalLedger(personalLedgerMaster);
                }

                //Close this form if operation is successful
                if (actionResult >0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }


        public void frmPersonalLedgerMasterAddUpdate_Fill_UsingExistingItem(PersonalLedgerMaster existingItem)
        {
            if (existingItem != null)
            {
                tbxPersonalLedgerName.Text = existingItem.PersonalLedgerName;
                tbxPersonalLedgerShortName.Text = existingItem.PersonalLedgerShortName;
                tbxAddress.Text = existingItem.Address;
                tbxContactPerson.Text = existingItem.ContactPerson;
                tbxMobile.Text = existingItem.Mobile;
                tbxPager.Text = existingItem.Pager;
                tbxFax.Text = existingItem.Fax;
                tbxOfficePhone.Text = existingItem.OfficePhone;
                tbxResidentPhone.Text = existingItem.ResidentPhone;
                tbxEmailAddress.Text = existingItem.EmailAddress;
                cbxStatus.SelectedItem= existingItem.Status ? Status.Active : Status.Inactive;
            }

        }
    }
}
