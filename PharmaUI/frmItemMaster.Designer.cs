namespace PharmaUI
{
    partial class frmItemMaster
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
            this.tbxSearchItem = new System.Windows.Forms.TextBox();
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.panelItemInfo = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxSearchItem
            // 
            this.tbxSearchItem.Location = new System.Drawing.Point(101, 38);
            this.tbxSearchItem.Name = "tbxSearchItem";
            this.tbxSearchItem.Size = new System.Drawing.Size(296, 20);
            this.tbxSearchItem.TabIndex = 2;
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.AutoSize = true;
            this.lblSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchItem.Location = new System.Drawing.Point(12, 38);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(83, 17);
            this.lblSearchItem.TabIndex = 1;
            this.lblSearchItem.Text = "Search Item";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::PharmaUI.Properties.Resources.AddItem;
            this.btnAddItem.Location = new System.Drawing.Point(967, 26);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(111, 35);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // dgvItemList
            // 
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Location = new System.Drawing.Point(15, 67);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.Size = new System.Drawing.Size(1063, 271);
            this.dgvItemList.TabIndex = 4;
            // 
            // panelItemInfo
            // 
            this.panelItemInfo.Location = new System.Drawing.Point(15, 345);
            this.panelItemInfo.Name = "panelItemInfo";
            this.panelItemInfo.Size = new System.Drawing.Size(1063, 122);
            this.panelItemInfo.TabIndex = 5;
            // 
            // frmItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 479);
            this.Controls.Add(this.panelItemInfo);
            this.Controls.Add(this.dgvItemList);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lblSearchItem);
            this.Controls.Add(this.tbxSearchItem);
            this.Name = "frmItemMaster";
            this.Text = "Item Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxSearchItem;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Panel panelItemInfo;
    }
}