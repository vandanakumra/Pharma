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
    public partial class frmUserMasterAddUpdate : Form
    {
        public int UserId { get; set; }
        IApplicationFacade applicationFacade;

        public frmUserMasterAddUpdate()
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        public frmUserMasterAddUpdate(int userId)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

        }

        private void frmUserMasterAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, UserId > 0 ? "User - Update" : "User - Add");
            GotFocusEventRaised(this);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
