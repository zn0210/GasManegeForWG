using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gas_test2.BLL;
using EAS.Services;

namespace Gas_test2.WinUI.FormView
{
    public partial class AddEquip : Form
    {
        public AddEquip()
        {
            InitializeComponent();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (ModuleClass.FuncClass.clikUI == "ometer")
            {
                if (txtName.Text.Trim() != "" && txtSName.Text.Trim() != "" && txtNum.Text.Trim() != "")
                {
                    try
                    {
                        ServiceContainer.GetService<IGasDAL>().InsertData("GasometerType", "GasometerName", txtName.Text.Trim(), "OTabName", txtSName.Text.Trim(), "GasometerNum", txtNum.Text.Trim());
                        //ServiceContainer.GetService<IGasDAL>().UpdateData("GasometerType",);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
            else if (ModuleClass.FuncClass.clikUI == "equip")
            {
                if (txtName.Text.Trim() != "" && txtSName.Text.Trim() != "" && txtNum.Text.Trim() != "")
                {
                    try
                    {
                        ServiceContainer.GetService<IGasDAL>().InsertData("EquipTypeSlet", "EquipName", txtName.Text.Trim(), "ETabName", txtSName.Text.Trim(), "EquipNum", txtNum.Text.Trim());
                        ServiceContainer.GetService<IGasDAL>().UpdateData("EquipTypeSlet", "PorC", rbtn.Checked.ToString(), "EquipName", txtName.Text.Trim());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);                   
                    }
                }
            }
            this.Close();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEquip_Load(object sender, EventArgs e)
        {
            if (ModuleClass.FuncClass.clikUI=="ometer")
            {
                label1.Text = "煤气柜名称：";
                label2.Text = "煤气柜简称：";
                label3.Text = "煤气柜数量：";
                label4.Visible = false;
                rbtn.Visible = false;
            }
            else if (ModuleClass.FuncClass.clikUI == "equip")
            {
                label1.Text = "设备名称：";
                label2.Text = "设备简称：";
                label3.Text = "设备数量："; 
                label4.Visible = true;
                rbtn.Visible = true;
            }
        }
    }
}
