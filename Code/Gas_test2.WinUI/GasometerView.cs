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

using ZedGraph;

namespace Gas_test2.WinUI
{
    [Module("76E6F5E8-AD5A-4BEC-AF16-28BF8739E4B9", "煤气柜预测数据查询", "FunctionList")]

    public partial class GasometerView : UserControl
    {

        private DataSet dataset = new DataSet();
        ModuleClass.FuncClass func = new ModuleClass.FuncClass();


        public GasometerView()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void GasometerView_Load(object sender, EventArgs e)
        {
            FreshTree();
        }

        private void FreshTree()
        {
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("GasometerType");
            Tree_Ometer.Nodes.Clear();
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {

                TreeNode tn = Tree_Ometer.Nodes.Add(dataset.Tables[0].Rows[j]["GasometerName"].ToString());
                int equipnum = int.Parse(dataset.Tables[0].Rows[j]["GasometerNum"].ToString());

                for (int i = 0; i < equipnum; i++)
                {
                    TreeNode tn1 = new TreeNode((i + 1) + "#" + dataset.Tables[0].Rows[j]["GasometerName"].ToString());
                    tn.Nodes.Add(tn1);
                }

                j++;
            }
        }

        private void btn_Forecast_Click(object sender, EventArgs e)
        {
            string StartTime, EndTime;
            string[] Num = txt_Equip.Text.Split('#');


            StartTime = func.Time_Format(DTP1.Value.ToString());
            EndTime = func.Time_Format(DTP2.Value.ToString());


            //////查询
            dataset.Clear();
            if (CkListBox1.GetItemChecked(0))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("TIME , FLOW", Num[1] + Num[0] + "_REAL", "TIME", StartTime, EndTime);

                //dataset = ServiceContainer.GetService<IGasDAL>().QueryData(ModuleClass.FuncClass.ActivContrl[1].ToString() + Num[0] + "_REAL");
            }
            if (CkListBox1.GetItemChecked(1))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData(Num[1] + Num[0] + "_FCST");
            }
            if (CkListBox1.GetItemChecked(2))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData(Num[1] + Num[0] + "_REAL");
            }

            ////设置DG
            DG1.DataSource = dataset.Tables[0];

            ////画图
            SetGragh(zg1);

        }

        /// <summary>
        /// zedgragh作图
        /// </summary>
        /// <param name="zg"></param>
        private void SetGragh(ZedGraph.ZedGraphControl zg)
        {
            GraphPane myPane = zg.GraphPane;

            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            //Set labels
            myPane.Title.Text = "煤气实绩";// 表头
            myPane.XAxis.Title.Text = "时间";// 横坐标lable
            myPane.YAxis.Title.Text = "煤气量";// 纵坐标label
            //Set list
            PointPairList list = new PointPairList();

            DataView dvList = new DataView(dataset.Tables[0]);
            foreach (DataRowView dv in dvList)
            {


                //double x = Convert.ToDouble(dv["TIME"]);
                //double x = (double)new XDate(2013, 6, 11, i, 0, 0);
                DateTime xx = DateTime.Parse(dv["TIME"].ToString());
                double x = (double)new XDate(xx);
                if (dv["FLOW"] is DBNull)
                    dv["FLOW"] = 500;
                double y = Convert.ToDouble(dv["FLOW"]);
                list.Add(x, y);



            }


            /*            
             * List<HRGasReal> tempList = vList.ToList();
            
                for (int i = 0; i < 100; i++)
                {
                    double C = tempList[i].Consumption;
                    DateTime T = tempList[i].Time;

                    double x = Convert.ToDouble(i);
                    double y = Convert.ToDouble(C);
                    list.Add(x, y);
                }
            */
            /*
            DateTime m = Convert.ToDateTime(DG1.Columns[1]);
            Double n = Convert.ToDouble( DG1.Columns[2]);
            list.Add(m, n);
            for (int i = 0; i < 100; i++)
            {
                double x = (double)new XDate(2013, 6,11,i,0,0);
                
                double y = Math.Sin((double)i * Math.PI / 15.0); 

                list.Add(x, y);
            }
            */

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("煤气量", list, Color.Blue, SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            //Calculate the Axis Scale Ranges
            myPane.XAxis.Type = AxisType.Date;

            myPane.AxisChange();

            SetSize();
        }


        /// <summary>
        /// zedgragh大小设置
        /// </summary>
        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
        }

        private void InitGragh(ZedGraph.ZedGraphControl zg)
        {
            GraphPane myPane = zg.GraphPane;

            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            //Set labels
            myPane.Title.Text = "煤气实绩";// 表头
            myPane.XAxis.Title.Text = "时间";// 横坐标lable
            myPane.YAxis.Title.Text = "煤气量";// 纵坐标label
            //Set list
            PointPairList list = new PointPairList();

            //DataView dvList = new DataView(dataset.Tables[0]);
            //foreach (DataRowView dv in dvList)
            //{


            //    //double x = Convert.ToDouble(dv["TIME"]);
            //    //double x = (double)new XDate(2013, 6, 11, i, 0, 0);
            //    DateTime xx = DateTime.Parse(dv["TIME"].ToString());
            //    double x = (double)new XDate(xx);
            //    if (dv["FLOW"] is DBNull)
            //        dv["FLOW"] = 500;
            //    double y = Convert.ToDouble(dv["FLOW"]);
            //    list.Add(x, y);

            //}




            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("煤气量", list, Color.Blue, SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            //Calculate the Axis Scale Ranges
            myPane.XAxis.Type = AxisType.Date;

            myPane.AxisChange();

            SetSize();
        }

        private void CkListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (CkListBox1.CheckedItems.Count > 0)
            {
                for (int i = 0; i < CkListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        this.CkListBox1.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                    }
                }
            }

        }

        private void Tree_Ometer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Tree_Ometer.SelectedNode.Level == 1)
            {
                txt_Equip.Text = "选中" + e.Node.Text;
                InitGragh(zg1);
            }

        }





    }
}
