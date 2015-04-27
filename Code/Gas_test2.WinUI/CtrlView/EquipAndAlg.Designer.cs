namespace Gas_test2.WinUI.CtrlView
{
    partial class EquipAndAlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tree_Alg = new System.Windows.Forms.TreeView();
            this.cbox_Eq = new System.Windows.Forms.ComboBox();
            this.gbox1 = new System.Windows.Forms.GroupBox();
            this.DG_Alg = new System.Windows.Forms.DataGridView();
            this.C_Alg = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Factor1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Factor2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Factor3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C_Factor4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.gbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Alg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree_Alg
            // 
            this.Tree_Alg.Dock = System.Windows.Forms.DockStyle.Right;
            this.Tree_Alg.Location = new System.Drawing.Point(642, 0);
            this.Tree_Alg.Name = "Tree_Alg";
            this.Tree_Alg.Size = new System.Drawing.Size(302, 457);
            this.Tree_Alg.TabIndex = 6;
            this.Tree_Alg.DoubleClick += new System.EventHandler(this.Tree_Alg_DoubleClick);
            // 
            // cbox_Eq
            // 
            this.cbox_Eq.FormattingEnabled = true;
            this.cbox_Eq.Location = new System.Drawing.Point(33, 31);
            this.cbox_Eq.Name = "cbox_Eq";
            this.cbox_Eq.Size = new System.Drawing.Size(193, 24);
            this.cbox_Eq.TabIndex = 0;
            this.cbox_Eq.SelectedIndexChanged += new System.EventHandler(this.cbox_Eq_SelectedIndexChanged);
            // 
            // gbox1
            // 
            this.gbox1.Controls.Add(this.btn_Enter);
            this.gbox1.Controls.Add(this.cbox_Eq);
            this.gbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox1.Font = new System.Drawing.Font("宋体", 12F);
            this.gbox1.Location = new System.Drawing.Point(0, 0);
            this.gbox1.Name = "gbox1";
            this.gbox1.Size = new System.Drawing.Size(642, 85);
            this.gbox1.TabIndex = 7;
            this.gbox1.TabStop = false;
            this.gbox1.Text = "选择设备：";
            // 
            // DG_Alg
            // 
            this.DG_Alg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Alg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Alg,
            this.C_Factor1,
            this.C_Factor2,
            this.C_Factor3,
            this.C_Factor4});
            this.DG_Alg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Alg.Location = new System.Drawing.Point(0, 0);
            this.DG_Alg.Name = "DG_Alg";
            this.DG_Alg.RowTemplate.Height = 23;
            this.DG_Alg.Size = new System.Drawing.Size(642, 372);
            this.DG_Alg.TabIndex = 0;
            // 
            // C_Alg
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F);
            this.C_Alg.DefaultCellStyle = dataGridViewCellStyle2;
            this.C_Alg.HeaderText = "可选算法";
            this.C_Alg.Name = "C_Alg";
            // 
            // C_Factor1
            // 
            this.C_Factor1.HeaderText = "算法因素1";
            this.C_Factor1.Name = "C_Factor1";
            // 
            // C_Factor2
            // 
            this.C_Factor2.HeaderText = "算法因素2";
            this.C_Factor2.Name = "C_Factor2";
            // 
            // C_Factor3
            // 
            this.C_Factor3.HeaderText = "算法因素3";
            this.C_Factor3.Name = "C_Factor3";
            // 
            // C_Factor4
            // 
            this.C_Factor4.HeaderText = "算法因素4";
            this.C_Factor4.Name = "C_Factor4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DG_Alg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 372);
            this.panel1.TabIndex = 8;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Location = new System.Drawing.Point(535, 31);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(75, 23);
            this.btn_Enter.TabIndex = 1;
            this.btn_Enter.Text = "确认";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // EquipAndAlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbox1);
            this.Controls.Add(this.Tree_Alg);
            this.Name = "EquipAndAlg";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.EquipAndAlg_Load);
            this.gbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Alg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree_Alg;
        private System.Windows.Forms.ComboBox cbox_Eq;
        private System.Windows.Forms.GroupBox gbox1;
        private System.Windows.Forms.DataGridView DG_Alg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Alg;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Factor1;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Factor2;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Factor3;
        private System.Windows.Forms.DataGridViewComboBoxColumn C_Factor4;
        private System.Windows.Forms.Button btn_Enter;

    }
}
