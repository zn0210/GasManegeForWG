namespace Gas_test2.WinUI
{
    partial class ForecastConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DG_Forecast = new System.Windows.Forms.DataGridView();
            this.C_Equip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Alg = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Trigger = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Duration = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Forecast)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 100);
            this.panel1.TabIndex = 2;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Start.Location = new System.Drawing.Point(754, 31);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(154, 37);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "启动预测";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DG_Forecast);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 357);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预测功能相关设置：";
            // 
            // DG_Forecast
            // 
            this.DG_Forecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Forecast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Equip,
            this.C_Alg,
            this.C_Trigger,
            this.C_Duration});
            this.DG_Forecast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Forecast.Location = new System.Drawing.Point(3, 22);
            this.DG_Forecast.Name = "DG_Forecast";
            this.DG_Forecast.RowTemplate.Height = 23;
            this.DG_Forecast.Size = new System.Drawing.Size(938, 332);
            this.DG_Forecast.TabIndex = 0;
            // 
            // C_Equip
            // 
            this.C_Equip.HeaderText = "设备种类";
            this.C_Equip.Name = "C_Equip";
            this.C_Equip.ReadOnly = true;
            // 
            // C_Alg
            // 
            this.C_Alg.HeaderText = "算法选择";
            this.C_Alg.Name = "C_Alg";
            // 
            // C_Trigger
            // 
            this.C_Trigger.HeaderText = "预测时间间隔";
            this.C_Trigger.Items.AddRange(new object[] {
            "5",
            "10"});
            this.C_Trigger.Name = "C_Trigger";
            this.C_Trigger.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_Trigger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // C_Duration
            // 
            this.C_Duration.HeaderText = "预测时长";
            this.C_Duration.Items.AddRange(new object[] {
            "15",
            "30",
            "60"});
            this.C_Duration.Name = "C_Duration";
            this.C_Duration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ForecastConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ForecastConfig";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.ForecastConfig_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Forecast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DG_Forecast;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Equip;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Alg;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Trigger;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Duration;


    }
}
