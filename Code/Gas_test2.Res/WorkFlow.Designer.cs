namespace Gas_test2.Res
{
    partial class WorkFlow
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
            this.lbDrugDict = new System.Windows.Forms.LinkLabel();
            this.lbDrugIn = new System.Windows.Forms.LinkLabel();
            this.lbDrugLimit = new System.Windows.Forms.LinkLabel();
            this.lbDrugSale = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbDrugDict
            // 
            this.lbDrugDict.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lbDrugDict.AutoSize = true;
            this.lbDrugDict.BackColor = System.Drawing.Color.Transparent;
            this.lbDrugDict.Font = new System.Drawing.Font("宋体", 16F);
            this.lbDrugDict.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugDict.Location = new System.Drawing.Point(563, 60);
            this.lbDrugDict.Name = "lbDrugDict";
            this.lbDrugDict.Size = new System.Drawing.Size(142, 22);
            this.lbDrugDict.TabIndex = 19;
            this.lbDrugDict.TabStop = true;
            this.lbDrugDict.Text = "能源系统配置";
            this.lbDrugDict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDrugDict.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbDrugDict.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDrugDict_LinkClicked);
            // 
            // lbDrugIn
            // 
            this.lbDrugIn.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lbDrugIn.AutoSize = true;
            this.lbDrugIn.BackColor = System.Drawing.Color.Transparent;
            this.lbDrugIn.Font = new System.Drawing.Font("宋体", 16F);
            this.lbDrugIn.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugIn.Location = new System.Drawing.Point(536, 182);
            this.lbDrugIn.Name = "lbDrugIn";
            this.lbDrugIn.Size = new System.Drawing.Size(230, 22);
            this.lbDrugIn.TabIndex = 19;
            this.lbDrugIn.TabStop = true;
            this.lbDrugIn.Text = "煤气设备节点数据查询";
            this.lbDrugIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDrugIn.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbDrugIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDrugIn_LinkClicked);
            // 
            // lbDrugLimit
            // 
            this.lbDrugLimit.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lbDrugLimit.AutoSize = true;
            this.lbDrugLimit.BackColor = System.Drawing.Color.Transparent;
            this.lbDrugLimit.Font = new System.Drawing.Font("宋体", 16F);
            this.lbDrugLimit.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugLimit.Location = new System.Drawing.Point(536, 302);
            this.lbDrugLimit.Name = "lbDrugLimit";
            this.lbDrugLimit.Size = new System.Drawing.Size(230, 22);
            this.lbDrugLimit.TabIndex = 19;
            this.lbDrugLimit.TabStop = true;
            this.lbDrugLimit.Text = "煤气设备节点数据预测";
            this.lbDrugLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDrugLimit.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbDrugLimit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDrugLimit_LinkClicked);
            // 
            // lbDrugSale
            // 
            this.lbDrugSale.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lbDrugSale.AutoSize = true;
            this.lbDrugSale.BackColor = System.Drawing.Color.Transparent;
            this.lbDrugSale.Font = new System.Drawing.Font("宋体", 16F);
            this.lbDrugSale.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugSale.Location = new System.Drawing.Point(536, 422);
            this.lbDrugSale.Name = "lbDrugSale";
            this.lbDrugSale.Size = new System.Drawing.Size(252, 22);
            this.lbDrugSale.TabIndex = 19;
            this.lbDrugSale.TabStop = true;
            this.lbDrugSale.Text = "煤气柜位数据查询及预测";
            this.lbDrugSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDrugSale.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbDrugSale.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDrugSale_LinkClicked);
            // 
            // WorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.lbDrugSale);
            this.Controls.Add(this.lbDrugLimit);
            this.Controls.Add(this.lbDrugIn);
            this.Controls.Add(this.lbDrugDict);
            this.Name = "WorkFlow";
            this.Size = new System.Drawing.Size(1097, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbDrugDict;
        private System.Windows.Forms.LinkLabel lbDrugIn;
        private System.Windows.Forms.LinkLabel lbDrugLimit;
        private System.Windows.Forms.LinkLabel lbDrugSale;

    }
}
