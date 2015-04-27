using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Gas_test2.WinUI;

namespace Gas_test2.Res
{
    partial class WorkFlow : UserControl
    {
        public WorkFlow()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);

            InitializeComponent();
        }                

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            g.DrawImage(Properties.Resources.FLow2, 0, 0, this.Width, this.Height);
        }

        

        private void lbDrugDict_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Type T=typeof(Config);

            //System.Type T = typeof(DrugDictList);
            EAS.Application.Instance.OpenModule(T);
        }

        

        private void lbDrugIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Type T = typeof(QueryView);
            //System.Type T = typeof(DrugIn);
            EAS.Application.Instance.OpenModule(T);
        }

       

        

        private void lbDrugLimit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Type T = typeof(ForecastConfig);
            //System.Type T = typeof(DrugLimitQuery);
            EAS.Application.Instance.OpenModule(T);
        }

        
        
        

        private void lbDrugSale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Type T = typeof(GasometerView);
            //System.Type T = typeof(DrugSale);
            EAS.Application.Instance.OpenModule(T);
        }

        

        
    }
}
