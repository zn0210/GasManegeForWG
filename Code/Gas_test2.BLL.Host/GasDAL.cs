using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EAS.Data.Linq;
using EAS.Data.ORM;
using Gas_test2.Entities;
using EAS.Services;
using Gas_test2.DAL;


namespace Gas_test2.BLL
{
    [ServiceObject("数据服务")]
    [ServiceBind(typeof(IGasDAL))]
    public class GasDAL:IGasDAL
    {
        private DataClass dataControl = new DataClass();
        private TabClass tabControl = new TabClass();

        public DataSet QueryData(string table_name)
        {
            return (dataControl.QueryData(table_name));
        }

        public DataSet QueryData(string column_name, string table_name)
        {
            return (dataControl.QueryData(column_name, table_name));
        }

        public DataSet QueryData(string TableName, string Clom1, string str1)
        {
            return (dataControl.QueryData( TableName,  Clom1,  str1));
        }

        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1)
        {
            return (dataControl.QueryData( Clom,  TableName,  Clom1,  str1));
        }

        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string str2)
        {
            return dataControl.QueryData(Clom, TableName, Clom1, str1, str2);
        }

        public DataSet QueryData(string Clom, string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            return dataControl.QueryData(Clom, TableName, Clom1, str1,Clom2, str2);
        }

        public int InsertData(string TableName, string Clom1, string str1)
        {
            return dataControl.InsertData(TableName, Clom1, str1);
        }

        public int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            return dataControl.InsertData(TableName, Clom1, str1, Clom2, str2);
        }

        public int InsertData(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return dataControl.InsertData(TableName, Clom1, str1, Clom2, str2, Clom3, str3);
        }

        public int DeleteData(string TableName, string Clom1, string str1)
        {
            return dataControl.DeleteData(TableName, Clom1, str1);
        }

        public int DeleteData(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            return dataControl.DeleteData(TableName, Clom1, str1, Clom2, str2);
        }

        public int DeleteData(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return dataControl.DeleteData(TableName, Clom1, str1, Clom2, str2, Clom3, str3);
        }

        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1)
        {
            return dataControl.UpdateData(TableName, Clom, str, Clom1, str1);
        }

        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2)
        {
            return dataControl.UpdateData(TableName, Clom, str, Clom1, str1, Clom2, str2);
        }

        public int UpdateData(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            return dataControl.UpdateData(TableName, Clom, str, Clom1, str1, Clom2, str2, Clom3, str3);
        }

        public int UpdateOE(string tablename, string Sclom0, string Sstr0, string Sclom1, string Sstr1, string Tclom3, string Tstr3, string Tclom4, string Tstr4)
        {
            //return dataControl.UpdateData(dataControl, Sclom0, Sstr0, Tclom3, Tstr3, Tclom4, Tstr4);
            int a=dataControl.UpdateData(tablename, Sclom0, Sstr0, Tclom3, Tstr3, Tclom4, Tstr4);
            int b=dataControl.UpdateData(tablename, Sclom1, Sstr1, Tclom3, Tstr3, Tclom4, Tstr4);
            
            return (a * b) ;
            //UpdateData( TableName,  Clom,  str,  Clom1,  str1,  Clom2,  str2)
            //dataControl.UpdateData(dataControl, Sclom0, Sstr0, Tclom3, Tstr3, Tclom4, Tstr4);
        }

        public int CreatEquipTab()
        {
            DataSet dataset = new DataSet();
            

            dataset=dataControl.QueryData("EquipTypeSlet", "Selected", "1");
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                for (int i = 0; i < int.Parse(dataset.Tables[0].Rows[j]["EquipNum"].ToString()); i++)
                {
                    tabControl.CreatEquipTabPart1(dataset.Tables[0].Rows[j]["ETabName"].ToString(), (i + 1).ToString());
                    string L1, L2, L3;

                    L1 = dataset.Tables[0].Rows[j]["L1"].ToString();
                    string[] L1D = L1.Split(';');
                    
                    for (int k = 0; k < L1D.Count() - 1; k++)
                    {
                        tabControl.AddTableColum(dataset.Tables[0].Rows[j]["ETabName"].ToString(), (i + 1).ToString() + "_L1", L1D[k]);
                        
                    }

                    L2 = dataset.Tables[0].Rows[j]["L2"].ToString();
                    string[] L2D = L2.Split(';');

                    for (int k = 0; k < L2D.Count() - 1; k++)
                    {
                        tabControl.AddTableColum(dataset.Tables[0].Rows[j]["ETabName"].ToString(), (i + 1).ToString() + "_L2", L2D[k]);

                    }

                    L3 = dataset.Tables[0].Rows[j]["L3"].ToString();
                    string[] L3D = L3.Split(';');

                    for (int k = 0; k < L3D.Count() - 1; k++)
                    {
                        tabControl.AddTableColum(dataset.Tables[0].Rows[j]["ETabName"].ToString(), (i + 1).ToString() + "_L3", L3D[k]);

                    }

                }
                j++;
            }



            return 0;
        }

        public int CreatEquipTab(string ETabName, string Num)
        {
            return tabControl.CreatEquipTab( ETabName, Num);
        }

        public int CreatAlgTab()
        {
            DataSet dataset = new DataSet();

            dataset = dataControl.QueryData("EquipAlgSlet");
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {

                tabControl.CreatAlgTabPart1(dataset.Tables[0].Rows[j]["EquipName"].ToString(), "0", dataset.Tables[0].Rows[j]["AlgName"].ToString());
                string Factor;

                Factor = dataset.Tables[0].Rows[j]["Factor"].ToString();
                string[] FactorD = Factor.Split(';');

                for (int k = 0; k < FactorD.Count() - 1; k++)
                {
                    tabControl.AddTableColum(dataset.Tables[0].Rows[j]["EquipName"].ToString(), "0_"+dataset.Tables[0].Rows[j]["AlgName"].ToString()+"_FCST", FactorD[k]);

                }


                
                j++;
            }


            return 0;
        }

        public int CreatAlgTab(string ETabName,string Num,string ATabName)
        {
            return tabControl.CreatAlgTab( ETabName, Num, ATabName);
        }

        public DataSet QueryTabName()
        {
            return tabControl.QueryTabName();
        }

        public int DropTable(string tableName)
        {
            return tabControl.DropTable(tableName);
        }
    }
}
