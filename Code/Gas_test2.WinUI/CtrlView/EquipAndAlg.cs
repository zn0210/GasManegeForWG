using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EAS;
using EAS.Services;
using EAS.Data.Linq;

using Gas_test2.Entities;

using Gas_test2.BLL;

namespace Gas_test2.WinUI.CtrlView
{
    public partial class EquipAndAlg : UserControl
    {
        private DataSet dataset = new DataSet();
        

        public EquipAndAlg()
        {
            InitializeComponent();
        }

        private void EquipAndAlg_Load(object sender, EventArgs e)
        {
            FreshCbox();
            FreshTree();
            FreshDG();
        }

        private void FreshDG()
        {
            
            if (cbox_Eq.Text.Trim() != "")
            {
                DataSet datasetAlg = new DataSet();
                datasetAlg = ServiceContainer.GetService<IGasDAL>().QueryData("AlgName","AlgTypeAbl" );

                DG_Alg.Rows.Clear();
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim());
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {

                    string Factor= dataset.Tables[0].Rows[j]["Factor"].ToString();

                    string[] FactorD = Factor.Split(';');
                    

                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewComboBoxCell comboxcell0 = new DataGridViewComboBoxCell();
                    for (int i = 0; i < datasetAlg.Tables[0].Rows.Count; i++)
                    {
                        comboxcell0.Items.Add(datasetAlg.Tables[0].Rows[i]["AlgName"]);
                        //comboxcell0.Selected
                    }
                    row.Cells.Add(comboxcell0);
                    //comboxcell0.DisplayMember = dataset.Tables[0].Rows[j]["AlgName"].ToString();
                    comboxcell0.Value = dataset.Tables[0].Rows[j]["AlgName"].ToString();
                    
                    
                    for (int i = 0; i < FactorD.Count() - 1; i++)
                    {
                        DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                        comboxcell.Items.Add(FactorD[i]);
                        //comboxcell.Value=FactorD[i];
                        row.Cells.Add(comboxcell);
                        
                    }
                    

                    DG_Alg.Rows.Add(row);

                    j++;
                }
            }
        }

        private void FreshTree()
        {
            DataSet dataset2 = new DataSet();

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipName","EquipTypeSlet");
            Tree_Alg.Nodes.Clear();
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                string equipname = dataset.Tables[0].Rows[j]["EquipName"].ToString();
                TreeNode tn = Tree_Alg.Nodes.Add(equipname);

                dataset2.Clear();
                dataset2 = ServiceContainer.GetService<IGasDAL>().QueryData("EquipAlgSlet", "EquipName", equipname);

                int k = 0;
                foreach (DataRow dr2 in dataset2.Tables[0].Rows)
                {
                    string Factor;

                    TreeNode tn1 = new TreeNode(dataset2.Tables[0].Rows[k]["AlgName"].ToString());
                    tn.Nodes.Add(tn1);
                    Factor = dataset2.Tables[0].Rows[k]["Factor"].ToString();
                    string[] L1D = Factor.Split(';');
                    for (int i = 0; i < L1D.Count() - 1; i++)
                    {
                        TreeNode tn12 = new TreeNode(L1D[i]);
                        tn1.Nodes.Add(tn12);
                    }


                    k++;
                }
                j++;
            }
        }

        private void FreshCbox()
        {
            cbox_Eq.Items.Clear();
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipName", "EquipTypeSlet");
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                cbox_Eq.Items.Add(dataset.Tables[0].Rows[j][0]);
                j++;
            }
            cbox_Eq.SelectedIndex = 0;
        }

        private void Tree_Alg_DoubleClick(object sender, EventArgs e)
        {
            FreshTree();
        }

        private void cbox_Eq_SelectedIndexChanged(object sender, EventArgs e)
        {
            FreshDG();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {

        }
    }
}
