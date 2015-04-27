namespace Gas_test2.WinUI
{
    partial class QueryView
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
            this.components = new System.ComponentModel.Container();
            this.Tree_Equip = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CkListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lab_EndTime = new System.Windows.Forms.Label();
            this.lab_StartTime = new System.Windows.Forms.Label();
            this.DTP2 = new System.Windows.Forms.DateTimePicker();
            this.DTP1 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Equip = new System.Windows.Forms.TextBox();
            this.lab = new System.Windows.Forms.Label();
            this.btn_Query = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tree_Equip
            // 
            this.Tree_Equip.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tree_Equip.Location = new System.Drawing.Point(0, 0);
            this.Tree_Equip.Name = "Tree_Equip";
            this.Tree_Equip.Size = new System.Drawing.Size(200, 457);
            this.Tree_Equip.TabIndex = 0;
            this.Tree_Equip.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_Equip_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CkListBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_Query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 124);
            this.panel1.TabIndex = 1;
            // 
            // CkListBox1
            // 
            this.CkListBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.CkListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.CkListBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CkListBox1.FormattingEnabled = true;
            this.CkListBox1.Items.AddRange(new object[] {
            "煤气实际流量",
            "煤气预测流量",
            "预测误差"});
            this.CkListBox1.Location = new System.Drawing.Point(479, 0);
            this.CkListBox1.Name = "CkListBox1";
            this.CkListBox1.Size = new System.Drawing.Size(128, 124);
            this.CkListBox1.TabIndex = 8;
            this.CkListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CkListBox1_ItemCheck);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lab_EndTime);
            this.panel4.Controls.Add(this.lab_StartTime);
            this.panel4.Controls.Add(this.DTP2);
            this.panel4.Controls.Add(this.DTP1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(178, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(301, 124);
            this.panel4.TabIndex = 7;
            // 
            // lab_EndTime
            // 
            this.lab_EndTime.AutoSize = true;
            this.lab_EndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_EndTime.Location = new System.Drawing.Point(25, 69);
            this.lab_EndTime.Name = "lab_EndTime";
            this.lab_EndTime.Size = new System.Drawing.Size(80, 16);
            this.lab_EndTime.TabIndex = 11;
            this.lab_EndTime.Text = "截止时间:";
            // 
            // lab_StartTime
            // 
            this.lab_StartTime.AutoSize = true;
            this.lab_StartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_StartTime.Location = new System.Drawing.Point(25, 33);
            this.lab_StartTime.Name = "lab_StartTime";
            this.lab_StartTime.Size = new System.Drawing.Size(88, 16);
            this.lab_StartTime.TabIndex = 10;
            this.lab_StartTime.Text = "起始时间：";
            // 
            // DTP2
            // 
            this.DTP2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DTP2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP2.Location = new System.Drawing.Point(119, 64);
            this.DTP2.Name = "DTP2";
            this.DTP2.Size = new System.Drawing.Size(153, 26);
            this.DTP2.TabIndex = 9;
            this.DTP2.Value = new System.DateTime(2013, 6, 17, 12, 41, 0, 0);
            // 
            // DTP1
            // 
            this.DTP1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DTP1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP1.Location = new System.Drawing.Point(119, 28);
            this.DTP1.Name = "DTP1";
            this.DTP1.Size = new System.Drawing.Size(153, 26);
            this.DTP1.TabIndex = 8;
            this.DTP1.Value = new System.DateTime(2013, 6, 17, 10, 41, 0, 0);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Equip);
            this.panel3.Controls.Add(this.lab);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 124);
            this.panel3.TabIndex = 6;
            // 
            // txt_Equip
            // 
            this.txt_Equip.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_Equip.Location = new System.Drawing.Point(19, 64);
            this.txt_Equip.Name = "txt_Equip";
            this.txt_Equip.ReadOnly = true;
            this.txt_Equip.Size = new System.Drawing.Size(135, 26);
            this.txt_Equip.TabIndex = 12;
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab.Location = new System.Drawing.Point(16, 28);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(120, 16);
            this.lab.TabIndex = 11;
            this.lab.Text = "当前查询设备：";
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(638, 33);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(70, 34);
            this.btn_Query.TabIndex = 5;
            this.btn_Query.Text = "查询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbCtrl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 333);
            this.panel2.TabIndex = 2;
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tabPage1);
            this.tbCtrl.Controls.Add(this.tabPage2);
            this.tbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCtrl.ItemSize = new System.Drawing.Size(100, 18);
            this.tbCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(744, 333);
            this.tbCtrl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zg1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zg1
            // 
            this.zg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zg1.Location = new System.Drawing.Point(3, 3);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(730, 301);
            this.zg1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DG1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DG1
            // 
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG1.Location = new System.Drawing.Point(3, 3);
            this.DG1.Name = "DG1";
            this.DG1.RowTemplate.Height = 23;
            this.DG1.Size = new System.Drawing.Size(730, 301);
            this.DG1.TabIndex = 0;
            // 
            // QueryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tree_Equip);
            this.Name = "QueryView";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.QueryView_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree_Equip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DG1;
        public System.Windows.Forms.CheckedListBox CkListBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lab_EndTime;
        private System.Windows.Forms.Label lab_StartTime;
        private System.Windows.Forms.DateTimePicker DTP2;
        private System.Windows.Forms.DateTimePicker DTP1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Equip;
        private System.Windows.Forms.Label lab;
    }
}
