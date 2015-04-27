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
using System.Threading;

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

namespace Gas_test2.WinUI.CtrlView
{
    //[Module("212165EE-6A75-43DA-8721-9035BEF5441E", "导航界面", "FunctionList")]
    
    public partial class Forecast : UserControl
    {
        private DataSet dataset = new DataSet();
        private bool StartForecast=false;
        static int t = 15;
        
        //System.Threading.Timer Thread_Time; 

        public Forecast()
        {
            InitializeComponent();
        }

        //[ModuleStart]
        //public void StartEx()
        //{

        //}

        private void Forecast_Load(object sender, EventArgs e)
        {

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet");
            DataView dvList = new DataView(dataset.Tables[0]);

            foreach (DataRowView dv in dvList)
            {
                if (ModuleClass.FuncClass.ActivContrl[0].ToString() == dv["EquipName"].ToString())
                {
                    lab_Eq.Text = "选择" + dv["EquipName"].ToString() + "设备号";
                    for (int i = 0; i < int.Parse(dv["EquipNum"].ToString()); i++)
                    {
                        cbox1.Items.Add((i+1) + "#设备");
                    }
                }
            }

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("AlgName", "EquipAlgSlet", "EquipName", ModuleClass.FuncClass.ActivContrl[0]);
            DataView dvList1 = new DataView(dataset.Tables[0]);

            foreach (DataRowView dv in dvList1)
            {
                
                cbox2.Items.Add(dv["AlgName"].ToString());
                
            }

            SetSize();

            timer1.Interval = 1000;
            timer1.Enabled = true;

        }

        private void btn_Para_Click(object sender, EventArgs e)
        {
            FormView.SetFCSTPara setpara = new FormView.SetFCSTPara();
            setpara.ShowDialog();
            setpara.Dispose();
        }

        private void btn_Err_Click(object sender, EventArgs e)
        {
            FormView.ErrShow errshow = new FormView.ErrShow();
            errshow.ShowDialog();
            errshow.Dispose();
        }

        private void btn_FCST_Click(object sender, EventArgs e)
        {
            //Thread_Time = new System.Threading.Timer(Thread_Timer_Method, null, 0, 20);
            
            //CallBLL();

            if (btn_FCST.Text == "预测")
            {
                if (cbox1.Text != "" && cbox2.Text != "")
                {
                    timer2.Interval = 5000;
                    timer2.Enabled = true;
                    btn_FCST.Text ="停止";
                }
                else
                    MessageBox.Show("选择设备和算法");
            }
            else if (btn_FCST.Text == "停止")
            {
                StopBLL();
                timer2.Enabled = false;
                btn_FCST.Text = "预测";
            }
            else
                MessageBox.Show("任务出错！");
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
            myPane.Title.Text = "煤气预测值";// 表头
            myPane.XAxis.Title.Text = "时间";// 横坐标lable
            myPane.YAxis.Title.Text = "煤气量";// 纵坐标label
            //Set list
            PointPairList list = new PointPairList();

            //dataset.Clear();
            //dataset = ServiceContainer.GetService<IGasDAL>().QueryData(ModuleClass.FuncClass.ActivContrl[0].ToString() + cbox1.Text+cbox2.Text + "FCST");
            DataView dvList = new DataView(dataset.Tables[0]);
            foreach (DataRowView dv in dvList)
            {
                //for (int i = 0; i < 100; i++)
                //{
                //    DateTime xx = DateTime.Parse(dv["TIME"].ToString());
                //    double x = (double)new XDate(xx);
                //    if (dv["FFLOW"] is DBNull)
                //        dv["FFLOW"] = 500;
                //    double y = Convert.ToDouble(dv["FFLOW"]);

                //    list.Add(x, y);
                //}

                DateTime xx = DateTime.Parse(dv["TIME"].ToString());
                double x = (double)new XDate(xx);
                if (dv["FFLOW"] is DBNull)
                    dv["FFLOW"] = 500;
                double y = Convert.ToDouble(dv["FFLOW"]);


                list.Add(x, y);

            }
            
            
          
            /*            
             List<HRGasReal> tempList = vList.ToList();
            
            for (int i = 0; i < 100; i++)
            {
                double C = tempList[i].Consumption;
                DateTime T = tempList[i].Time;

                double x = Convert.ToDouble(i);
                double y = Convert.ToDouble(C);
                list.Add(x, y);
            }
            */
            /*//DateTime m = Convert.ToDateTime(DG1.Columns[1]);
            Double n = Convert.ToDouble( DG1.Columns[2]);
            list.Add(m, n);
            for (int i = 0; i < 100; i++)
            {
                double x = (double)new XDate(2013, 6,11,i,0,0);
                
                double y = Math.Sin((double)i * Math.PI / 15.0); 

                list.Add(x, y);
            }*/

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

        private void Forecast_ControlRemoved(object sender, ControlEventArgs e)
        {
            //Thread_Time.Dispose();
            timer1.Enabled = false;
            timer2.Enabled = false;

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    CallBLL();
        //}

        private void CallBLL()
        {
            /////BLL预测业务
            var vService = ServiceContainer.GetService<IGasBLL>();
            try
            {
                vService.Forecast(cbox2.Text);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("预测出错：" + exc.Message);
                return;
            }
            /////画图
            SetGragh(zg1);
        }

        void Thread_Timer_Method(object o)
        {
            /*

            /////BLL预测业务
            var vService = ServiceContainer.GetService<IGasBLL>();
            try
            {
                vService.Focast();
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("预测出错：" + exc.Message);
                return;
            }
             */ 


            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("TIME,FFLOW", ModuleClass.FuncClass.ActivContrl[0].ToString() + "0_" + cbox2.Text.Trim() + "_FCST");
            ////设置DG
            DG1.DataSource = dataset.Tables[0];
            
            /////画图
            SetGragh(zg1);
            SetSize();



        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            textBox1.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Forecast_Leave(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            //timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (StartForecast == false)
            {
                /////BLL预测业务
                var vService = ServiceContainer.GetService<IGasBLL>();
                try
                {
                    vService.Forecast(cbox2.Text);
                    StartForecast = true;
                }
                catch (System.Exception exc)
                {
                    MessageBox.Show("预测出错：" + exc.Message);
                    return;
                }
            }
             
            
            string[] Num = cbox1.Text.Split('#');
            t = t + 1;
            if (t == 23)
                t = 0;
            string starttime="2013-06-17 "+t+":36:00.000";
            string endtime = "2013-06-17 "+(t+1)+":36:00.000";


            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("TIME,FFLOW", ModuleClass.FuncClass.ActivContrl[0].ToString() + "0_" + cbox2.Text.Trim() + "_FCST", "TIME", starttime, endtime);
            ////设置DG
            DG1.DataSource = dataset.Tables[0];

            /////画图
            SetGragh(zg1);
            SetSize();
        }

        private void StopBLL()
        {
            /////BLL预测业务
            var vService = ServiceContainer.GetService<IGasBLL>();
            try
            {
                vService.StopForecast();
                StartForecast = false;
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("预测出错：" + exc.Message);
                return;
            }
        }

    }
}
