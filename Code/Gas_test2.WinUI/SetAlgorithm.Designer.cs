namespace Gas_test2.WinUI
{
    partial class SetAlgorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetAlgorithm));
            this.gbox1 = new System.Windows.Forms.GroupBox();
            this.cbox_Eq = new System.Windows.Forms.ComboBox();
            this.gbox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_Alg = new System.Windows.Forms.ListBox();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.lbox_UsedAlg = new System.Windows.Forms.ListBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.gbox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbox_Factor = new System.Windows.Forms.ListBox();
            this.btn_Right2 = new System.Windows.Forms.Button();
            this.btn_Left2 = new System.Windows.Forms.Button();
            this.lbox_UsedFact = new System.Windows.Forms.ListBox();
            this.btn_Q = new System.Windows.Forms.Button();
            this.gbox1.SuspendLayout();
            this.gbox2.SuspendLayout();
            this.gbox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox1
            // 
            this.gbox1.Controls.Add(this.cbox_Eq);
            this.gbox1.Location = new System.Drawing.Point(13, 12);
            this.gbox1.Name = "gbox1";
            this.gbox1.Size = new System.Drawing.Size(255, 85);
            this.gbox1.TabIndex = 3;
            this.gbox1.TabStop = false;
            this.gbox1.Text = "选择设备：";
            // 
            // cbox_Eq
            // 
            this.cbox_Eq.FormattingEnabled = true;
            this.cbox_Eq.Location = new System.Drawing.Point(33, 31);
            this.cbox_Eq.Name = "cbox_Eq";
            this.cbox_Eq.Size = new System.Drawing.Size(193, 20);
            this.cbox_Eq.TabIndex = 0;
            this.cbox_Eq.SelectedIndexChanged += new System.EventHandler(this.cbox_Eq_SelectedIndexChanged);
            // 
            // gbox2
            // 
            this.gbox2.Controls.Add(this.label2);
            this.gbox2.Controls.Add(this.label1);
            this.gbox2.Controls.Add(this.lbox_Alg);
            this.gbox2.Controls.Add(this.btn_Right);
            this.gbox2.Controls.Add(this.btn_Left);
            this.gbox2.Controls.Add(this.lbox_UsedAlg);
            this.gbox2.Location = new System.Drawing.Point(13, 113);
            this.gbox2.Name = "gbox2";
            this.gbox2.Size = new System.Drawing.Size(397, 374);
            this.gbox2.TabIndex = 4;
            this.gbox2.TabStop = false;
            this.gbox2.Text = "算法配置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "选入的算法：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "可选算法：";
            // 
            // lbox_Alg
            // 
            this.lbox_Alg.FormattingEnabled = true;
            this.lbox_Alg.ItemHeight = 12;
            this.lbox_Alg.Location = new System.Drawing.Point(33, 46);
            this.lbox_Alg.Name = "lbox_Alg";
            this.lbox_Alg.Size = new System.Drawing.Size(113, 292);
            this.lbox_Alg.TabIndex = 9;
            // 
            // btn_Right
            // 
            this.btn_Right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Right.BackgroundImage")));
            this.btn_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Right.Location = new System.Drawing.Point(168, 222);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(58, 34);
            this.btn_Right.TabIndex = 8;
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Left.BackgroundImage")));
            this.btn_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Left.Location = new System.Drawing.Point(168, 114);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(58, 38);
            this.btn_Left.TabIndex = 7;
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // lbox_UsedAlg
            // 
            this.lbox_UsedAlg.FormattingEnabled = true;
            this.lbox_UsedAlg.ItemHeight = 12;
            this.lbox_UsedAlg.Location = new System.Drawing.Point(243, 46);
            this.lbox_UsedAlg.Name = "lbox_UsedAlg";
            this.lbox_UsedAlg.Size = new System.Drawing.Size(122, 292);
            this.lbox_UsedAlg.TabIndex = 10;
            this.lbox_UsedAlg.SelectedIndexChanged += new System.EventHandler(this.lbox_UsedAlg_SelectedIndexChanged);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Location = new System.Drawing.Point(307, 62);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(103, 45);
            this.btn_Enter.TabIndex = 5;
            this.btn_Enter.Text = "创建算法表";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // gbox3
            // 
            this.gbox3.Controls.Add(this.label4);
            this.gbox3.Controls.Add(this.label3);
            this.gbox3.Controls.Add(this.lbox_Factor);
            this.gbox3.Controls.Add(this.btn_Right2);
            this.gbox3.Controls.Add(this.btn_Left2);
            this.gbox3.Controls.Add(this.lbox_UsedFact);
            this.gbox3.Location = new System.Drawing.Point(445, 28);
            this.gbox3.Name = "gbox3";
            this.gbox3.Size = new System.Drawing.Size(477, 454);
            this.gbox3.TabIndex = 6;
            this.gbox3.TabStop = false;
            this.gbox3.Text = "算法参数配置：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "选择的因素：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "可选的因素：";
            // 
            // lbox_Factor
            // 
            this.lbox_Factor.FormattingEnabled = true;
            this.lbox_Factor.ItemHeight = 12;
            this.lbox_Factor.Location = new System.Drawing.Point(62, 58);
            this.lbox_Factor.Name = "lbox_Factor";
            this.lbox_Factor.Size = new System.Drawing.Size(113, 364);
            this.lbox_Factor.TabIndex = 13;
            // 
            // btn_Right2
            // 
            this.btn_Right2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Right2.BackgroundImage")));
            this.btn_Right2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Right2.Location = new System.Drawing.Point(197, 234);
            this.btn_Right2.Name = "btn_Right2";
            this.btn_Right2.Size = new System.Drawing.Size(58, 34);
            this.btn_Right2.TabIndex = 12;
            this.btn_Right2.UseVisualStyleBackColor = true;
            this.btn_Right2.Click += new System.EventHandler(this.btn_Right2_Click);
            // 
            // btn_Left2
            // 
            this.btn_Left2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Left2.BackgroundImage")));
            this.btn_Left2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Left2.Location = new System.Drawing.Point(197, 126);
            this.btn_Left2.Name = "btn_Left2";
            this.btn_Left2.Size = new System.Drawing.Size(58, 38);
            this.btn_Left2.TabIndex = 11;
            this.btn_Left2.UseVisualStyleBackColor = true;
            this.btn_Left2.Click += new System.EventHandler(this.btn_Left2_Click);
            // 
            // lbox_UsedFact
            // 
            this.lbox_UsedFact.FormattingEnabled = true;
            this.lbox_UsedFact.ItemHeight = 12;
            this.lbox_UsedFact.Location = new System.Drawing.Point(272, 58);
            this.lbox_UsedFact.Name = "lbox_UsedFact";
            this.lbox_UsedFact.Size = new System.Drawing.Size(122, 364);
            this.lbox_UsedFact.TabIndex = 14;
            // 
            // btn_Q
            // 
            this.btn_Q.Location = new System.Drawing.Point(307, 11);
            this.btn_Q.Name = "btn_Q";
            this.btn_Q.Size = new System.Drawing.Size(103, 45);
            this.btn_Q.TabIndex = 7;
            this.btn_Q.Text = "查询关系图";
            this.btn_Q.UseVisualStyleBackColor = true;
            // 
            // SetAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Q);
            this.Controls.Add(this.gbox3);
            this.Controls.Add(this.gbox1);
            this.Controls.Add(this.gbox2);
            this.Controls.Add(this.btn_Enter);
            this.Name = "SetAlgorithm";
            this.Size = new System.Drawing.Size(973, 485);
            this.Load += new System.EventHandler(this.SetAlgorithm_Load);
            this.gbox1.ResumeLayout(false);
            this.gbox2.ResumeLayout(false);
            this.gbox2.PerformLayout();
            this.gbox3.ResumeLayout(false);
            this.gbox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox1;
        private System.Windows.Forms.GroupBox gbox2;
        private System.Windows.Forms.ListBox lbox_Alg;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.ListBox lbox_UsedAlg;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.GroupBox gbox3;
        private System.Windows.Forms.ComboBox cbox_Eq;
        private System.Windows.Forms.ListBox lbox_Factor;
        private System.Windows.Forms.Button btn_Right2;
        private System.Windows.Forms.Button btn_Left2;
        private System.Windows.Forms.ListBox lbox_UsedFact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Q;
    }
}
