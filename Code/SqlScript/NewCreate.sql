use Gas
go
--create schema dbo
--go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_REAL') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_REAL
go

create table (设备简称)(编号)_REAL (
    TIME DATETIME  NOT NULL ,
    FLOW FLOAT  NULL ,
    CLRFC FLOAT  NULL ,
    GTYPE BIT  NULL 
) 
go

alter table (设备简称)(编号)_REAL add 
    CONSTRAINT pk_(设备简称)(编号)_REAL PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'煤气实测数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_REAL', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_REAL', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'流量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_REAL', N'column', N'FLOW'
go
DECLARE @v sql_variant
SET @v = N'热值'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_REAL', N'column', N'CLRFC'
go
DECLARE @v sql_variant
SET @v = N'产耗类型'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_REAL', N'column', N'GTYPE'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_FCST
go

create table (设备简称)(编号)_FCST (
    TIME DATETIME  NOT NULL ,
    FLOW FLOAT  NULL ,
    GTYPE BIT  NULL ,
    ERROR FLOAT  NULL 
) 
go

alter table (设备简称)(编号)_FCST add 
    CONSTRAINT pk_(设备简称)(编号)_FCST PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'煤气预测数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_FCST', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_FCST', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'流量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_FCST', N'column', N'FLOW'
go
DECLARE @v sql_variant
SET @v = N'产耗类型'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_FCST', N'column', N'GTYPE'
go
DECLARE @v sql_variant
SET @v = N'误差'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_FCST', N'column', N'ERROR'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_L1') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_L1
go

create table (设备简称)(编号)_L1 (
    TIME DATETIME  NOT NULL ,
    FACTOR1 FLOAT  NULL ,
    FACTORn FLOAT  NULL 
) 
go

alter table (设备简称)(编号)_L1 add 
    CONSTRAINT pk_(设备简称)(编号)_L1 PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'设备直采因素数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L1', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L1', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'因素1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L1', N'column', N'FACTOR1'
go
DECLARE @v sql_variant
SET @v = N'因素n'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L1', N'column', N'FACTORn'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_L2') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_L2
go

create table (设备简称)(编号)_L2 (
    TIME DATETIME  NOT NULL ,
    FACTOR1 FLOAT  NULL ,
    FACTORn FLOAT  NULL 
) 
go

alter table (设备简称)(编号)_L2 add 
    CONSTRAINT pk_(设备简称)(编号)_L2 PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'设备操作因素数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L2', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L2', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'因素1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L2', N'column', N'FACTOR1'
go
DECLARE @v sql_variant
SET @v = N'因素n'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L2', N'column', N'FACTORn'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_L3') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_L3
go

create table (设备简称)(编号)_L3 (
    TIME DATETIME  NOT NULL ,
    FACTOR1 FLOAT  NULL ,
    FACTORn FLOAT  NULL 
) 
go

alter table (设备简称)(编号)_L3 add 
    CONSTRAINT pk_(设备简称)(编号)_L3 PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'生产计划因素数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L3', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L3', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'因素1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L3', N'column', N'FACTOR1'
go
DECLARE @v sql_variant
SET @v = N'因素n'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_L3', N'column', N'FACTORn'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备名)（号）_STATE') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备名)（号）_STATE
go

create table (设备名)（号）_STATE (
    TIME DATETIME  NOT NULL ,
    STATE INT  NULL ,
    STATENOTE NVARCHAR(30)  NULL ,
    WYEAR INT  NULL 
) 
go

alter table (设备名)（号）_STATE add 
    CONSTRAINT pk_(设备名)（号）_STATE PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'设备状态表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备名)（号）_STATE', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备名)（号）_STATE', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'状态值'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备名)（号）_STATE', N'column', N'STATE'
go
DECLARE @v sql_variant
SET @v = N'状态说明'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备名)（号）_STATE', N'column', N'STATENOTE'
go
DECLARE @v sql_variant
SET @v = N'使用年限'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备名)（号）_STATE', N'column', N'WYEAR'
go

if exists (select * from dbo.sysobjects where id = object_id(N'(设备简称)(编号)_(算法)_FCST') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table (设备简称)(编号)_(算法)_FCST
go

create table (设备简称)(编号)_(算法)_FCST (
    TIME DATETIME  NOT NULL ,
    RFLOW FLOAT  NULL ,
    FFLOW FLOAT  NULL ,
    ERROR FLOAT  NULL ,
    FACTOR1 FLOAT  NULL ,
    FACTORn FLOAT  NULL 
) 
go

alter table (设备简称)(编号)_(算法)_FCST add 
    CONSTRAINT pk_(设备简称)(编号)_(算法)_FCST PRIMARY KEY  CLUSTERED 
    (
        TIME
    ) 
go
DECLARE @v sql_variant
SET @v = N'算法数据表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'TIME'
go
DECLARE @v sql_variant
SET @v = N'真实流量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'RFLOW'
go
DECLARE @v sql_variant
SET @v = N'预测流量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'FFLOW'
go
DECLARE @v sql_variant
SET @v = N'误差'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'ERROR'
go
DECLARE @v sql_variant
SET @v = N'因素1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'FACTOR1'
go
DECLARE @v sql_variant
SET @v = N'因素n'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'(设备简称)(编号)_(算法)_FCST', N'column', N'FACTORn'
go

