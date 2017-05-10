﻿namespace PharmaUI
{
    partial class frmPersonalLedgerMaster
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPersonalLedger = new System.Windows.Forms.DataGridView();
            this.btnAddNewLedger = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(138, 81);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(294, 23);
            this.txtSearch.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search String";
            // 
            // dgvPersonalLedger
            // 
            this.dgvPersonalLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonalLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalLedger.Location = new System.Drawing.Point(16, 121);
            this.dgvPersonalLedger.Name = "dgvPersonalLedger";
            this.dgvPersonalLedger.ReadOnly = true;
            this.dgvPersonalLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonalLedger.Size = new System.Drawing.Size(609, 260);
            this.dgvPersonalLedger.TabIndex = 9;
            // 
            // btnAddNewLedger
            // 
            this.btnAddNewLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewLedger.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLedger.Image = global::PharmaUI.Properties.Resources.AddItem;
            this.btnAddNewLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewLedger.Location = new System.Drawing.Point(441, 73);
            this.btnAddNewLedger.Name = "btnAddNewLedger";
            this.btnAddNewLedger.Size = new System.Drawing.Size(184, 42);
            this.btnAddNewLedger.TabIndex = 8;
            this.btnAddNewLedger.Text = "Add Personal Diary";
            this.btnAddNewLedger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewLedger.UseVisualStyleBackColor = true;
            this.btnAddNewLedger.Click += new System.EventHandler(this.btnAddNewLedger_Click);
            // 
            // frmPersonalLedgerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 399);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPersonalLedger);
            this.Controls.Add(this.btnAddNewLedger);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Name = "frmPersonalLedgerMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPersonalLedgerMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewLedger;
        private System.Windows.Forms.DataGridView dgvPersonalLedger;
    }
}