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
    public partial class frmItemMasterAddUpdatedNew : Form
    {
        private bool isInEditMode;

        public frmItemMasterAddUpdatedNew()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            ExtensionMethods.DisableAllTextBoxAndComboBox(this);
        }

        private void frmItemMasterAddUpdatedNew_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, isInEditMode ? "Item Master - Update" : "Item Master - Add");
        }

       
    }
}
