namespace Gas_test2.WinUI
{
    partial class GasometerView
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
            this.Tree_Ometer = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CkListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lab_EndTime = new System.Windows.Forms.Label();
            this.lab_StartTime = new System.Windows.Forms.Label();
            this.DTP2 = new System.Windows.Forms.DateTimePicker();
            this.DTP1 = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_Equip = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btn_Forecast = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tree_Ometer
            // 
            this.Tree_Ometer.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tree_Ometer.Location = new System.Drawing.Point(0, 0);
            this.Tree_Ometer.Name = "Tree_Ometer";
            this.Tree_Ometer.Size = new System.Drawing.Size(200, 457);
            this.Tree_Ometer.TabIndex = 0;
            this.Tree_Ometer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_Ometer_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CkListBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btn_Forecast);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 104);
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
            this.CkListBox1.Location = new System.Drawing.Point(472, 0);
            this.CkListBox1.MultiColumn = true;
            this.CkListBox1.Name = "CkListBox1";
            this.CkListBox1.Size = new System.Drawing.Size(150, 104);
            this.CkListBox1.TabIndex = 16;
            this.CkListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CkListBox1_ItemCheck);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lab_EndTime);
            this.panel3.Controls.Add(this.lab_StartTime);
            this.panel3.Controls.Add(this.DTP2);
            this.panel3.Controls.Add(this.DTP1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(204, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 104);
            this.panel3.TabIndex = 15;
            // 
            // lab_EndTime
            // 
            this.lab_EndTime.AutoSize = true;
            this.lab_EndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_EndTime.Location = new System.Drawing.Point(21, 59);
            this.lab_EndTime.Name = "lab_EndTime";
            this.lab_EndTime.Size = new System.Drawing.Size(80, 16);
            this.lab_EndTime.TabIndex = 11;
            this.lab_EndTime.Text = "截止时间:";
            // 
            // lab_StartTime
            // 
            this.lab_StartTime.AutoSize = true;
            this.lab_StartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_StartTime.Location = new System.Drawing.Point(21, 23);
            this.lab_StartTime.Name = "lab_StartTime";
            this.lab_StartTime.Size = new System.Drawing.Size(88, 16);
            this.lab_StartTime.TabIndex = 10;
            this.lab_StartTime.Text = "起始时间：";
            // 
            // DTP2
            // 
            this.DTP2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP2.Location = new System.Drawing.Point(115, 51);
            this.DTP2.Name = "DTP2";
            this.DTP2.Size = new System.Drawing.Size(144, 26);
            this.DTP2.TabIndex = 9;
            this.DTP2.Value = new System.DateTime(2013, 6, 17, 12, 41, 0, 0);
            // 
            // DTP1
            // 
            this.DTP1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP1.Location = new System.Drawing.Point(115, 17);
            this.DTP1.Name = "DTP1";
            this.DTP1.Size = new System.Drawing.Size(144, 26);
            this.DTP1.TabIndex = 8;
            this.DTP1.Value = new System.DateTime(2013, 6, 17, 10, 41, 0, 0);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.txt_Equip);
            this.panel4.Controls.Add(this.lbl2);
            this.panel4.Controls.Add(this.lbl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(204, 104);
            this.panel4.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "15",
            "30",
            "60"});
            this.comboBox1.Location = new System.Drawing.Point(98, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "15";
            // 
            // txt_Equip
            // 
            this.txt_Equip.Location = new System.Drawing.Point(100, 14);
            this.txt_Equip.Name = "txt_Equip";
            this.txt_Equip.ReadOnly = true;
            this.txt_Equip.Size = new System.Drawing.Size(98, 26);
            this.txt_Equip.TabIndex = 8;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(20, 54);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(88, 16);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "预测时长：";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(20, 17);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(88, 16);
            this.lbl1.TabIndex = 6;
            this.lbl1.Text = "当前设备：";
            // 
            // btn_Forecast
            // 
            this.btn_Forecast.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_Forecast.Location = new System.Drawing.Point(643, 35);
            this.btn_Forecast.Name = "btn_Forecast";
            this.btn_Forecast.Size = new System.Drawing.Size(70, 34);
            this.btn_Forecast.TabIndex = 0;
            this.btn_Forecast.Text = "预测";
            this.btn_Forecast.UseVisualStyleBackColor = true;
            this.btn_Forecast.Click += new System.EventHandler(this.btn_Forecast_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbCtrl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 353);
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
            this.tbCtrl.Size = new System.Drawing.Size(744, 353);
            this.tbCtrl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zg1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 327);
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
            this.zg1.Size = new System.Drawing.Size(730, 321);
            this.zg1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DG1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 327);
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
            this.DG1.Size = new System.Drawing.Size(730, 321);
            this.DG1.TabIndex = 0;
            // 
            // GasometerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tree_Ometer);
            this.Name = "GasometerView";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.GasometerView_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree_Ometer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button btn_Forecast;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_Equip;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lab_EndTime;
        private System.Windows.Forms.Label lab_StartTime;
        private System.Windows.Forms.DateTimePicker DTP2;
        private System.Windows.Forms.DateTimePicker DTP1;
        public System.Windows.Forms.CheckedListBox CkListBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
