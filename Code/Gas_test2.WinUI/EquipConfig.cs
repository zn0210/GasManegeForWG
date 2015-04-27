using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using EAS.Data;
using EAS.Data.ORM;
using EAS.Data.Access;
using EAS.Modularization;

using EAS;
using EAS.Services;
using EAS.Data.Linq;

using Gas_test2.Entities;

using Gas_test2.BLL; 


namespace Gas_test2.WinUI
{
    [Module("FDF56D48-0A51-43C5-8BC7-C447A5CC2426", "设备节点配置", "FunctionList")]
    
    public partial class EquipConfig : UserControl
    {
        private DataSet dataset = new DataSet();
        
        
        public EquipConfig()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void EquipConfig_Load(object sender, EventArgs e)
        {
            lbox_Type.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Type");

            lbox_Equip.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");
            
            txtbox_Num.Text = "";
            dgv_L1.Rows.Clear();
            dgv_L2.Rows.Clear();
            dgv_L3.Rows.Clear();
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            FormView.AddEquip addequip = new FormView.AddEquip();
            addequip.ShowDialog();
            addequip.Dispose();
            lbox_Type.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Type");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                
                /////////删除表一行数据
                ServiceContainer.GetService<IGasDAL>().DeleteData("EquipTypeSlet", "EquipName", lbox_Type.SelectedItem.ToString());
                lbox_Type.Items.RemoveAt(lbox_Type.SelectedIndex);
                lbox_Type.Items.Clear();
                FreshLbox("EquipName", "EquipTypeSlet", "lbox_Type");
            }
            catch
            {
                MessageBox.Show("选择删除项");
            }
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            if (lbox_Type.Items.Count != 0)
            {
                if (lbox_Type.SelectedItems.Count != 0)
                    if (!lbox_Equip.Items.Contains(lbox_Type.SelectedItem))
                    {
                        lbox_Equip.Items.Add(lbox_Type.SelectedItem);
                        //string i=lbox_Type.SelectedItem.ToString();
                        try
                        {
                            ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "Selected", "1", "EquipName", lbox_Type.SelectedItem.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("调用数据服务失败");
                        }
                    }
            }
            
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.Items.Count != 0)
            {
                if (lbox_Equip.SelectedItems.Count != 0)
                {
                    ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "Selected", "0", "EquipName", lbox_Equip.SelectedItem.ToString());
                    lbox_Equip.Items.RemoveAt(lbox_Equip.SelectedIndex);                   
                }
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.SelectedItems.Count != 0)
            {
                string L1, L2, L3;
                
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipNum", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                txtbox_Num.Text = dataset.Tables[0].Rows[0][0].ToString();

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L1", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L1 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L1D = L1.Split(';');
                dgv_L1.Rows.Clear();
                for (int i = 0; i < L1D.Count()-1; i++)
                {
                    dgv_L1.Rows.Add(L1D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L2", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L2 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L2D = L2.Split(';');
                dgv_L2.Rows.Clear();
                for (int i = 0; i < L2D.Count()-1; i++)
                {
                    dgv_L2.Rows.Add(L2D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L3", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L3 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L3D = L3.Split(';');
                dgv_L3.Rows.Clear();
                for (int i = 0; i < L3D.Count()-1; i++)
                {
                    dgv_L3.Rows.Add(L3D[i]);
                }
            }
            else
                MessageBox.Show("选择设备");
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.SelectedItems.Count != 0)
            {
                string L1 = "", L2 = "", L3 = "";

                //dataGridView1.Rows[i].Cell[i].Text.ToString().Equals("") || this.dataGridView1.Rows[i].Cell[i].Text.ToString().Equals("&nbsp;") 

                if (dgv_L1.RowCount != 0)
                {
                    for (int i = 0; i < dgv_L1.Rows.Count-1; i++)
                    {
                        L1 = L1 + dgv_L1.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                if (dgv_L2.RowCount != 0)
                {
                    for (int i = 0; i < dgv_L2.Rows.Count-1; i++)
                    {
                        L2 = L2 + dgv_L2.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                if (dgv_L3.RowCount != 0)
                {
                    for (int i = 0; i < dgv_L3.Rows.Count-1; i++)
                    {
                        L3 = L3 + dgv_L3.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                /////写EquipTypeSlet数据表
                //ServiceContainer.GetService<IGasDAL>().UpdateData(lbox_Equip.SelectedItem.ToString(), txtbox_Num.Text.Trim(), L1, L2, L3);
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "EquipNum", txtbox_Num.Text.Trim(), "EquipName", lbox_Equip.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L1", L1, "EquipName", lbox_Equip.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L2", L2, "EquipName", lbox_Equip.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L3", L3, "EquipName", lbox_Equip.SelectedItem.ToString());
            }
            else
                MessageBox.Show("选择修改对象");
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            //////////创建数据表
            /*
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet",  "Selected",  "1");
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                for (int i = 0; i < int.Parse(dataset.Tables[0].Rows[j][2].ToString()); i++)
                {
                    ServiceContainer.GetService<IGasDAL>().CreatEquipTab(dataset.Tables[0].Rows[j][1].ToString(), (i+1).ToString());
                }
                j++;
            }
            */



            
            ServiceContainer.GetService<IGasDAL>().CreatEquipTab();

        }


        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab,string listbox)
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
            if (listbox == "lbox_Type")
            {
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab);
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    lbox_Type.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }
            }
            else if (listbox == "lbox_Equip")
            {
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData( cloum, tab, "Selected", "1");
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    lbox_Equip.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }
            }


        }









    }
}
