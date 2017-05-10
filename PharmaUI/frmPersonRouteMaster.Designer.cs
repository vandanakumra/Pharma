namespace PharmaUI
{
    partial class frmPersonRouteMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddPersonRoute = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPersonRouteType = new System.Windows.Forms.ComboBox();
            this.dgvPersonRoute = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPersonRoute
            // 
            this.btnAddPersonRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPersonRoute.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPersonRoute.Image = global::PharmaUI.Properties.Resources.AddItem;
            this.btnAddPersonRoute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPersonRoute.Location = new System.Drawing.Point(598, 64);
            this.btnAddPersonRoute.Name = "btnAddPersonRoute";
            this.btnAddPersonRoute.Size = new System.Drawing.Size(214, 61);
            this.btnAddPersonRoute.TabIndex = 12;
            this.btnAddPersonRoute.Text = "Add New Person/Route";
            this.btnAddPersonRoute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddPersonRoute.UseVisualStyleBackColor = true;
            this.btnAddPersonRoute.Click += new System.EventHandler(this.btnAddPersonRoute_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(165, 102);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(294, 23);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search String";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Person/Route Type";
            // 
            // cbPersonRouteType
            // 
            this.cbPersonRouteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonRouteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPersonRouteType.FormattingEnabled = true;
            this.cbPersonRouteType.Location = new System.Drawing.Point(165, 64);
            this.cbPersonRouteType.Name = "cbPersonRouteType";
            this.cbPersonRouteType.Size = new System.Drawing.Size(294, 24);
            this.cbPersonRouteType.TabIndex = 8;
            // 
            // dgvPersonRoute
            // 
            this.dgvPersonRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonRoute.Location = new System.Drawing.Point(14, 143);
            this.dgvPersonRoute.Name = "dgvPersonRoute";
            this.dgvPersonRoute.ReadOnly = true;
            this.dgvPersonRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonRoute.Size = new System.Drawing.Size(798, 233);
            this.dgvPersonRoute.TabIndex = 7;
            // 
            // frmPersonRouteMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(826, 413);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddPersonRoute);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPersonRouteType);
            this.Controls.Add(this.dgvPersonRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPersonRouteMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPersonRouteMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPersonRoute;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPersonRouteType;
        private System.Windows.Forms.DataGridView dgvPersonRoute;
    }
}