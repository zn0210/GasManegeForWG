﻿namespace Gas_test2.WinUI
{
    partial class EquipConfig
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipConfig));
            this.btn_Update = new System.Windows.Forms.Button();
            this.lbox_Equip = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbox_Type = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbox_Num = new System.Windows.Forms.TextBox();
            this.lab_Num = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPage_L3 = new System.Windows.Forms.TabPage();
            this.dgv_L3 = new System.Windows.Forms.DataGridView();
            this.L3Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPage_L2 = new System.Windows.Forms.TabPage();
            this.dgv_L2 = new System.Windows.Forms.DataGridView();
            this.L2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPage_L1 = new System.Windows.Forms.TabPage();
            this.dgv_L1 = new System.Windows.Forms.DataGridView();
            this.L1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_create = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.btn_Q = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbPage_L3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L3)).BeginInit();
            this.tbPage_L2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L2)).BeginInit();
            this.tbPage_L1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(119, 342);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(51, 48);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "更改";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // lbox_Equip
            // 
            this.lbox_Equip.FormattingEnabled = true;
            this.lbox_Equip.ItemHeight = 12;
            this.lbox_Equip.Location = new System.Drawing.Point(32, 20);
            this.lbox_Equip.Name = "lbox_Equip";
            this.lbox_Equip.Size = new System.Drawing.Size(150, 292);
            this.lbox_Equip.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Update);
            this.groupBox2.Controls.Add(this.btn_Read);
            this.groupBox2.Controls.Add(this.lbox_Equip);
            this.groupBox2.Location = new System.Drawing.Point(310, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 411);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择加入的设备：";
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(37, 342);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(51, 48);
            this.btn_Read.TabIndex = 7;
            this.btn_Read.Text = "读取";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(124, 342);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(50, 48);
            this.btn_Delete.TabIndex = 7;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(27, 342);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(50, 48);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbox_Type
            // 
            this.lbox_Type.FormattingEnabled = true;
            this.lbox_Type.ItemHeight = 12;
            this.lbox_Type.Location = new System.Drawing.Point(27, 20);
            this.lbox_Type.Name = "lbox_Type";
            this.lbox_Type.Size = new System.Drawing.Size(150, 292);
            this.lbox_Type.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Controls.Add(this.lbox_Type);
            this.groupBox1.Location = new System.Drawing.Point(26, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 411);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可选设备：";
            // 
            // txtbox_Num
            // 
            this.txtbox_Num.Location = new System.Drawing.Point(110, 40);
            this.txtbox_Num.Name = "txtbox_Num";
            this.txtbox_Num.Size = new System.Drawing.Size(100, 21);
            this.txtbox_Num.TabIndex = 10;
            // 
            // lab_Num
            // 
            this.lab_Num.AutoSize = true;
            this.lab_Num.Location = new System.Drawing.Point(21, 43);
            this.lab_Num.Name = "lab_Num";
            this.lab_Num.Size = new System.Drawing.Size(65, 12);
            this.lab_Num.TabIndex = 9;
            this.lab_Num.Text = "设备数量：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbox_Num);
            this.panel1.Controls.Add(this.lab_Num);
            this.panel1.Location = new System.Drawing.Point(576, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 100);
            this.panel1.TabIndex = 17;
            // 
            // tbPage_L3
            // 
            this.tbPage_L3.Controls.Add(this.dgv_L3);
            this.tbPage_L3.Location = new System.Drawing.Point(4, 22);
            this.tbPage_L3.Name = "tbPage_L3";
            this.tbPage_L3.Size = new System.Drawing.Size(309, 205);
            this.tbPage_L3.TabIndex = 2;
            this.tbPage_L3.Text = "调度数据";
            this.tbPage_L3.UseVisualStyleBackColor = true;
            // 
            // dgv_L3
            // 
            this.dgv_L3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_L3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.L3Name});
            this.dgv_L3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_L3.Location = new System.Drawing.Point(0, 0);
            this.dgv_L3.Name = "dgv_L3";
            this.dgv_L3.RowTemplate.Height = 23;
            this.dgv_L3.Size = new System.Drawing.Size(309, 205);
            this.dgv_L3.TabIndex = 0;
            // 
            // L3Name
            // 
            this.L3Name.HeaderText = "因素名称";
            this.L3Name.Name = "L3Name";
            // 
            // tbPage_L2
            // 
            this.tbPage_L2.Controls.Add(this.dgv_L2);
            this.tbPage_L2.Location = new System.Drawing.Point(4, 22);
            this.tbPage_L2.Name = "tbPage_L2";
            this.tbPage_L2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage_L2.Size = new System.Drawing.Size(309, 205);
            this.tbPage_L2.TabIndex = 1;
            this.tbPage_L2.Text = "操作数据";
            this.tbPage_L2.UseVisualStyleBackColor = true;
            // 
            // dgv_L2
            // 
            this.dgv_L2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_L2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.L2Name});
            this.dgv_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_L2.Location = new System.Drawing.Point(3, 3);
            this.dgv_L2.Name = "dgv_L2";
            this.dgv_L2.RowTemplate.Height = 23;
            this.dgv_L2.Size = new System.Drawing.Size(303, 199);
            this.dgv_L2.TabIndex = 0;
            // 
            // L2Name
            // 
            this.L2Name.HeaderText = "因素名称";
            this.L2Name.Name = "L2Name";
            // 
            // tbPage_L1
            // 
            this.tbPage_L1.Controls.Add(this.dgv_L1);
            this.tbPage_L1.Location = new System.Drawing.Point(4, 22);
            this.tbPage_L1.Name = "tbPage_L1";
            this.tbPage_L1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage_L1.Size = new System.Drawing.Size(309, 205);
            this.tbPage_L1.TabIndex = 0;
            this.tbPage_L1.Text = "直采数据";
            this.tbPage_L1.UseVisualStyleBackColor = true;
            // 
            // dgv_L1
            // 
            this.dgv_L1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_L1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.L1Name});
            this.dgv_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_L1.Location = new System.Drawing.Point(3, 3);
            this.dgv_L1.Name = "dgv_L1";
            this.dgv_L1.RowTemplate.Height = 23;
            this.dgv_L1.Size = new System.Drawing.Size(303, 199);
            this.dgv_L1.TabIndex = 0;
            // 
            // L1Name
            // 
            this.L1Name.HeaderText = "因素名称";
            this.L1Name.Name = "L1Name";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(772, 379);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(99, 66);
            this.btn_create.TabIndex = 16;
            this.btn_create.Text = "创建设备表";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPage_L1);
            this.tabControl1.Controls.Add(this.tbPage_L2);
            this.tabControl1.Controls.Add(this.tbPage_L3);
            this.tabControl1.Location = new System.Drawing.Point(576, 118);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 231);
            this.tabControl1.TabIndex = 15;
            // 
            // btn_Right
            // 
            this.btn_Right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Right.BackgroundImage")));
            this.btn_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Right.Location = new System.Drawing.Point(232, 193);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(58, 34);
            this.btn_Right.TabIndex = 14;
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Left.BackgroundImage")));
            this.btn_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Left.Location = new System.Drawing.Point(232, 105);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(58, 38);
            this.btn_Left.TabIndex = 13;
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // btn_Q
            // 
            this.btn_Q.Location = new System.Drawing.Point(618, 379);
            this.btn_Q.Name = "btn_Q";
            this.btn_Q.Size = new System.Drawing.Size(99, 66);
            this.btn_Q.TabIndex = 20;
            this.btn_Q.Text = "查询完整信息";
            this.btn_Q.UseVisualStyleBackColor = true;
            // 
            // EquipConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Q);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Right);
            this.Controls.Add(this.btn_Left);
            this.Name = "EquipConfig";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.EquipConfig_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbPage_L3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L3)).EndInit();
            this.tbPage_L2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L2)).EndInit();
            this.tbPage_L1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.ListBox lbox_Equip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox lbox_Type;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbox_Num;
        private System.Windows.Forms.Label lab_Num;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tbPage_L3;
        private System.Windows.Forms.TabPage tbPage_L2;
        private System.Windows.Forms.TabPage tbPage_L1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.DataGridView dgv_L3;
        private System.Windows.Forms.DataGridView dgv_L2;
        private System.Windows.Forms.DataGridView dgv_L1;
        private System.Windows.Forms.DataGridViewTextBoxColumn L3Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn L2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn L1Name;
        private System.Windows.Forms.Button btn_Q;
    }
}
