using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAS.Modularization;

namespace Gas_test2.Res
{
    [Module("41B94B7C-62CE-478A-8986-06A4731E2822", "启始页", "AgileEAS.NET平台WinForm/Wpf容器起始页模块")]
    public partial class StartWF : UserControl
    {
        [ModuleStart]
        public void Start()
        {
            WorkFlow wf = new WorkFlow();
            wf.Top = 0;
            wf.Left = 0;
            wf.Dock = DockStyle.None;

            int widht = wf.Width;
            int height = wf.Height;

            this.panMain.Controls.Add(wf);
        }

        public StartWF()
        {
            InitializeComponent();
        }
    }
}
