﻿using System;
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
        public frmUserMasterAddUpdate()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
        }

        private void frmUserMasterAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Add Update");
        }
    }
}
