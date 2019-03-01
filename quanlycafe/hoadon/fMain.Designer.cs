namespace quanlycafe
{
    partial class MForm
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
            this.livMenu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.livOrder = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReset = new System.Windows.Forms.Button();
            this.lbThanhtien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypeFood = new System.Windows.Forms.ComboBox();
            this.numUDDiscount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTableName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDiscount)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // livMenu
            // 
            this.livMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.livMenu.FullRowSelect = true;
            this.livMenu.GridLines = true;
            this.livMenu.Location = new System.Drawing.Point(12, 68);
            this.livMenu.MultiSelect = false;
            this.livMenu.Name = "livMenu";
            this.livMenu.Size = new System.Drawing.Size(286, 556);
            this.livMenu.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.livMenu.TabIndex = 0;
            this.livMenu.UseCompatibleStateImageBehavior = false;
            this.livMenu.View = System.Windows.Forms.View.Details;
            this.livMenu.DoubleClick += new System.EventHandler(this.livMenu_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ĐVT";
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 99;
            // 
            // livOrder
            // 
            this.livOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.livOrder.FullRowSelect = true;
            this.livOrder.GridLines = true;
            this.livOrder.Location = new System.Drawing.Point(694, 68);
            this.livOrder.MultiSelect = false;
            this.livOrder.Name = "livOrder";
            this.livOrder.Size = new System.Drawing.Size(282, 401);
            this.livOrder.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.livOrder.TabIndex = 1;
            this.livOrder.UseCompatibleStateImageBehavior = false;
            this.livOrder.View = System.Windows.Forms.View.Details;
            this.livOrder.DoubleClick += new System.EventHandler(this.livOrder_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ĐVT";
            this.columnHeader5.Width = 56;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đơn giá";
            this.columnHeader6.Width = 66;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số lượng";
            this.columnHeader7.Width = 64;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(3, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(109, 48);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbThanhtien
            // 
            this.lbThanhtien.AutoSize = true;
            this.lbThanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhtien.Location = new System.Drawing.Point(912, 517);
            this.lbThanhtien.Name = "lbThanhtien";
            this.lbThanhtien.Size = new System.Drawing.Size(19, 20);
            this.lbThanhtien.TabIndex = 3;
            this.lbThanhtien.Text = "0";
            this.lbThanhtien.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(782, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thành tiền:";
            // 
            // cbTypeFood
            // 
            this.cbTypeFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFood.FormattingEnabled = true;
            this.cbTypeFood.Location = new System.Drawing.Point(12, 39);
            this.cbTypeFood.Name = "cbTypeFood";
            this.cbTypeFood.Size = new System.Drawing.Size(139, 22);
            this.cbTypeFood.TabIndex = 13;
            this.cbTypeFood.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            // 
            // numUDDiscount
            // 
            this.numUDDiscount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUDDiscount.Location = new System.Drawing.Point(912, 485);
            this.numUDDiscount.Name = "numUDDiscount";
            this.numUDDiscount.Size = new System.Drawing.Size(64, 20);
            this.numUDDiscount.TabIndex = 14;
            this.numUDDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUDDiscount.ValueChanged += new System.EventHandler(this.numUDGiamGia_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(833, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Giảm giá:";
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.Location = new System.Drawing.Point(118, 8);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(109, 48);
            this.btnThanhtoan.TabIndex = 16;
            this.btnThanhtoan.Text = "Thanh toán";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThanhtoan);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Location = new System.Drawing.Point(738, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 71);
            this.panel2.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smenuAdmin,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1014, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smenuAdmin
            // 
            this.smenuAdmin.Name = "smenuAdmin";
            this.smenuAdmin.Size = new System.Drawing.Size(55, 20);
            this.smenuAdmin.Text = "Admin";
            this.smenuAdmin.Click += new System.EventHandler(this.smenuAdmin_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.tàiKhoảnToolStripMenuItem.Text = "Đổi mật khẩu";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.đăngXuấtToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpTable.Location = new System.Drawing.Point(304, 68);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(384, 557);
            this.flpTable.TabIndex = 19;
            // 
            // lbTableName
            // 
            this.lbTableName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbTableName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableName.Location = new System.Drawing.Point(694, 473);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(124, 30);
            this.lbTableName.TabIndex = 20;
            this.lbTableName.Tag = "0";
            this.lbTableName.Text = "Bàn 1";
            this.lbTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 638);
            this.Controls.Add(this.lbTableName);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbThanhtien);
            this.Controls.Add(this.numUDDiscount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTypeFood);
            this.Controls.Add(this.livOrder);
            this.Controls.Add(this.livMenu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý";
            this.Load += new System.EventHandler(this.MForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDDiscount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView livMenu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView livOrder;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbThanhtien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTypeFood;
        private System.Windows.Forms.NumericUpDown numUDDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Label lbTableName;
    }
}

