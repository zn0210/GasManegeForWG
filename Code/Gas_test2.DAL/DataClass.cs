using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Gas_test2.Entities;
using EAS.Data.ORM;

namespace Gas_test2.DAL
{
    public class DataClass
    {
        #region 定义与实例化
        BaseClass baseClass = new BaseClass();
        #endregion

        #region 查询，插入，删除，修改

        /// <summary>
        /// 查询，查询表的全部内容
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public DataSet QueryData(string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName, TableName);
            return returndataset;
        }

        /// <summary>
        /// 查询，查询表的一整列
        /// </summary>
        /// <param name="Clom">列名</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public DataSet QueryData(string Clom, string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName, TableName);
            return returndataset;
        }

        /// <summary>
        /// 查询，查询表里符合条件的元组，一整行
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">判定列名</param>
        /// <param name="str1">判定值</param>
        /// <returns></returns>      
        public DataSet QueryData(string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName + " where " + Clom1 + "='" + str1+"'", TableName);
            return returndataset;
        }

        /// <summary>
        /// 查询，查询表里符合条件的元组的某个列值
        /// </summary>
        /// <param name="Clom">目标列</param>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">判定列名</param>
        /// <param name="str1">判定值</param>
        /// <returns></returns>
        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName + " where " + Clom1 + "='" + str1+"'", TableName);
            return returndataset;
        }

        /// <summary>
        /// 查询，查询表中一时间段的数据
        /// </summary>
        /// <param name="Clom">目标列</param>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">判定列</param>
        /// <param name="str1">起</param>
        /// <param name="str2">止</param>
        /// <returns></returns>
        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string str2)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName + " where " + Clom1 + " between '" + str1 + "' and '" + str2 + "'", TableName);
            return returndataset;
        }

        /// <summary>
        /// 查询，查询表数据,两个条件
        /// </summary>
        /// <param name="Clom"></param>
        /// <param name="TableName"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName + " where " + Clom1 + " = '" + str1 + "' and " + Clom2 + " = '" + str2 + "'", TableName);
            return returndataset;

        }

        /// <summary>
        ///  插入, 插入元组,1个列值
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">列名</param>
        /// <param name="str1">插入值</param>
        /// <returns></returns>
        public int InsertData(string TableName, string Clom1, string str1)
        {
            return baseClass.ExecuteSQLcmd("insert into " + TableName + "(" + Clom1 + ")" + " values " + "('" + str1 + "')");
            
        }

        /// <summary>
        /// 插入, 插入元组,2个列值
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">列名1</param>
        /// <param name="str1">插入值1</param>
        /// <param name="Clom2">列名2</param>
        /// <param name="str2">插入值2</param>
        /// <returns></returns>
        public int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            return baseClass.ExecuteSQLcmd("insert into " + TableName + "(" + Clom1 + "," + Clom2 + ")" + " values " + "('" + str1 + "','" + str2 + "')");
            
        }

        /// <summary>
        /// 插入, 插入元组,3个列值
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">列名1</param>
        /// <param name="str1">插入值1</param>
        /// <param name="Clom2">列名2</param>
        /// <param name="str2">插入值2</param>
        /// <param name="Clom3">列名3</param>
        /// <param name="str3">插入值3</param>
        /// <returns></returns>
        public int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return baseClass.ExecuteSQLcmd("insert into " + TableName + "(" + Clom1 + "," + Clom2 + "," + Clom3 + ")" + " values " + "('" + str1 + "','" + str2 + "','" + str3 + "')");
            
        }

        /// <summary>
        /// 删除，从表中删除符合条件的元组，1个条件
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1">判定列</param>
        /// <param name="str1">判定值</param>
        /// <returns></returns>
        public int DeleteData(string TableName, string Clom1, string str1)
        {
            return baseClass.ExecuteSQLcmd("delete from " + TableName + " where " + Clom1 + "='" + str1 + "'");
            
        }

        /// <summary>
        /// 删除，从表中删除符合条件的元组，2个条件
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public int DeleteData(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            return baseClass.ExecuteSQLcmd("delete from " + TableName + " where " + Clom1 + "='" + str1 + "' and " + Clom2 + "='" + str2 + "'");
            
        }

        /// <summary>
        /// 删除，从表中删除符合条件的元组，3个条件
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <param name="Clom3"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public int DeleteData(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return baseClass.ExecuteSQLcmd("delete from " + TableName + " where " + Clom1 + " = '" + str1 + "' and " + Clom2 + "='" + str2 + "' and " + Clom3 + "='" + str3 + "'");
            
        }

        /// <summary>
        /// 修改，1个条件
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Clom"></param>
        /// <param name="str"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <returns></returns>
        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1)
        {
            return baseClass.ExecuteSQLcmd("update " + TableName + " set " + Clom + "='" + str + "' where " + Clom1 + "='" + str1 + "'");
            
        }

        /// <summary>
        ///  修改，2个条件
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Clom"></param>
        /// <param name="str"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2)
        {
            return baseClass.ExecuteSQLcmd("update " + TableName + " set " + Clom + "='" + str + "' where " + Clom1 + "= '" + str1 + "' and " + Clom2 + " = '" + str2 + "'");
            
        }

        /// <summary>
        ///  修改，3个条件
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Clom"></param>
        /// <param name="str"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <param name="Clom3"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return baseClass.ExecuteSQLcmd("update " + TableName + " set " + Clom + "='" + str + "' where " + Clom1 + "='" + str1 + "' and " + Clom2 + "='" + str2 + "' and " + Clom3 + "='" + str3 + "'");
            
        }

        #endregion
    }
}
