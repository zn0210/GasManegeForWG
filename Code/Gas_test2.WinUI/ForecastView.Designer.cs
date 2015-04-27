namespace Gas_test2.WinUI
{
    partial class ForecastView
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
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Equip = new System.Windows.Forms.TextBox();
            this.lab_Equip = new System.Windows.Forms.Label();
            this.txtAlg = new System.Windows.Forms.TextBox();
            this.lab_Alg = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtNowtime = new System.Windows.Forms.TextBox();
            this.lab_Duration = new System.Windows.Forms.Label();
            this.lab_Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tbCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Controls.Add(this.tbCtrl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 366);
            this.panel1.TabIndex = 1;
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tabPage1);
            this.tbCtrl.Controls.Add(this.tabPage2);
            this.tbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(744, 366);
            this.tbCtrl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zg1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zg1
            // 
            this.zg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zg1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zg1.Location = new System.Drawing.Point(3, 3);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(730, 330);
            this.zg1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DG1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 336);
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
            this.DG1.Size = new System.Drawing.Size(730, 330);
            this.DG1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 91);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txt_Equip);
            this.panel4.Controls.Add(this.lab_Equip);
            this.panel4.Controls.Add(this.txtAlg);
            this.panel4.Controls.Add(this.lab_Alg);
            this.panel4.Controls.Add(this.txtDuration);
            this.panel4.Controls.Add(this.txtNowtime);
            this.panel4.Controls.Add(this.lab_Duration);
            this.panel4.Controls.Add(this.lab_Time);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(683, 91);
            this.panel4.TabIndex = 12;
            // 
            // txt_Equip
            // 
            this.txt_Equip.Location = new System.Drawing.Point(152, 16);
            this.txt_Equip.Name = "txt_Equip";
            this.txt_Equip.ReadOnly = true;
            this.txt_Equip.Size = new System.Drawing.Size(119, 26);
            this.txt_Equip.TabIndex = 13;
            // 
            // lab_Equip
            // 
            this.lab_Equip.AutoSize = true;
            this.lab_Equip.Location = new System.Drawing.Point(66, 19);
            this.lab_Equip.Name = "lab_Equip";
            this.lab_Equip.Size = new System.Drawing.Size(88, 16);
            this.lab_Equip.TabIndex = 12;
            this.lab_Equip.Text = "选择设备：";
            // 
            // txtAlg
            // 
            this.txtAlg.Location = new System.Drawing.Point(152, 59);
            this.txtAlg.Name = "txtAlg";
            this.txtAlg.ReadOnly = true;
            this.txtAlg.Size = new System.Drawing.Size(119, 26);
            this.txtAlg.TabIndex = 11;
            // 
            // lab_Alg
            // 
            this.lab_Alg.AutoSize = true;
            this.lab_Alg.Location = new System.Drawing.Point(66, 62);
            this.lab_Alg.Name = "lab_Alg";
            this.lab_Alg.Size = new System.Drawing.Size(88, 16);
            this.lab_Alg.TabIndex = 10;
            this.lab_Alg.Text = "预测算法：";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(387, 59);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(134, 26);
            this.txtDuration.TabIndex = 9;
            // 
            // txtNowtime
            // 
            this.txtNowtime.Location = new System.Drawing.Point(387, 16);
            this.txtNowtime.Name = "txtNowtime";
            this.txtNowtime.ReadOnly = true;
            this.txtNowtime.Size = new System.Drawing.Size(134, 26);
            this.txtNowtime.TabIndex = 8;
            // 
            // lab_Duration
            // 
            this.lab_Duration.AutoSize = true;
            this.lab_Duration.Location = new System.Drawing.Point(293, 62);
            this.lab_Duration.Name = "lab_Duration";
            this.lab_Duration.Size = new System.Drawing.Size(88, 16);
            this.lab_Duration.TabIndex = 7;
            this.lab_Duration.Text = "预测时长：";
            // 
            // lab_Time
            // 
            this.lab_Time.AutoSize = true;
            this.lab_Time.Location = new System.Drawing.Point(293, 19);
            this.lab_Time.Name = "lab_Time";
            this.lab_Time.Size = new System.Drawing.Size(88, 16);
            this.lab_Time.TabIndex = 6;
            this.lab_Time.Text = "当前时间：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ForecastView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tree_Equip);
            this.Name = "ForecastView";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.ForecastView_Load);
            this.Leave += new System.EventHandler(this.ForecastView_Leave);
            this.panel1.ResumeLayout(false);
            this.tbCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree_Equip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtAlg;
        private System.Windows.Forms.Label lab_Alg;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtNowtime;
        private System.Windows.Forms.Label lab_Duration;
        private System.Windows.Forms.Label lab_Time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_Equip;
        private System.Windows.Forms.Label lab_Equip;
        private System.Windows.Forms.Timer timer2;
    }
}
