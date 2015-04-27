using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EAS.Services;
using Gas_test2.BLL;

namespace Gas_test2.WinUI.FormView
{
    public partial class ClearData : Form
    {
        private DataSet dataset = new DataSet();

        string[] tablename = new string[] {"EquipTypeSlet","EAS_ACCOUNTGROUPING","EAS_ACCOUNTS","EAS_ACL","EAS_APPSETTINGS","EAS_BUGS","EAS_CERTIFICATE",
            "EAS_DESKTOPITEM","EAS_ERRORLOG","EAS_GROUPS","EAS_IDENTITYVALUES","EAS_LOGS","EAS_MODULEGROUPS","EAS_MODULES","EAS_ORGANIZATION",
             "EAS_PACKAGE","EAS_REPORTS","EAS_ROLES","IM_MESSAGE","WF_DEFINE","WF_EXECUTE","WF_INSTANCE","WF_INSTANCESTATE","WF_STATE","EAS_INPUTDICT",
             "EAS_VARIABLES","EAS_CACHEITEM","SOA_SUBSCRIBEEVENTS","TB_LEAVE","AlgTypeAbl","EquipTypeAbl","EquipAlgSlet"};

        public ClearData()
        {
            InitializeComponent();
        }

        private void ClearData_Load(object sender, EventArgs e)
        {

            dataset=ServiceContainer.GetService<IGasDAL>().QueryTabName();
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                bool bl = true;
                for (int i = 0; i < tablename.Length; i++)
                {
                    if (dataset.Tables[0].Rows[j][0].ToString() == tablename[i]) 
                    { 
                        bl = false;
                        break; 
                    } 
                }

                if (bl == true)
                    lbox_Table.Items.Add(dataset.Tables[0].Rows[j][0]);
                j++;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lbox_Table.Items.Count != 0)
            {
                if (lbox_Table.SelectedItems.Count != 0)
                {
                    ServiceContainer.GetService<IGasDAL>().DropTable(lbox_Table.SelectedItem.ToString());
                    lbox_Table.Items.RemoveAt(lbox_Table.SelectedIndex);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
