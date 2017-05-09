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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.splitContainerItemMaster = new System.Windows.Forms.SplitContainer();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.panelItemInfo = new System.Windows.Forms.Panel();
            this.gbItemDetail = new System.Windows.Forms.GroupBox();
            this.tableItemInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxQtyVal = new System.Windows.Forms.Label();
            this.lblMRPVal = new System.Windows.Forms.Label();
            this.lblUPCVal = new System.Windows.Forms.Label();
            this.lblPurchaseRateVal = new System.Windows.Forms.Label();
            this.lblTaxOnSaleVal = new System.Windows.Forms.Label();
            this.lblPackingVal = new System.Windows.Forms.Label();
            this.lblSpecialRateVal = new System.Windows.Forms.Label();
            this.lblComanyCodeVal = new System.Windows.Forms.Label();
            this.lblSaleRateVal = new System.Windows.Forms.Label();
            this.lblItemNameVal = new System.Windows.Forms.Label();
            this.lblComanyCode = new System.Windows.Forms.Label();
            this.lblPacking = new System.Windows.Forms.Label();
            this.lblPurchaseRate = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblSaleRate = new System.Windows.Forms.Label();
            this.lblSpecialRate = new System.Windows.Forms.Label();
            this.lblTaxOnSale = new System.Windows.Forms.Label();
            this.lblUPC = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItemMaster)).BeginInit();
            this.splitContainerItemMaster.Panel1.SuspendLayout();
            this.splitContainerItemMaster.Panel2.SuspendLayout();
            this.splitContainerItemMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.panelItemInfo.SuspendLayout();
            this.gbItemDetail.SuspendLayout();
            this.tableItemInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(80, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(296, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.AutoSize = true;
            this.lblSearchItem.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchItem.Location = new System.Drawing.Point(-4, 13);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(78, 19);
            this.lblSearchItem.TabIndex = 1;
            this.lblSearchItem.Text = "Search Item";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Image = global::PharmaUI.Properties.Resources.AddItem;
            this.btnAddItem.Location = new System.Drawing.Point(909, 0);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(154, 35);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // splitContainerItemMaster
            // 
            this.splitContainerItemMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerItemMaster.Location = new System.Drawing.Point(15, 64);
            this.splitContainerItemMaster.Name = "splitContainerItemMaster";
            this.splitContainerItemMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerItemMaster.Panel1
            // 
            this.splitContainerItemMaster.Panel1.Controls.Add(this.dgvItemList);
            this.splitContainerItemMaster.Panel1.Controls.Add(this.lblSearchItem);
            this.splitContainerItemMaster.Panel1.Controls.Add(this.btnAddItem);
            this.splitContainerItemMaster.Panel1.Controls.Add(this.txtSearch);
            this.splitContainerItemMaster.Panel1MinSize = 250;
            // 
            // splitContainerItemMaster.Panel2
            // 
            this.splitContainerItemMaster.Panel2.Controls.Add(this.panelItemInfo);
            this.splitContainerItemMaster.Size = new System.Drawing.Size(1062, 413);
            this.splitContainerItemMaster.SplitterDistance = 250;
            this.splitContainerItemMaster.TabIndex = 4;
            // 
            // dgvItemList
            // 
            this.dgvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Location = new System.Drawing.Point(3, 41);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(1056, 206);
            this.dgvItemList.TabIndex = 4;
            // 
            // panelItemInfo
            // 
            this.panelItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItemInfo.Controls.Add(this.gbItemDetail);
            this.panelItemInfo.Location = new System.Drawing.Point(0, -1);
            this.panelItemInfo.Name = "panelItemInfo";
            this.panelItemInfo.Size = new System.Drawing.Size(1060, 162);
            this.panelItemInfo.TabIndex = 0;
            // 
            // gbItemDetail
            // 
            this.gbItemDetail.Controls.Add(this.tableItemInfo);
            this.gbItemDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItemDetail.Location = new System.Drawing.Point(3, 3);
            this.gbItemDetail.Name = "gbItemDetail";
            this.gbItemDetail.Size = new System.Drawing.Size(591, 152);
            this.gbItemDetail.TabIndex = 3;
            this.gbItemDetail.TabStop = false;
            this.gbItemDetail.Text = "Selected Item Detail";
            // 
            // tableItemInfo
            // 
            this.tableItemInfo.ColumnCount = 4;
            this.tableItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.Controls.Add(this.lblMaxQtyVal, 3, 4);
            this.tableItemInfo.Controls.Add(this.lblMRPVal, 1, 4);
            this.tableItemInfo.Controls.Add(this.lblUPCVal, 3, 3);
            this.tableItemInfo.Controls.Add(this.lblPurchaseRateVal, 1, 3);
            this.tableItemInfo.Controls.Add(this.lblTaxOnSaleVal, 3, 2);
            this.tableItemInfo.Controls.Add(this.lblPackingVal, 1, 2);
            this.tableItemInfo.Controls.Add(this.lblSpecialRateVal, 3, 1);
            this.tableItemInfo.Controls.Add(this.lblComanyCodeVal, 1, 1);
            this.tableItemInfo.Controls.Add(this.lblSaleRateVal, 3, 0);
            this.tableItemInfo.Controls.Add(this.lblItemNameVal, 1, 0);
            this.tableItemInfo.Controls.Add(this.lblComanyCode, 0, 1);
            this.tableItemInfo.Controls.Add(this.lblPacking, 0, 2);
            this.tableItemInfo.Controls.Add(this.lblPurchaseRate, 0, 3);
            this.tableItemInfo.Controls.Add(this.lblMRP, 0, 4);
            this.tableItemInfo.Controls.Add(this.lblSaleRate, 2, 0);
            this.tableItemInfo.Controls.Add(this.lblSpecialRate, 2, 1);
            this.tableItemInfo.Controls.Add(this.lblTaxOnSale, 2, 2);
            this.tableItemInfo.Controls.Add(this.lblUPC, 2, 3);
            this.tableItemInfo.Controls.Add(this.label9, 2, 4);
            this.tableItemInfo.Controls.Add(this.lblItemName, 0, 0);
            this.tableItemInfo.Location = new System.Drawing.Point(6, 23);
            this.tableItemInfo.Name = "tableItemInfo";
            this.tableItemInfo.RowCount = 5;
            this.tableItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableItemInfo.Size = new System.Drawing.Size(457, 123);
            this.tableItemInfo.TabIndex = 0;
            // 
            // lblMaxQtyVal
            // 
            this.lblMaxQtyVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxQtyVal.AutoSize = true;
            this.lblMaxQtyVal.Location = new System.Drawing.Point(368, 96);
            this.lblMaxQtyVal.Name = "lblMaxQtyVal";
            this.lblMaxQtyVal.Size = new System.Drawing.Size(86, 27);
            this.lblMaxQtyVal.TabIndex = 21;
            this.lblMaxQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMRPVal
            // 
            this.lblMRPVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMRPVal.AutoSize = true;
            this.lblMRPVal.Location = new System.Drawing.Point(140, 96);
            this.lblMRPVal.Name = "lblMRPVal";
            this.lblMRPVal.Size = new System.Drawing.Size(85, 27);
            this.lblMRPVal.TabIndex = 20;
            this.lblMRPVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUPCVal
            // 
            this.lblUPCVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUPCVal.AutoSize = true;
            this.lblUPCVal.Location = new System.Drawing.Point(368, 72);
            this.lblUPCVal.Name = "lblUPCVal";
            this.lblUPCVal.Size = new System.Drawing.Size(86, 24);
            this.lblUPCVal.TabIndex = 19;
            this.lblUPCVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPurchaseRateVal
            // 
            this.lblPurchaseRateVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPurchaseRateVal.AutoSize = true;
            this.lblPurchaseRateVal.Location = new System.Drawing.Point(140, 72);
            this.lblPurchaseRateVal.Name = "lblPurchaseRateVal";
            this.lblPurchaseRateVal.Size = new System.Drawing.Size(85, 24);
            this.lblPurchaseRateVal.TabIndex = 18;
            this.lblPurchaseRateVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaxOnSaleVal
            // 
            this.lblTaxOnSaleVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaxOnSaleVal.AutoSize = true;
            this.lblTaxOnSaleVal.Location = new System.Drawing.Point(368, 48);
            this.lblTaxOnSaleVal.Name = "lblTaxOnSaleVal";
            this.lblTaxOnSaleVal.Size = new System.Drawing.Size(86, 24);
            this.lblTaxOnSaleVal.TabIndex = 17;
            this.lblTaxOnSaleVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPackingVal
            // 
            this.lblPackingVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPackingVal.AutoSize = true;
            this.lblPackingVal.Location = new System.Drawing.Point(140, 48);
            this.lblPackingVal.Name = "lblPackingVal";
            this.lblPackingVal.Size = new System.Drawing.Size(85, 24);
            this.lblPackingVal.TabIndex = 16;
            this.lblPackingVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecialRateVal
            // 
            this.lblSpecialRateVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpecialRateVal.AutoSize = true;
            this.lblSpecialRateVal.Location = new System.Drawing.Point(368, 24);
            this.lblSpecialRateVal.Name = "lblSpecialRateVal";
            this.lblSpecialRateVal.Size = new System.Drawing.Size(86, 24);
            this.lblSpecialRateVal.TabIndex = 15;
            this.lblSpecialRateVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComanyCodeVal
            // 
            this.lblComanyCodeVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComanyCodeVal.AutoSize = true;
            this.lblComanyCodeVal.Location = new System.Drawing.Point(140, 24);
            this.lblComanyCodeVal.Name = "lblComanyCodeVal";
            this.lblComanyCodeVal.Size = new System.Drawing.Size(85, 24);
            this.lblComanyCodeVal.TabIndex = 14;
            this.lblComanyCodeVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaleRateVal
            // 
            this.lblSaleRateVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaleRateVal.AutoSize = true;
            this.lblSaleRateVal.Location = new System.Drawing.Point(368, 0);
            this.lblSaleRateVal.Name = "lblSaleRateVal";
            this.lblSaleRateVal.Size = new System.Drawing.Size(86, 24);
            this.lblSaleRateVal.TabIndex = 13;
            this.lblSaleRateVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemNameVal
            // 
            this.lblItemNameVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemNameVal.AutoSize = true;
            this.lblItemNameVal.Location = new System.Drawing.Point(140, 0);
            this.lblItemNameVal.Name = "lblItemNameVal";
            this.lblItemNameVal.Size = new System.Drawing.Size(85, 24);
            this.lblItemNameVal.TabIndex = 12;
            this.lblItemNameVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComanyCode
            // 
            this.lblComanyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComanyCode.AutoSize = true;
            this.lblComanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComanyCode.Location = new System.Drawing.Point(3, 24);
            this.lblComanyCode.Name = "lblComanyCode";
            this.lblComanyCode.Size = new System.Drawing.Size(131, 24);
            this.lblComanyCode.TabIndex = 3;
            this.lblComanyCode.Text = "Comany Code";
            this.lblComanyCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPacking
            // 
            this.lblPacking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPacking.AutoSize = true;
            this.lblPacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacking.Location = new System.Drawing.Point(3, 48);
            this.lblPacking.Name = "lblPacking";
            this.lblPacking.Size = new System.Drawing.Size(131, 24);
            this.lblPacking.TabIndex = 4;
            this.lblPacking.Text = "Packing";
            this.lblPacking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPurchaseRate
            // 
            this.lblPurchaseRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPurchaseRate.AutoSize = true;
            this.lblPurchaseRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseRate.Location = new System.Drawing.Point(3, 72);
            this.lblPurchaseRate.Name = "lblPurchaseRate";
            this.lblPurchaseRate.Size = new System.Drawing.Size(131, 24);
            this.lblPurchaseRate.TabIndex = 5;
            this.lblPurchaseRate.Text = "Purchase Rate";
            this.lblPurchaseRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMRP.AutoSize = true;
            this.lblMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.Location = new System.Drawing.Point(3, 96);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(131, 27);
            this.lblMRP.TabIndex = 6;
            this.lblMRP.Text = "MRP";
            this.lblMRP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaleRate
            // 
            this.lblSaleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaleRate.AutoSize = true;
            this.lblSaleRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleRate.Location = new System.Drawing.Point(231, 0);
            this.lblSaleRate.Name = "lblSaleRate";
            this.lblSaleRate.Size = new System.Drawing.Size(131, 24);
            this.lblSaleRate.TabIndex = 7;
            this.lblSaleRate.Text = "Sale Rate";
            this.lblSaleRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecialRate
            // 
            this.lblSpecialRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpecialRate.AutoSize = true;
            this.lblSpecialRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialRate.Location = new System.Drawing.Point(231, 24);
            this.lblSpecialRate.Name = "lblSpecialRate";
            this.lblSpecialRate.Size = new System.Drawing.Size(131, 24);
            this.lblSpecialRate.TabIndex = 8;
            this.lblSpecialRate.Text = "Special Rate";
            this.lblSpecialRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaxOnSale
            // 
            this.lblTaxOnSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaxOnSale.AutoSize = true;
            this.lblTaxOnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxOnSale.Location = new System.Drawing.Point(231, 48);
            this.lblTaxOnSale.Name = "lblTaxOnSale";
            this.lblTaxOnSale.Size = new System.Drawing.Size(131, 24);
            this.lblTaxOnSale.TabIndex = 9;
            this.lblTaxOnSale.Text = "Tax On Sale";
            this.lblTaxOnSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUPC
            // 
            this.lblUPC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUPC.AutoSize = true;
            this.lblUPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPC.Location = new System.Drawing.Point(231, 72);
            this.lblUPC.Name = "lblUPC";
            this.lblUPC.Size = new System.Drawing.Size(131, 24);
            this.lblUPC.TabIndex = 10;
            this.lblUPC.Text = "UPC";
            this.lblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(231, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 27);
            this.label9.TabIndex = 11;
            this.label9.Text = "Max Quantity";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(3, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(131, 24);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 479);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerItemMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmItemMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            this.splitContainerItemMaster.Panel1.ResumeLayout(false);
            this.splitContainerItemMaster.Panel1.PerformLayout();
            this.splitContainerItemMaster.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItemMaster)).EndInit();
            this.splitContainerItemMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.panelItemInfo.ResumeLayout(false);
            this.gbItemDetail.ResumeLayout(false);
            this.tableItemInfo.ResumeLayout(false);
            this.tableItemInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.SplitContainer splitContainerItemMaster;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Panel panelItemInfo;
        private System.Windows.Forms.GroupBox gbItemDetail;
        private System.Windows.Forms.TableLayoutPanel tableItemInfo;
        private System.Windows.Forms.Label lblMaxQtyVal;
        private System.Windows.Forms.Label lblMRPVal;
        private System.Windows.Forms.Label lblUPCVal;
        private System.Windows.Forms.Label lblPurchaseRateVal;
        private System.Windows.Forms.Label lblTaxOnSaleVal;
        private System.Windows.Forms.Label lblPackingVal;
        private System.Windows.Forms.Label lblSpecialRateVal;
        private System.Windows.Forms.Label lblComanyCodeVal;
        private System.Windows.Forms.Label lblSaleRateVal;
        private System.Windows.Forms.Label lblItemNameVal;
        private System.Windows.Forms.Label lblComanyCode;
        private System.Windows.Forms.Label lblPacking;
        private System.Windows.Forms.Label lblPurchaseRate;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblSaleRate;
        private System.Windows.Forms.Label lblSpecialRate;
        private System.Windows.Forms.Label lblTaxOnSale;
        private System.Windows.Forms.Label lblUPC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblItemName;
    }
}