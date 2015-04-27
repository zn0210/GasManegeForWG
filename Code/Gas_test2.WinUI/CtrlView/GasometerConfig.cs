using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EAS.Data;
using EAS.Data.ORM;
using EAS.Data.Access;
using EAS.Modularization;

using EAS;
using EAS.Services;
using EAS.Data.Linq;

using Gas_test2.Entities;

using Gas_test2.BLL; 

namespace Gas_test2.WinUI.CtrlView
{
    public partial class GasometerConfig : UserControl
    {
        private DataSet dataset = new DataSet();

        public GasometerConfig()
        {
            InitializeComponent();
        }

        private void GasometerConfig_Load(object sender, EventArgs e)
        {

            Setsize();
            panel1.BorderStyle = BorderStyle.Fixed3D;
            FreshUI("GasometerName", "GasometerType", "lbox_Gasometer");
            
        }

        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshUI(string cloum, string tab, string listbox)
        {
            /*
            dataset.Clear();

            dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab);

            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                if (listbox == "lbox_Type")
                {
                    
                    lbox_Type.Items.Add(dataset.Tables[0].Rows[j][0]);
                }
                else if (listbox == "lbox_Equip")
                {
                    //dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab);
                    if (dataset.Tables[0].Rows[j][6].ToString() == "1")
                        lbox_Equip.Items.Add(dataset.Tables[0].Rows[j][0]);
                }
                j++;
            }
            */
            //if (listbox == "lbox_Gasometer")
            //{}
            lbox_Gasometer.Items.Clear();
            panel1.Controls.Clear();
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData( tab);
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                //Listbox
                lbox_Gasometer.Items.Add(dataset.Tables[0].Rows[j][cloum]);

                //Panel
                
                Panel panelBar= new Panel();
                panel1.Controls.Add(panelBar);
                panelBar.BorderStyle = BorderStyle.FixedSingle;
                panelBar.Location = new Point(10, 10 + panel1.Height*j / 4);
                panelBar.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height / 4);
                   
                banner bar = new banner();
                bar.LabelText = dataset.Tables[0].Rows[j][cloum].ToString()+"数量：";
                bar.UDNum =int.Parse( dataset.Tables[0].Rows[j]["GasometerNum"].ToString());
                panelBar.Controls.Add(bar);

                j++;
            }


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FormView.AddEquip addequip = new FormView.AddEquip();
                ModuleClass.FuncClass.clikUI = "ometer";
                addequip.ShowDialog();
                addequip.Dispose();

                FreshUI("GasometerName", "GasometerType", "lbox_Gasometer");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {

                /////////删除表一行数据
                ServiceContainer.GetService<IGasDAL>().DeleteData("GasometerType", "GasometerName", lbox_Gasometer.SelectedItem.ToString());
                lbox_Gasometer.Items.RemoveAt(lbox_Gasometer.SelectedIndex);

                FreshUI("GasometerName", "GasometerType", "lbox_Gasometer");
            }
            catch
            {
                MessageBox.Show("选择删除项");
            }
        }

        private void GasometerConfig_SizeChanged(object sender, EventArgs e)
        {
            Setsize();
        }

        private void Setsize()
        {
            groupBox1.Location = new Point(10, 10);
            groupBox1.Size = new Size((this.ClientRectangle.Width - 30)/4, this.ClientRectangle.Height - 20);

            panel1.Location = new Point((this.ClientRectangle.Width - 30) / 4+20,  10);
            panel1.Size = new Size((this.ClientRectangle.Width - 30)*3/4, this.ClientRectangle.Height - 20);

        }
    }
}
