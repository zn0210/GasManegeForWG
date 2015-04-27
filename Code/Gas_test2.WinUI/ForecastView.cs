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
    [Module("5EAEF312-692A-42DD-B565-723580465F6D", "预测数据监控", "FunctionList")]

    public partial class ForecastView : UserControl
    {
        private DataSet dataset = new DataSet();

        //private static int secTime=0;
        //private static int minTime = 0;
        //private static int hurTime = 0;
        private static int triggerTime=5;

        public ForecastView()
        {
            InitializeComponent();
        }

        private void ForecastView_Load(object sender, EventArgs e)
        {
            FreshTree();
            
            InitTimer1();

            //StartBLL();
        }

        private void StartBLL()
        {
            /////BLL预测业务
            var vService = ServiceContainer.GetService<IGasBLL>();
            try
            {
                //vService.Forecast("blank");
                vService.Forecast();
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("预测出错：" + exc.Message);
                return;
            }
        }



        private void FreshTree()
        {

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet");
            Tree_Equip.Nodes.Clear();
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {

                TreeNode tn = Tree_Equip.Nodes.Add(dataset.Tables[0].Rows[j]["EquipName"].ToString());
                int equipnum = int.Parse(dataset.Tables[0].Rows[j]["EquipNum"].ToString());

                for (int i = 0; i < equipnum; i++)
                {
                    TreeNode tn1 = new TreeNode((i + 1) + "#" + dataset.Tables[0].Rows[j]["EquipName"].ToString());
                    tn.Nodes.Add(tn1);
                }

                j++;
            }
            Tree_Equip.SelectedNode = null;
        }


        private void Tree_Equip_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Tree_Equip.SelectedNode.Level == 1)
            {
                txt_Equip.Text = "选中" + e.Node.Text;
                FreshTxt(e.Node.Text);
                InitGragh(zg1);
                InitTimer2();
            }
        }

        private void FreshTxt(string selected)
        {
            string[] Row = selected.Split('#');

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet", "EquipName", Row[1]);
            txtAlg.Text = dataset.Tables[0].Rows[0]["ForecastAlg"].ToString();
            txtDuration.Text = dataset.Tables[0].Rows[0]["Duration"].ToString();
            //triggerTime = int.Parse(dataset.Tables[0].Rows[0]["TriggerTime"].ToString());
        }




        private void InitTimer1()
        {

            timer1.Interval = 1000;
            timer1.Enabled = true;
        }


        private void InitTimer2()
        {
            timer1.Interval = triggerTime*60000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            txtNowtime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            QueryResult();
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

        private void QueryResult() 
        {

            string[] Num = txt_Equip.Text.Split('#');

            string StartTime = "2013-06-17 15:36:00.00";
            string EndTime = "2013-06-17 16:36:00.00";

            //////查询
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("TIME , FLOW", Num[1] + Num[0] + "_FCST", "TIME", StartTime, EndTime);

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

        private void ForecastView_Leave(object sender, EventArgs e)
        {
            //StopBLL();
        }

        private void StopBLL()
        {
            /////BLL预测业务
            var vService = ServiceContainer.GetService<IGasBLL>();
            try
            {
                vService.StopForecast();
                
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("预测出错：" + exc.Message);
                return;
            }
        }



    }
}
