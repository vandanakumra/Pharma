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
    public partial class frmPersonRouteMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private PersonRouteMaster PersonRouteMaster { get; set; }

        public frmPersonRouteMasterAddUpdate(string recordType = "")
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            this.PersonRouteMaster = new PersonRouteMaster();
            SetUIForRecordType(recordType);
        }

        private void SetUIForRecordType(string recordType)
        {
            if (!String.IsNullOrWhiteSpace(recordType))
            {
                cbPersonRouteType.Text = recordType;
                cbPersonRouteType.Enabled = false;
            }
        }

        public frmPersonRouteMasterAddUpdate(PersonRouteMaster personRouteMaster)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            this.PersonRouteMaster = personRouteMaster;
        }


        private void frmPersonRouteMasterAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Person Route Master  - Add");
            GotFocusEventRaised(this);

            ExtensionMethods.FormLoad(this, (this.PersonRouteMaster.PersonRouteID > 0) ? "Person Route Master - Update" : "Person Route Master - Add");

            if (this.PersonRouteMaster.PersonRouteID > 0)
            {
                FillFormForUpdate();
            }
            else
            {
                FillCombo();
                cbxStatus.SelectedItem = Enums.Status.Active;
            }
        }

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

        private void FillCombo()
        {
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));

            cbPersonRouteType.DataSource = applicationFacade.GetRecordTypes();
            cbPersonRouteType.ValueMember = "RecordTypeId";
            cbPersonRouteType.DisplayMember = "RecordTypeName";
        }

        private void FillFormForUpdate()
        {
            FillCombo();

            tbPersonRouteName.Text = this.PersonRouteMaster.PersonRouteName;
            txtPersonRouteCode.Text = this.PersonRouteMaster.PersonRouteCode;
            cbPersonRouteType.SelectedValue = this.PersonRouteMaster.RecordTypeId;
            cbxStatus.SelectedItem = this.PersonRouteMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PersonRouteMaster model = new PersonRouteMaster();

            model.PersonRouteID = this.PersonRouteMaster.PersonRouteID;
            model.RecordTypeId = (int)cbPersonRouteType.SelectedValue;

            Status status;
            Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
            model.Status = status == Status.Active;

            model.PersonRouteName = tbPersonRouteName.Text;
            model.PersonRouteCode = this.PersonRouteMaster.PersonRouteCode;

            var result = this.PersonRouteMaster.RecordTypeId > 0 ? applicationFacade.UpdatePersonRoute(model) : applicationFacade.AddPersonRoute(model);

            if (result > 0)
            {
                this.Close();
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
