using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Threading;


using EAS.Data.Linq;
using EAS.Data.ORM;
using Gas_test2.Entities;
using EAS.Services;
using Gas_test2.DAL;
using MLApp;

namespace Gas_test2.BLL
{
    [ServiceObject("预测服务")]
    [ServiceBind(typeof(IGasBLL))]
    public  class GasForecast:IGasBLL
    {
        private FileClass fileControl = new FileClass();
        private DataClass dataControl = new DataClass();
        System.Threading.Timer Thread_Time;

        public int Forecast( )
        {
            Thread_Time = new System.Threading.Timer(Thread_Timer_Method2, null, 0, 2000);  //定时器
            return 0;
        }

        private void Thread_Timer_Method2(object state)
        {
            //定时启动几个线程
            //取数据库数据
            //调用算法计算
            //数据返回数据库
            //释放线程
        }

        public int Forecast(string AlgName)
        {
            
            #region 参数设定
            int i0 = 100;    //输入行
            int i1 = 1;      //输入列
            int o0 = 10;    //输入行
            int o1 = 1;      //输入列
            float[,] w = new float[i0, i1];
            

            string FnameI = @"E:\a.txt";
            string FnameO = @"E:\b.txt";

            //DbEntities db = new DbEntities();
            //var t = db.CreateTransaction();
            #endregion

             
            Thread_Time = new System.Threading.Timer(Thread_Timer_Method, null, 0, 2000);
            ///////查询数据                   
            

            //数组赋值
            for (int i = 0; i < 100; i++)
            {
                //w[i, 0] = tempList[i].Consumption;
            }

            //数组到txt
            fileControl.saveMatrix(w, FnameO);
            //Matlab运算
            Matlabfunc();
            //读txt到数组
            w = fileControl.readMatrix(o0, o1, FnameI);
            ////////数组到数据库
            


            //t.Commit();


            return 0;
        }

        public int StopForecast()
        {
            Thread_Time.Dispose();
            return 0;
        }

        private void Thread_Timer_Method(object state)
        {
            int i=0;
            i = i+1;
        }

        /// <summary>
        /// matlab调用
        /// </summary>
        private void Matlabfunc()
        {
            MLApp.MLAppClass matlab = new MLApp.MLAppClass();//调用matlab引擎
            string command;
            //command = "path(path,'E:\\code\\oldGas\\mcd')";
            command = @"path(path,'E:\code\gas_eas\Gas_test2\MATcode\test')";
            matlab.Execute(command);
            //command = "BFGWAVELET";
            command = "LSSVR";
            matlab.Visible = 0;
            matlab.Execute(command);     // 执行Matlab命令
        }



    }
}
