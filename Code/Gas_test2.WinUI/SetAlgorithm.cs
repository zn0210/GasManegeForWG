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
    [Module("61E1524D-AAF7-4369-B46F-3D6766226A11", "设置预测算法", "FunctionList")]
    
    public partial class SetAlgorithm : UserControl
    {
        private DataSet dataset = new DataSet();
        
        public SetAlgorithm()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void SetAlgorithm_Load(object sender, EventArgs e)
        {
            cbox_Eq.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "cbox_Eq");
            
            

            lbox_Alg.Items.Clear();
            FreshLbox("AlgName", "AlgTypeAbl", "lbox_Alg");
            
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {

            if (lbox_Alg.Items.Count != 0 && cbox_Eq.Text != "")
            {
                if (lbox_Alg.SelectedItems.Count != 0)
                    if (!lbox_UsedAlg.Items.Contains(lbox_Alg.SelectedItem))
                    {
                        lbox_UsedAlg.Items.Add(lbox_Alg.SelectedItem);
                        ServiceContainer.GetService<IGasDAL>().InsertData("EquipAlgSlet", "EquipName", cbox_Eq.Text, "AlgName", lbox_Alg.SelectedItem.ToString());
                    }
            }
            else
                MessageBox.Show("选择设备");
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (lbox_UsedAlg.Items.Count != 0)
            {
                if (lbox_UsedAlg.SelectedItems.Count != 0  && cbox_Eq.Text != "")
                {
                    lbox_UsedAlg.Items.RemoveAt(lbox_UsedAlg.SelectedIndex);
                    ServiceContainer.GetService<IGasDAL>().DeleteData("EquipAlgSlet", "EquipName", cbox_Eq.Text, "AlgName", lbox_UsedAlg.SelectedItems.ToString());

                }
            }
            else
                MessageBox.Show("选择设备");
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string UsedAlg="";
            foreach (string i in lbox_UsedAlg.Items)
            {
                UsedAlg = UsedAlg+i+';';
            }
            /////重置更新表AlgTypeSlet
            //ServiceContainer.GetService<IGasDAL>().InsertData("AlgTypeSlet", "ETabName", lbox_Alg.SelectedItem.ToString(), "ATabName", UsedAlg);

            /////创建算法表
            /*
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet");
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                
                ServiceContainer.GetService<IGasDAL>().CreatAlgTab(dataset.Tables[0].Rows[j][0].ToString(), "0", dataset.Tables[0].Rows[j][2].ToString());
                
                j++;
            }
             */ 

            ServiceContainer.GetService<IGasDAL>().CreatAlgTab();
            
        }




        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab, string listbox)
        {
            if (listbox == "lbox_Alg")
            {
                dataset.Clear();

                dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab);

                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                
                    lbox_Alg.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }
            }

            else if (listbox == "cbox_Eq")
            {
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab, "Selected", "1");
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    cbox_Eq.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }
            }
        }

        private void lbox_UsedAlg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbox_UsedAlg.Items.Clear();
            lbox_Factor.Items.Clear();
            lbox_UsedFact.Items.Clear();

            string L1, L2, L3;

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L1", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
            L1 = dataset.Tables[0].Rows[0][0].ToString();
            string[] L1D = L1.Split(';');
            for (int i = 0; i < L1D.Count()-1; i++)
            {
                lbox_Factor.Items.Add(L1D[i]);
            }

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L2", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
            L2 = dataset.Tables[0].Rows[0][0].ToString();
            string[] L2D = L2.Split(';');
            for (int i = 0; i < L2D.Count()-1; i++)
            {
                lbox_Factor.Items.Add(L2D[i]);
            }

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L3", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
            L3 = dataset.Tables[0].Rows[0][0].ToString();
            string[] L3D = L3.Split(';');
            for (int i = 0; i < L3D.Count()-1; i++)
            {
                lbox_Factor.Items.Add(L3D[i]);
            }

            /*
            string Factor;
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("Factor", "EquipAlgSlet", "EquipName", cbox_Eq.Text, "AlgName", lbox_UsedAlg.SelectedItem.ToString());
            Factor = dataset.Tables[0].Rows[0][0].ToString();
            string[] FactorD = Factor.Split(';');
            for (int i = 0; i < FactorD.Count() - 1; i++)
            {
                lbox_UsedFact.Items.Add(FactorD[i]);
            }
             */

        }

        private void btn_Left2_Click(object sender, EventArgs e)
        {
            if (lbox_Factor.Items.Count != 0 && cbox_Eq.Text != "" && lbox_UsedAlg.SelectedItems.Count!=0)
            {
                if (lbox_Factor.SelectedItems.Count != 0)
                    if (!lbox_UsedFact.Items.Contains(lbox_Factor.SelectedItem))
                    {
                        lbox_UsedFact.Items.Add(lbox_Factor.SelectedItem);

                        string Factor="";
                        for (int i = 0; i < lbox_UsedFact.Items.Count; i++)
                        {
                            Factor = Factor + lbox_UsedFact.Items[i]+";";
                        }
                        ServiceContainer.GetService<IGasDAL>().UpdateData("EquipAlgSlet", "Factor", Factor, "EquipName", cbox_Eq.Text, "AlgName", lbox_UsedAlg.SelectedItem.ToString());
                    }
            }
        }

        private void btn_Right2_Click(object sender, EventArgs e)
        {
            if (lbox_UsedFact.Items.Count != 0 && cbox_Eq.Text != "")
            {
                if (lbox_UsedFact.SelectedItems.Count != 0)
                {
                    lbox_UsedFact.Items.RemoveAt(lbox_UsedFact.SelectedIndex);

                    string Factor = "";
                    for (int i = 0; i < lbox_UsedFact.Items.Count; i++)
                    {
                        Factor = Factor + lbox_UsedFact.Items[i] + ";";
                    }
                    ServiceContainer.GetService<IGasDAL>().UpdateData("EquipAlgSlet", "Factor", Factor, "EquipName", cbox_Eq.Text, "AlgName", lbox_UsedAlg.SelectedItem.ToString());

                }
            }
        }

        private void cbox_Eq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_Eq.Text.Trim() != "")
            {
                lbox_UsedAlg.Items.Clear();
                //FreshLbox("EquipName", "EquipAlgSlet", "lbox_UsedAlg");
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("AlgName", "EquipAlgSlet", "EquipName", cbox_Eq.Text);

                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    lbox_UsedAlg.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }



                lbox_Factor.Items.Clear();
                lbox_UsedFact.Items.Clear();

                string L1, L2, L3;

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L1", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
                L1 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L1D = L1.Split(';');
                for (int i = 0; i < L1D.Count() - 1; i++)
                {
                    lbox_Factor.Items.Add(L1D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L2", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
                L2 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L2D = L2.Split(';');
                for (int i = 0; i < L2D.Count() - 1; i++)
                {
                    lbox_Factor.Items.Add(L2D[i]);
                }

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("L3", "EquipTypeSlet", "EquipName", cbox_Eq.Text);
                L3 = dataset.Tables[0].Rows[0][0].ToString();
                string[] L3D = L3.Split(';');
                for (int i = 0; i < L3D.Count() - 1; i++)
                {
                    lbox_Factor.Items.Add(L3D[i]);
                }


            }



        }










    }
}
