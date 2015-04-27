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
    [Module("E5BD5566-25F7-493C-9463-02E123E4FC87", "算法文件配置", "FunctionList")]
    
    public partial class FileConfig : UserControl
    {
        private DataSet dataset = new DataSet();
        
        public FileConfig()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void FileConfig_Load(object sender, EventArgs e)
        {
            lbox_Type.Items.Clear();
            FreshLbox("AlgName", "AlgTypeAbl");

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormView.AddAlgorithm addalg = new FormView.AddAlgorithm();
            addalg.ShowDialog();
            addalg.Dispose();
            lbox_Type.Items.Clear();
            FreshLbox("AlgName", "AlgTypeAbl");
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            ///不可见了
            //FormView.AddAlgorithm addalg = new FormView.AddAlgorithm();
            //addalg.Show();
            //addalg.Dispose();
            
            ////update表数据
            if (lbox_Type.SelectedItems.Count != 0)
            {
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("AlgRoute", "AlgTypeAbl", "AlgName", lbox_Type.SelectedItem.ToString());
                textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();

                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("AlgParaRoute", "AlgTypeAbl", "AlgName", lbox_Type.SelectedItem.ToString());
                textBox2.Text = dataset.Tables[0].Rows[0][0].ToString();

                using (StreamReader sr = new StreamReader(textBox2.Text))
                {
                    this.rbox.Text = sr.ReadToEnd();
                }
            }
            else
                MessageBox.Show("选择算法");

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                
                /////删除一行数据
                ServiceContainer.GetService<IGasDAL>().DeleteData("AlgTypeAbl", "AlgName", lbox_Type.SelectedItem.ToString());
                lbox_Type.Items.RemoveAt(lbox_Type.SelectedIndex);
                lbox_Type.Items.Clear();
                FreshLbox("AlgName", "AlgTypeAbl");
            }
            catch
            {
                MessageBox.Show("选择删除对象");
            }
        }

        private void btn_Browse1_Click(object sender, EventArgs e)
        {
            if (lbox_Type.SelectedItems.Count != 0)
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName; //得到文件名 
                    textBox1.Text = fileName;
                    ServiceContainer.GetService<IGasDAL>().UpdateData("AlgTypeAbl", "AlgRoute", fileName, "AlgName", lbox_Type.SelectedItem.ToString());

                }
            }
            else
                MessageBox.Show("选择算法");
        }

        private void btn_Browse2_Click(object sender, EventArgs e)
        {
            if (lbox_Type.SelectedItems.Count != 0)
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName; //得到文件名 
                    textBox2.Text = fileName;
                    ServiceContainer.GetService<IGasDAL>().UpdateData("AlgTypeAbl", "AlgParaRoute", fileName, "AlgName", lbox_Type.SelectedItem.ToString());


                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        this.rbox.Text = sr.ReadToEnd();
                    }
                }
            }
            
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            ////update表数据
            if (lbox_Type.SelectedItems.Count != 0)
            {
                ServiceContainer.GetService<IGasDAL>().UpdateData("AlgTypeAbl", "AlgRoute", textBox1.Text.Trim(), "AlgName", lbox_Type.SelectedItem.ToString());
                ServiceContainer.GetService<IGasDAL>().UpdateData("AlgTypeAbl", "AlgParaRoute", textBox2.Text.Trim(), "AlgName", lbox_Type.SelectedItem.ToString());
                //保存算法参数

            }
            else
                MessageBox.Show("请在左侧选择要修改的算法");
        }




        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab)
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







    }
}
