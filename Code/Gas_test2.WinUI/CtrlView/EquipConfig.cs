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
    public partial class EquipConfig : UserControl
    {
        private DataSet dataset = new DataSet();
        private DataSet datasetALL = new DataSet();

        public EquipConfig()
        {
            InitializeComponent();
        }

        private void EquipConfig_Load(object sender, EventArgs e)
        {
            
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");
            
            
        }


        /// <summary>
        /// 读取数据库数据到listbox并刷新Treeview
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab, string listbox)
        {
            lbox_Equip.Items.Clear();
            datasetALL.Clear();
            datasetALL = ServiceContainer.GetService<IGasDAL>().QueryData(tab);
            int j = 0;
            foreach (DataRow dr in datasetALL.Tables[0].Rows)
            {
                //if (datasetALL.Tables[0].Rows[j]["Selected"].ToString() == "True")
                //{}
                    lbox_Equip.Items.Add(datasetALL.Tables[0].Rows[j][cloum]);
                
                j++;
            }

            FreshTree(datasetALL);

        }

        /// <summary>
        /// 读数据库创建treeview
        /// </summary>
        private void FreshTree()
        {
            datasetALL.Clear();
            datasetALL = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet");
            FreshTree( datasetALL);
        }


        /// <summary>
        /// 创建treeview
        /// </summary>
        /// <param name="datasetALL">整表信息</param>
        private void FreshTree(DataSet datasetALL)
        {
            Tree_Factor.Nodes.Clear();
            int j = 0;
            foreach (DataRow dr in datasetALL.Tables[0].Rows)
            {
                //string ii= datasetALL.Tables[0].Rows[j]["Selected"].ToString();
                //if (datasetALL.Tables[0].Rows[j]["Selected"].ToString() == "True")
                //{}
                    TreeNode tn = Tree_Factor.Nodes.Add(datasetALL.Tables[0].Rows[j]["EquipName"].ToString());

                    string L1, L2, L3;

                    TreeNode tn1 = new TreeNode("直采数据");
                    tn.Nodes.Add(tn1);
                    L1 = datasetALL.Tables[0].Rows[j]["L1"].ToString();
                    string[] L1D = L1.Split(';');
                    for (int i = 0; i < L1D.Count() - 1; i++)
                    {
                        TreeNode tn12 = new TreeNode(L1D[i]);
                        tn1.Nodes.Add(tn12);
                    }

                    TreeNode tn2 = new TreeNode("操作数据");
                    tn.Nodes.Add(tn2);
                    L2 = datasetALL.Tables[0].Rows[j]["L2"].ToString();
                    string[] L2D = L2.Split(';');
                    for (int i = 0; i < L2D.Count() - 1; i++)
                    {
                        TreeNode tn22 = new TreeNode(L2D[i]);
                        tn2.Nodes.Add(tn22);
                    }

                    TreeNode tn3 = new TreeNode("调度数据");
                    tn.Nodes.Add(tn3);
                    L3 = datasetALL.Tables[0].Rows[j]["L3"].ToString();
                    string[] L3D = L3.Split(';');
                    for (int i = 0; i < L3D.Count() - 1; i++)
                    {
                        TreeNode tn32 = new TreeNode(L3D[i]);
                        tn3.Nodes.Add(tn32);
                    }
                    
                    
                j++;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormView.AddEquip addequip = new FormView.AddEquip();
            ModuleClass.FuncClass.clikUI = "equip";
            addequip.ShowDialog();
            addequip.Dispose();
            
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");
        }

        private void lbox_Equip_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbox_Equip.SelectedItems.Count != 0)
            {
                string L1, L2, L3;

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L1", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L1 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L1D = L1.Split(';');
                dgv_L1.Rows.Clear();
                for (int i = 0; i < L1D.Count() - 1; i++)
                {
                    dgv_L1.Rows.Add(L1D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L2", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L2 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L2D = L2.Split(';');
                dgv_L2.Rows.Clear();
                for (int i = 0; i < L2D.Count() - 1; i++)
                {
                    dgv_L2.Rows.Add(L2D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L3", "EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                L3 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L3D = L3.Split(';');
                dgv_L3.Rows.Clear();
                for (int i = 0; i < L3D.Count() - 1; i++)
                {
                    dgv_L3.Rows.Add(L3D[i]);
                }
            }
            //else
            //    MessageBox.Show("选择设备");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                /////////删除表一行数据
                ServiceContainer.GetService<IGasDAL>().DeleteData("EquipTypeSlet", "EquipName", lbox_Equip.SelectedItem.ToString());
                lbox_Equip.Items.RemoveAt(lbox_Equip.SelectedIndex);
                
                FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");
            }
            catch
            {
                MessageBox.Show("选择删除项");
            }
        }

        private void btn_FactorEnter_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.SelectedItems.Count != 0)
            {
                string L1 = "", L2 = "", L3 = "";

                //dataGridView1.Rows[i].Cell[i].Text.ToString().Equals("") || this.dataGridView1.Rows[i].Cell[i].Text.ToString().Equals("&nbsp;") 

                if (dgv_L1.RowCount >1)
                {
                    for (int i = 0; i < dgv_L1.Rows.Count - 1; i++)
                    {
                        L1 = L1 + dgv_L1.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                if (dgv_L2.RowCount >1)
                {
                    for (int i = 0; i < dgv_L2.Rows.Count - 1; i++)
                    {
                        L2 = L2 + dgv_L2.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                if (dgv_L3.RowCount >1)
                {
                    for (int i = 0; i < dgv_L3.Rows.Count - 1; i++)
                    {
                        L3 = L3 + dgv_L3.Rows[i].Cells[0].Value.ToString() + ';';
                    }
                }
                /////写EquipTypeSlet数据表
                //ServiceContainer.GetService<IGasDAL>().UpdateData(lbox_Equip.SelectedItem.ToString(), txtbox_Num.Text.Trim(), L1, L2, L3);
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L1", L1, "EquipName", lbox_Equip.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L2", L2, "EquipName", lbox_Equip.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "L3", L3, "EquipName", lbox_Equip.SelectedItem.ToString());

                
                FreshTree();
            
            }
            else
                MessageBox.Show("选择修改对象");

            
        }

        private void Tree_Factor_DoubleClick(object sender, EventArgs e)
        {
            
            FreshTree();
        }


    }
}
