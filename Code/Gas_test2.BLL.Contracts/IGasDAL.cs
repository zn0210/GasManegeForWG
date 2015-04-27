using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gas_test2.Entities;

namespace Gas_test2.BLL
{
    public interface IGasDAL
    {
        /// <summary>
        /// 查询整张表
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        DataSet QueryData(string table_name);

        /// <summary>
        /// 查询一张表的整列数据
        /// </summary>
        /// <param name="column_name">列名</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        DataSet QueryData(string column_name, string table_name);

        /// <summary>
        /// 查询一张表的一行数据
        /// </summary>
        /// <param name="row_name">主键值</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        DataSet QueryData(string TableName, string Clom1, string str1);

        /// <summary>
        /// 查询一行数据的某列值
        /// </summary>
        /// <param name="Clom"></param>
        /// <param name="TableName"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <returns></returns>
        DataSet QueryData(string Clom, string TableName, string Clom1, string str1);

        /// <summary>
        /// 查询一段数据
        /// </summary>
        /// <param name="Clom"></param>
        /// <param name="TableName"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string str2);

        /// <summary>
        /// 查询，两个判定条件
        /// </summary>
        /// <param name="Clom"></param>
        /// <param name="TableName"></param>
        /// <param name="Clom1"></param>
        /// <param name="str1"></param>
        /// <param name="Clom2"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string Clom2, string str2);


        /// <summary>
        /// 删除指定表中某行数据
        /// </summary>
        /// <param name="value">查询值</param>
        /// <param name="column_name">列名</param>
        /// <param name="table_name">表名</param>
        int DeleteData(string TableName, string Clom1, string str1);
        int DeleteData(string TableName, string Clom1, string str1, string Clom2, string str2);

        /// <summary>
        /// 添加一行数据
        /// </summary>
        int InsertData(string TableName, string Clom1, string str1);
        int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2);
        int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3);

        /// <summary>
        /// 修改一行数据数据
        /// </summary>
        int UpdateData(string TableName, string Clom, string str, string Clom1, string str1);
        int UpdateData(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2);

        /// <summary>
        /// 添加AlgTypeAbl一行数据
        /// </summary>
        /// <param name="AlgName">算法名称</param>
        /// <param name="ATabName">算法简称</param>
        //void AddAlgTypeAbl(string AlgName, string ATabName);

        /// <summary>
        /// 更新算法路径设置
        /// </summary>
        /// <param name="AlgRoute">m文件路径</param>
        /// <param name="AlgParaRoute">算法配置路径</param>
        /// <param name="AlgName">算法名称</param>
        //void UpdataAlgTypeAbl(string AlgRoute, string AlgParaRoute, string AlgName);

        /// <summary>
        /// 查询EquipName是否存在，存在则update，否则insert
        /// </summary>
        /// <param name="EquipName">设备名</param>
        /// <param name="Alg">算法名称</param>
        //void EditAlgTypeSlet(string EquipName,string Alg);

        DataSet QueryTabName();

        int UpdateOE(string tablename, string Sclom0, string Sstr0, string Sclom1, string Sstr1, string Tclom3, string Tstr3, string Tclom4, string Tstr4);

        int DropTable(string tableName);

        int CreatEquipTab();

        int CreatEquipTab(string ETabName, string Num);

        int CreatAlgTab();

        int CreatAlgTab(string ETabName, string Num, string ATabName);
    }
}
