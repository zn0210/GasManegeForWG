using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gas_test2.DAL
{
    public class TabClass
    {
        #region 定义与实例化
        BaseClass baseClass = new BaseClass();
        #endregion

        #region 创建，删除，修改

        /// <summary>
        /// 创建设备数据表
        /// </summary>
        /// <param name="ETabName"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public int CreatEquipTab(string ETabName,string Num)
        {
            return baseClass.ExecuteSQLcmd(@"if exists (select * from dbo.sysobjects where id = object_id(N'"+ETabName+Num+@"_REAL') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table "+ETabName+Num+@"_REAL "+

                @"create table "+ETabName+Num+@"_REAL (TIME DATETIME  NOT NULL ,FLOW FLOAT  NULL ,CLRFC FLOAT  NULL ,GTYPE BIT  NULL) "+

                @"alter table "+ETabName+Num+@"_REAL add CONSTRAINT pk_"+ETabName+Num+@"_REAL PRIMARY KEY  CLUSTERED (TIME ) "+

                @"DECLARE @q sql_variant SET @q = N'煤气实测数据表' EXECUTE sp_addextendedproperty N'MS_Description', @q, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+@"_REAL', NULL, NULL "+

                @"DECLARE @w sql_variant SET @w = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @w, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'TIME' " +

                @"DECLARE @e sql_variant SET @e = N'流量' EXECUTE sp_addextendedproperty N'MS_Description', @e, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'FLOW' " +

                @"DECLARE @r sql_variant SET @r = N'热值' EXECUTE sp_addextendedproperty N'MS_Description', @r, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'CLRFC' " +

                @"DECLARE @t sql_variant SET @t = N'产耗类型' EXECUTE sp_addextendedproperty N'MS_Description', @t, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'GTYPE' "+

                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_FCST " +

                @"create table " + ETabName + Num + @"_FCST (TIME DATETIME  NOT NULL ,FLOW FLOAT  NULL ,GTYPE BIT  NULL ,ERROR FLOAT  NULL )" +

                @"alter table " + ETabName + Num + @"_FCST add CONSTRAINT pk_" + ETabName + Num + @"_FCST PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @y sql_variant SET @y = N'煤气预测数据表' EXECUTE sp_addextendedproperty N'MS_Description', @y, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', NULL, NULL " +

                @"DECLARE @u sql_variant SET @u = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @u, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'TIME' " +

                @"DECLARE @i sql_variant SET @i = N'流量' EXECUTE sp_addextendedproperty N'MS_Description', @i, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'FLOW' " +

                @"DECLARE @o sql_variant SET @o = N'产耗类型' EXECUTE sp_addextendedproperty N'MS_Description', @o, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'GTYPE' " +

                @"DECLARE @p sql_variant SET @p = N'误差' EXECUTE sp_addextendedproperty N'MS_Description', @p, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'ERROR' " +

                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L1') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L1 " +

                @"create table " + ETabName + Num + @"_L1 (TIME DATETIME  NOT NULL , FACTOR1 FLOAT  NULL , FACTORn FLOAT  NULL) " +

                @"alter table " + ETabName + Num + @"_L1 add CONSTRAINT pk_" + ETabName + Num + @"_L1 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @a sql_variant SET @a = N'设备直采因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @a, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', NULL, NULL " +

                @"DECLARE @s sql_variant SET @s = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @s, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', N'column', N'TIME' " +

                @"DECLARE @d sql_variant SET @d = N'因素1' EXECUTE sp_addextendedproperty N'MS_Description', @d, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', N'column', N'FACTOR1' " +

                @"DECLARE @f sql_variant SET @f = N'因素n' EXECUTE sp_addextendedproperty N'MS_Description', @f, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', N'column', N'FACTORn' " +

                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L2') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L2 " +

                @"create table " + ETabName + Num + @"_L2 (TIME DATETIME  NOT NULL , FACTOR1 FLOAT  NULL , FACTORn FLOAT  NULL ) " +

                @"alter table " + ETabName + Num + @"_L2 add CONSTRAINT pk_" + ETabName + Num + @"_L2 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @g sql_variant SET @g = N'设备操作因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @g, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', NULL, NULL " +

                @"DECLARE @h sql_variant SET @h = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @h, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', N'column', N'TIME' " +

                @"DECLARE @j sql_variant SET @j = N'因素1' EXECUTE sp_addextendedproperty N'MS_Description', @j, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', N'column', N'FACTOR1' " +

                @"DECLARE @k sql_variant SET @k = N'因素n' EXECUTE sp_addextendedproperty N'MS_Description', @k, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', N'column', N'FACTORn' " +

                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L3') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L3 " +

                @"create table " + ETabName + Num + @"_L3 (TIME DATETIME  NOT NULL , FACTOR1 FLOAT  NULL ,FACTORn FLOAT  NULL) " +

                @"alter table " + ETabName + Num + @"_L3 add CONSTRAINT pk_" + ETabName + Num + @"_L3 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @z sql_variant SET @z = N'生产计划因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @z, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', NULL, NULL " +

                @"DECLARE @x sql_variant SET @x = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @x, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', N'column', N'TIME' " +

                @"DECLARE @c sql_variant SET @c = N'因素1' EXECUTE sp_addextendedproperty N'MS_Description', @c, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', N'column', N'FACTOR1' " +

                @"DECLARE @v sql_variant SET @v = N'因素n' EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', N'column', N'FACTORn' " +

                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_STATE') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_STATE " +

                @"create table " + ETabName + Num + @"_STATE (TIME DATETIME  NOT NULL , STATE INT  NULL , STATENOTE NVARCHAR(30)  NULL , WYEAR INT  NULL ) " +

                @"alter table " + ETabName + Num + @"_STATE add CONSTRAINT pk_" + ETabName + Num + @"_STATE PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @b sql_variant SET @b = N'设备状态表' EXECUTE sp_addextendedproperty N'MS_Description', @b, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', NULL, NULL " +

                @"DECLARE @n sql_variant SET @n = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @n, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'TIME' " +

                @"DECLARE @m sql_variant SET @m = N'状态值' EXECUTE sp_addextendedproperty N'MS_Description', @m, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'STATE' " +

                @"DECLARE @l sql_variant SET @l = N'状态说明' EXECUTE sp_addextendedproperty N'MS_Description', @l, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'STATENOTE' " +

                @"DECLARE @vv sql_variant SET @vv = N'使用年限' EXECUTE sp_addextendedproperty N'MS_Description', @vv, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'WYEAR' " 
                );
            
        }

        /// <summary>
        /// 创建设备表，不带因素列
        /// </summary>
        /// <param name="ETabName"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public int CreatEquipTabPart1(string ETabName, string Num)
        {
            return baseClass.ExecuteSQLcmd(
                ////////////////////real
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_REAL') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_REAL " +

                @"create table " + ETabName + Num + @"_REAL (TIME DATETIME  NOT NULL ,FLOW FLOAT  NULL ,CLRFC FLOAT  NULL ,GTYPE BIT  NULL) " +

                @"alter table " + ETabName + Num + @"_REAL add CONSTRAINT pk_" + ETabName + Num + @"_REAL PRIMARY KEY  CLUSTERED (TIME ) " +

                @"DECLARE @q sql_variant SET @q = N'煤气实测数据表' EXECUTE sp_addextendedproperty N'MS_Description', @q, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', NULL, NULL " +

                @"DECLARE @w sql_variant SET @w = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @w, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'TIME' " +

                @"DECLARE @e sql_variant SET @e = N'流量' EXECUTE sp_addextendedproperty N'MS_Description', @e, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'FLOW' " +

                @"DECLARE @r sql_variant SET @r = N'热值' EXECUTE sp_addextendedproperty N'MS_Description', @r, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'CLRFC' " +

                @"DECLARE @t sql_variant SET @t = N'产耗类型' EXECUTE sp_addextendedproperty N'MS_Description', @t, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_REAL', N'column', N'GTYPE' " +

                ////////////////FCST
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_FCST " +

                @"create table " + ETabName + Num + @"_FCST (TIME DATETIME  NOT NULL ,FLOW FLOAT  NULL ,GTYPE BIT  NULL ,ERROR FLOAT  NULL )" +

                @"alter table " + ETabName + Num + @"_FCST add CONSTRAINT pk_" + ETabName + Num + @"_FCST PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @y sql_variant SET @y = N'煤气预测数据表' EXECUTE sp_addextendedproperty N'MS_Description', @y, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', NULL, NULL " +

                @"DECLARE @u sql_variant SET @u = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @u, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'TIME' " +

                @"DECLARE @i sql_variant SET @i = N'流量' EXECUTE sp_addextendedproperty N'MS_Description', @i, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'FLOW' " +

                @"DECLARE @o sql_variant SET @o = N'产耗类型' EXECUTE sp_addextendedproperty N'MS_Description', @o, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'GTYPE' " +

                @"DECLARE @p sql_variant SET @p = N'误差' EXECUTE sp_addextendedproperty N'MS_Description', @p, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_FCST', N'column', N'ERROR' " +

                ////////////////L1
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L1') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L1 " +

                @"create table " + ETabName + Num + @"_L1 (TIME DATETIME  NOT NULL ) " +

                @"alter table " + ETabName + Num + @"_L1 add CONSTRAINT pk_" + ETabName + Num + @"_L1 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @a sql_variant SET @a = N'设备直采因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @a, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', NULL, NULL " +

                @"DECLARE @s sql_variant SET @s = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @s, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L1', N'column', N'TIME' " +

                //////////////L2
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L2') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L2 " +

                @"create table " + ETabName + Num + @"_L2 (TIME DATETIME  NOT NULL ) " +

                @"alter table " + ETabName + Num + @"_L2 add CONSTRAINT pk_" + ETabName + Num + @"_L2 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @g sql_variant SET @g = N'设备操作因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @g, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', NULL, NULL " +

                @"DECLARE @h sql_variant SET @h = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @h, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L2', N'column', N'TIME' " +

                /////////////////L3
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_L3') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_L3 " +

                @"create table " + ETabName + Num + @"_L3 (TIME DATETIME  NOT NULL ) " +

                @"alter table " + ETabName + Num + @"_L3 add CONSTRAINT pk_" + ETabName + Num + @"_L3 PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @z sql_variant SET @z = N'生产计划因素数据表' EXECUTE sp_addextendedproperty N'MS_Description', @z, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', NULL, NULL " +

                @"DECLARE @x sql_variant SET @x = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @x, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_L3', N'column', N'TIME' " +

                ////////////STATE
                @"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + @"_STATE') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + @"_STATE " +

                @"create table " + ETabName + Num + @"_STATE (TIME DATETIME  NOT NULL , STATE INT  NULL , STATENOTE NVARCHAR(30)  NULL , WYEAR INT  NULL ) " +

                @"alter table " + ETabName + Num + @"_STATE add CONSTRAINT pk_" + ETabName + Num + @"_STATE PRIMARY KEY  CLUSTERED (TIME) " +

                @"DECLARE @b sql_variant SET @b = N'设备状态表' EXECUTE sp_addextendedproperty N'MS_Description', @b, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', NULL, NULL " +

                @"DECLARE @n sql_variant SET @n = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @n, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'TIME' " +

                @"DECLARE @m sql_variant SET @m = N'状态值' EXECUTE sp_addextendedproperty N'MS_Description', @m, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'STATE' " +

                @"DECLARE @l sql_variant SET @l = N'状态说明' EXECUTE sp_addextendedproperty N'MS_Description', @l, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'STATENOTE' " +

                @"DECLARE @vv sql_variant SET @vv = N'使用年限' EXECUTE sp_addextendedproperty N'MS_Description', @vv, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + @"_STATE', N'column', N'WYEAR' "
                );

        }


        /// <summary>
        /// 创建算法表
        /// </summary>
        /// <param name="ETabName"></param>
        /// <param name="Num"></param>
        /// <param name="ATabName"></param>
        /// <returns></returns>
        public int CreatAlgTab(string ETabName,string Num,string ATabName)
        {
            return baseClass.ExecuteSQLcmd(@"if exists (select * from dbo.sysobjects where id = object_id(N'"+ETabName+Num+"_"+ATabName+@"_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table "+ETabName+Num+"_"+ATabName+@"_FCST "+

                @"create table "+ETabName+Num+"_"+ATabName+@"_FCST ( TIME DATETIME  NOT NULL ,RFLOW FLOAT  NULL ,FFLOW FLOAT  NULL ,ERROR FLOAT  NULL ,FACTOR1 FLOAT  NULL ,FACTORn FLOAT  NULL) "+

                @"alter table "+ETabName+Num+"_"+ATabName+@"_FCST add CONSTRAINT pk_"+ETabName+Num+"_"+ATabName+@"_FCST PRIMARY KEY  CLUSTERED (TIME ) "+

                @"DECLARE @q sql_variant SET @q = N'算法数据表' EXECUTE sp_addextendedproperty N'MS_Description', @q, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', NULL, NULL "+

                @"DECLARE @w sql_variant SET @w = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @w, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'TIME' "+

                @"DECLARE @e sql_variant SET @e = N'真实流量' EXECUTE sp_addextendedproperty N'MS_Description', @e, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'RFLOW' "+

                @"DECLARE @r sql_variant SET @r = N'预测流量' EXECUTE sp_addextendedproperty N'MS_Description', @r, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'FFLOW' "+

                @"DECLARE @t sql_variant SET @t = N'误差' EXECUTE sp_addextendedproperty N'MS_Description', @t, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'ERROR' "+

                @"DECLARE @y sql_variant SET @y = N'因素1' EXECUTE sp_addextendedproperty N'MS_Description', @y, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'FACTOR1' "+

                @"DECLARE @u sql_variant SET @u = N'因素n' EXECUTE sp_addextendedproperty N'MS_Description', @u, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+"_"+ATabName+@"_FCST', N'column', N'FACTORn' ");
            
        }

        public int CreatAlgTabPart1(string ETabName, string Num, string ATabName)
        {
            return baseClass.ExecuteSQLcmd(@"if exists (select * from dbo.sysobjects where id = object_id(N'" + ETabName + Num + "_" + ATabName + @"_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table " + ETabName + Num + "_" + ATabName + @"_FCST " +

                @"create table " + ETabName + Num + "_" + ATabName + @"_FCST ( TIME DATETIME  NOT NULL ,RFLOW FLOAT  NULL ,FFLOW FLOAT  NULL ,ERROR FLOAT  NULL ) " +

                @"alter table " + ETabName + Num + "_" + ATabName + @"_FCST add CONSTRAINT pk_" + ETabName + Num + "_" + ATabName + @"_FCST PRIMARY KEY  CLUSTERED (TIME ) " +

                @"DECLARE @q sql_variant SET @q = N'算法数据表' EXECUTE sp_addextendedproperty N'MS_Description', @q, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + "_" + ATabName + @"_FCST', NULL, NULL " +

                @"DECLARE @w sql_variant SET @w = N'时间' EXECUTE sp_addextendedproperty N'MS_Description', @w, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + "_" + ATabName + @"_FCST', N'column', N'TIME' " +

                @"DECLARE @e sql_variant SET @e = N'真实流量' EXECUTE sp_addextendedproperty N'MS_Description', @e, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + "_" + ATabName + @"_FCST', N'column', N'RFLOW' " +

                @"DECLARE @r sql_variant SET @r = N'预测流量' EXECUTE sp_addextendedproperty N'MS_Description', @r, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + "_" + ATabName + @"_FCST', N'column', N'FFLOW' " +

                @"DECLARE @t sql_variant SET @t = N'误差' EXECUTE sp_addextendedproperty N'MS_Description', @t, N'SCHEMA', N'dbo', N'table', N'" + ETabName + Num + "_" + ATabName + @"_FCST', N'column', N'ERROR' ");
        }


        /// <summary>
        /// 查询所有表名
        /// </summary>
        /// <returns></returns>
        public DataSet QueryTabName()
        {
            return baseClass.getDataSet("select name from sysobjects where xtype='u'","master");
        }

        /// <summary>
        /// 添加数据表列
        /// </summary>
        /// <param name="ETabName"></param>
        /// <param name="Num"></param>
        /// <param name="column_name1"></param>
        /// <returns></returns>
        public int AddTableColum(string ETabName,string Num, string column_name1)
        {
            return baseClass.ExecuteSQLcmd(@"alter table " + ETabName + Num + @" add " + column_name1 + " FLOAT NULL" 

                //@"DECLARE @q sql_variant SET @q = N'煤气实测数据表' EXECUTE sp_addextendedproperty N'MS_Description', @q, N'SCHEMA', N'dbo', N'table', N'"+ETabName+Num+@"_REAL', NULL, NULL "
                );
        }



        // 创建一个有两个字段的数据表
        public int CreateTable(string tableName, string colum_name1, string colum_name2, string datatype1, string datatype2)
        {
            return baseClass.ExecuteSQLcmd("create table " + tableName + "(" + colum_name1 + datatype1 + "," + colum_name2 + datatype2 + ")" + ";");
            
        }

        //在其他文件组上创建两个字段的数据表
        public int CreateTable(string tableName, string colum_name1, string colum_name2, string file_name, string datatype1, string datatype2)
        {
            return baseClass.ExecuteSQLcmd("create table " + tableName + "(" + colum_name1 + datatype1 + "," + colum_name2 + datatype2 + ")" + "on" + file_name + ";");
            
        }



        //更改数据表中一列的数据类型     
        public int UpdateTable(string tableName, string column_name1, string datatype)
        {
            return baseClass.ExecuteSQLcmd("alter table " + tableName + " alter column " + column_name1 + datatype + ";"); 
            
        }

        //向数据表中添加一个字段    
        public int AddTable(string tableName, string column_name1, string datatype)
        {
            return baseClass.ExecuteSQLcmd("alter table" + tableName + " add " + column_name1 + datatype + ";");
            
        }

        //删除数据表中一个字段     
        public int DropTable(string tableName, string column_name1)
        {
            return baseClass.ExecuteSQLcmd("alter table " + tableName + " drop column " + column_name1 + ";");
            
        }

        //删除一个数据表;
        public int DropTable(string tableName)
        {
            return baseClass.ExecuteSQLcmd("drop table " + tableName + ";");
            
        }
        #endregion
    }
}
