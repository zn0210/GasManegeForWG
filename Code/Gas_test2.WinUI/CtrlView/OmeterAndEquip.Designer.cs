namespace Gas_test2.WinUI.CtrlView
{
    partial class OmeterAndEquip
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbox_Ometer = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DG_In = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DG_Out = new System.Windows.Forms.DataGridView();
            this.C_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.C_Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_In)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Out)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Enter);
            this.groupBox1.Controls.Add(this.lbox_Ometer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 457);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "煤气柜列表：";
            // 
            // lbox_Ometer
            // 
            this.lbox_Ometer.FormattingEnabled = true;
            this.lbox_Ometer.ItemHeight = 16;
            this.lbox_Ometer.Location = new System.Drawing.Point(60, 50);
            this.lbox_Ometer.Name = "lbox_Ometer";
            this.lbox_Ometer.Size = new System.Drawing.Size(161, 260);
            this.lbox_Ometer.TabIndex = 0;
            this.lbox_Ometer.SelectedIndexChanged += new System.EventHandler(this.lbox_Ometer_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DG_In);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(280, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 229);
            this.panel1.TabIndex = 1;
            // 
            // DG_In
            // 
            this.DG_In.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_In.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DG_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_In.Location = new System.Drawing.Point(159, 0);
            this.DG_In.Margin = new System.Windows.Forms.Padding(8);
            this.DG_In.Name = "DG_In";
            this.DG_In.RowTemplate.Height = 23;
            this.DG_In.Size = new System.Drawing.Size(505, 229);
            this.DG_In.TabIndex = 2;
            this.DG_In.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_In_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "设备名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择状态";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "百分比";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(159, 229);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(28, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入设备：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DG_Out);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(280, 229);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 228);
            this.panel2.TabIndex = 2;
            // 
            // DG_Out
            // 
            this.DG_Out.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Out.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Name,
            this.C_Flag,
            this.C_Percent});
            this.DG_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Out.Location = new System.Drawing.Point(159, 0);
            this.DG_Out.Margin = new System.Windows.Forms.Padding(8);
            this.DG_Out.Name = "DG_Out";
            this.DG_Out.RowTemplate.Height = 23;
            this.DG_Out.Size = new System.Drawing.Size(505, 228);
            this.DG_Out.TabIndex = 1;
            // 
            // C_Name
            // 
            this.C_Name.HeaderText = "设备名称";
            this.C_Name.Name = "C_Name";
            this.C_Name.ReadOnly = true;
            // 
            // C_Flag
            // 
            this.C_Flag.HeaderText = "选择状态";
            this.C_Flag.Name = "C_Flag";
            // 
            // C_Percent
            // 
            this.C_Percent.HeaderText = "百分比";
            this.C_Percent.Name = "C_Percent";
            this.C_Percent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_Percent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(159, 228);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(38, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "输出设备：";
            // 
            // btn_Enter
            // 
            this.btn_Enter.Location = new System.Drawing.Point(90, 380);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(75, 23);
            this.btn_Enter.TabIndex = 1;
            this.btn_Enter.Text = "确认";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // OmeterAndEquip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "OmeterAndEquip";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.OmeterAndEquip_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_In)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Out)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbox_Ometer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DG_In;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG_Out;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Percent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Enter;
    }
}
