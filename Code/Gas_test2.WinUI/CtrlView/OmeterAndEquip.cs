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
    public partial class OmeterAndEquip : UserControl
    {
        private DataSet dataset = new DataSet();
        private int equipTypeNum;

        public OmeterAndEquip()
        {
            InitializeComponent();
        }

        private void OmeterAndEquip_Load(object sender, EventArgs e)
        {
            FreshLbox("GasometerName", "GasometerType", "lbox_Gasometer");
            FreshDG();
            /* 设置label显示方式
            string str = "输入设备：";
            int LblNum = str.Length;   //Label内容长度         
            int RowNum = 10;           //每行显示的字数         
            float FontWidth = label1.Width / label1.Text.Length;  //每个字符的宽度         
            int RowHeight=15;           //每行的高度         
            int ColNum = (LblNum - (LblNum / RowNum) * RowNum) == 0 ? (LblNum / RowNum) : (LblNum / RowNum) + 1;   //列数         
            label1.AutoSize = false;    //设置AutoSize         
            label1.Width = (int)(FontWidth * 10.0);          //设置显示宽度         
            label1.Height = RowHeight * ColNum;           //设置显示高度
             */ 
        }


        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab, string listbox)
        {
            
            lbox_Ometer.Items.Clear();
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData(cloum, tab);
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                lbox_Ometer.Items.Add(dataset.Tables[0].Rows[j][cloum]);
                j++;
            }



        }

        private void lbox_Ometer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox_Ometer.SelectedItems.Count != 0)
            {
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("GoEquipSlet", "GasometerName", lbox_Ometer.SelectedItem.ToString());

                for (int i = 0; i < equipTypeNum; i++)
                {
                    int j = 0;
                    foreach (DataRow dr in dataset.Tables[0].Rows)
                    {
                        if (dataset.Tables[0].Rows[j]["PorC"].ToString() == "True" && dataset.Tables[0].Rows[j]["EquipName"].ToString() == DG_In.Rows[i].Cells["设备名称"].Value.ToString())
                        {
                            DG_In.Rows[i].Cells[1].Value = 1;
                            DG_In.Rows[i].Cells[2].Value = dataset.Tables[0].Rows[j]["GasPercent"];
                        }
                        else if (dataset.Tables[0].Rows[j]["PorC"].ToString() == "False" && dataset.Tables[0].Rows[j]["EquipName"].ToString() == DG_Out.Rows[i].Cells["设备名称"].Value.ToString())
                        {
                            DG_Out.Rows[i].Cells[1].Value = 1;
                            DG_Out.Rows[i].Cells[2].Value = dataset.Tables[0].Rows[j]["GasPercent"];
                        }
                        j++;
                    }

                }
            }


        }

        private void FreshDG()
        {
            DG_In.Rows.Clear();
            DG_Out.Rows.Clear();
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData( "EquipTypeSlet");
            equipTypeNum = dataset.Tables[0].Rows.Count;
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                if (dr["PorC"].ToString() == "True")
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                    textboxcell.Value = dataset.Tables[0].Rows[j][0];
                    row.Cells.Add(textboxcell);
                    DataGridViewCheckBoxCell checkcell = new DataGridViewCheckBoxCell();
                    checkcell.Value = false;
                    row.Cells.Add(checkcell);
                    DataGridViewTextBoxCell txtboxcell = new DataGridViewTextBoxCell();
                    row.Cells.Add(txtboxcell);
                    DG_In.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row2 = new DataGridViewRow();
                    DataGridViewTextBoxCell textboxcell2 = new DataGridViewTextBoxCell();
                    textboxcell2.Value = dataset.Tables[0].Rows[j][0];
                    row2.Cells.Add(textboxcell2);
                    DataGridViewCheckBoxCell checkcell2 = new DataGridViewCheckBoxCell();
                    checkcell2.Value = false;
                    row2.Cells.Add(checkcell2);
                    DataGridViewTextBoxCell txtboxcell2 = new DataGridViewTextBoxCell();
                    row2.Cells.Add(txtboxcell2);
                    DG_Out.Rows.Add(row2);
                }

                //DataGridViewRow row = new DataGridViewRow();
                //row.Cells["设备名称"].Value = dataset.Tables[0].Rows[j][0];//设置row属性
                //DG_In.Rows.Add(row);
                //DG_Out.Rows.Add(row);
                //DG_In.Rows[j].Cells[0].Value = dataset.Tables[0].Rows[j][0];
                //DG_Out.Rows[j].Cells[0].Value = dataset.Tables[0].Rows[j][0];
                j++;
            }
        }

        private void DG_In_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        //datagrideview更新数据库
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (lbox_Ometer.SelectedItems.Count != 0)
            {
                foreach (DataGridViewRow dr in DG_In.Rows)
                {
                    DataSet flag = ServiceContainer.GetService<IGasDAL>().QueryData("*", "GoEquipSlet","GasometerName", lbox_Ometer.SelectedItem.ToString(),"EquipName",dr.Cells[0].Value.ToString());
                    if (flag.Tables[0].Rows.Count == 0)
                    {
                        try
                        {
                            ServiceContainer.GetService<IGasDAL>().InsertData("GoEquipSlet",  "GasometerName", lbox_Ometer.SelectedItem.ToString(), "EquipName", dr.Cells[0].Value.ToString());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                    try
                    {
                        ServiceContainer.GetService<IGasDAL>().UpdateOE("GoEquipSlet", "GasPercent", dr.Cells[2].Value.ToString(), "PorC", dr.Cells[1].Value.ToString(), "GasometerName", lbox_Ometer.SelectedItem.ToString(), "EquipName", dr.Cells[0].Value.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }

                foreach (DataGridViewRow dr in DG_Out.Rows)
                {
                    DataSet flag = ServiceContainer.GetService<IGasDAL>().QueryData("*", "GoEquipSlet", "GasometerName", lbox_Ometer.SelectedItem.ToString(), "EquipName", dr.Cells[0].Value.ToString());
                    if (flag.Tables[0].Rows.Count == 0)
                    {
                        try
                        {
                            ServiceContainer.GetService<IGasDAL>().InsertData("GoEquipSlet", "GasometerName", lbox_Ometer.SelectedItem.ToString(), "EquipName", dr.Cells[0].Value.ToString());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    try
                    {
                        ServiceContainer.GetService<IGasDAL>().UpdateOE("GoEquipSlet", "GasPercent", dr.Cells[2].Value.ToString(), "PorC", dr.Cells[1].Value.ToString(), "GasometerName", lbox_Ometer.SelectedItem.ToString(), "EquipName", dr.Cells[0].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
 
            }
            else
                MessageBox.Show("请选择要更新的煤气柜");
        }



    }
}
