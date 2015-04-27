using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class pop
    {
        public  double LinearRegression(double[,] data)
        {
            double[,] derivedData = new double[data.GetLength(0) + 1, data.GetLength(1) + 3];
            int i;
            for (i = 0; i < data.GetLength(0); i++)
            {
                derivedData[i, 0] = data[i, 0]; //X
                derivedData[i, 1] = data[i, 1]; //Y
                derivedData[i, 2] = data[i, 0] * data[i, 1]; //XY
                derivedData[i, 3] = data[i, 0] * data[i, 0]; //XX
                derivedData[i, 4] = data[i, 1] * data[i, 1]; //YY
                derivedData[derivedData.GetLength(0) - 1, 0] += derivedData[i, 0]; //X的累加
                derivedData[derivedData.GetLength(0) - 1, 1] += derivedData[i, 1]; //Y的累加
                derivedData[derivedData.GetLength(0) - 1, 2] += derivedData[i, 2]; //XY的累加
                derivedData[derivedData.GetLength(0) - 1, 3] += derivedData[i, 3]; //XX的累加
                derivedData[derivedData.GetLength(0) - 1, 4] += derivedData[i, 4]; //YY的累加
            }
            double xba = derivedData[derivedData.GetLength(0) - 1, 0] / data.GetLength(0);
            double yba = derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double Lxx = derivedData[derivedData.GetLength(0) - 1, 3] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 0], 2) / data.GetLength(0); double Lyy = derivedData[derivedData.GetLength(0) - 1, 4] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 1], 2) / data.GetLength(0);
            double Lxy = derivedData[derivedData.GetLength(0) - 1, 2] - derivedData[derivedData.GetLength(0) - 1, 0] * derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double b = Lxy / Lxx;
            double a = yba - b * xba;
            double s;
            int m=7;
            s = a + b * m;
             return s;
        }





        public double LinearRegression2(double[,] data)
        {
            double[,] derivedData = new double[data.GetLength(0) + 1, data.GetLength(1) + 3];
            int i;
            for (i = 0; i < data.GetLength(0); i++)
            {
                derivedData[i, 0] = data[i, 0]; //X
                derivedData[i, 1] = data[i, 1]; //Y
                derivedData[i, 2] = data[i, 0] * data[i, 1]; //XY
                derivedData[i, 3] = data[i, 0] * data[i, 0]; //XX
                derivedData[i, 4] = data[i, 1] * data[i, 1]; //YY
                derivedData[derivedData.GetLength(0) - 1, 0] += derivedData[i, 0]; //X的累加
                derivedData[derivedData.GetLength(0) - 1, 1] += derivedData[i, 1]; //Y的累加
                derivedData[derivedData.GetLength(0) - 1, 2] += derivedData[i, 2]; //XY的累加
                derivedData[derivedData.GetLength(0) - 1, 3] += derivedData[i, 3]; //XX的累加
                derivedData[derivedData.GetLength(0) - 1, 4] += derivedData[i, 4]; //YY的累加
            }
            double xba = derivedData[derivedData.GetLength(0) - 1, 0] / data.GetLength(0);
            double yba = derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double Lxx = derivedData[derivedData.GetLength(0) - 1, 3] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 0], 2) / data.GetLength(0); double Lyy = derivedData[derivedData.GetLength(0) - 1, 4] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 1], 2) / data.GetLength(0);
            double Lxy = derivedData[derivedData.GetLength(0) - 1, 2] - derivedData[derivedData.GetLength(0) - 1, 0] * derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double b = Lxy / Lxx;
            double a = yba - b * xba;
            double s;
            int m =8;
            s = a + b * m;
            return s;
        }




        public double LinearRegression3(double[,] data)
        {
            double[,] derivedData = new double[data.GetLength(0) + 1, data.GetLength(1) + 3];
            int i;
            for (i = 0; i < data.GetLength(0); i++)
            {
                derivedData[i, 0] = data[i, 0]; //X
                derivedData[i, 1] = data[i, 1]; //Y
                derivedData[i, 2] = data[i, 0] * data[i, 1]; //XY
                derivedData[i, 3] = data[i, 0] * data[i, 0]; //XX
                derivedData[i, 4] = data[i, 1] * data[i, 1]; //YY
                derivedData[derivedData.GetLength(0) - 1, 0] += derivedData[i, 0]; //X的累加
                derivedData[derivedData.GetLength(0) - 1, 1] += derivedData[i, 1]; //Y的累加
                derivedData[derivedData.GetLength(0) - 1, 2] += derivedData[i, 2]; //XY的累加
                derivedData[derivedData.GetLength(0) - 1, 3] += derivedData[i, 3]; //XX的累加
                derivedData[derivedData.GetLength(0) - 1, 4] += derivedData[i, 4]; //YY的累加
            }
            double xba = derivedData[derivedData.GetLength(0) - 1, 0] / data.GetLength(0);
            double yba = derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double Lxx = derivedData[derivedData.GetLength(0) - 1, 3] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 0], 2) / data.GetLength(0); double Lyy = derivedData[derivedData.GetLength(0) - 1, 4] - Math.Pow(derivedData[derivedData.GetLength(0) - 1, 1], 2) / data.GetLength(0);
            double Lxy = derivedData[derivedData.GetLength(0) - 1, 2] - derivedData[derivedData.GetLength(0) - 1, 0] * derivedData[derivedData.GetLength(0) - 1, 1] / data.GetLength(0);
            double b = Lxy / Lxx;
            double a = yba - b * xba;
            double s;
            int m = 9;
            s = a + b * m;
            return s;
        }
         






        public  double WeightedMovingAverage(double[] data)
        {
            int count = data.GetLength(0);
            double s = 0.0;
            //double s1;
            //for (int i = 0; i < x; i++)
            //{
                s = 0.0;
                for (int j = 0; j < count; j++)
                {
                    s += (j + 1) * data[j]; 
                } 
                s /= (count * (count + 1) / 2);
                for (int j = 0; j < count - 1; j++) 
                {
                    data[j] = data[j + 1]; 
                } 
                data[count - 1] = s;
            //}
            return s;
        }


    }
}
