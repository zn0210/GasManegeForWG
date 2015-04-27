namespace Gas_test2.WinUI.FormView
{
    partial class ClearData
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
            this.lbox_Table = new System.Windows.Forms.ListBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbox_Table
            // 
            this.lbox_Table.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbox_Table.FormattingEnabled = true;
            this.lbox_Table.ItemHeight = 16;
            this.lbox_Table.Location = new System.Drawing.Point(33, 22);
            this.lbox_Table.Name = "lbox_Table";
            this.lbox_Table.Size = new System.Drawing.Size(208, 244);
            this.lbox_Table.TabIndex = 0;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Location = new System.Drawing.Point(33, 293);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 30);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Location = new System.Drawing.Point(166, 293);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // ClearData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 349);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.lbox_Table);
            this.Name = "ClearData";
            this.Text = "ClearData";
            this.Load += new System.EventHandler(this.ClearData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_Table;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Close;
    }
}