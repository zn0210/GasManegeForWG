using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EAS.Modularization;

namespace Gas_test2.Res
{
	partial class AboutForm :Form
	{
        string LicenceText
        {
            get
            {
                return "<P style=\"FONT-SIZE: 12px\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���棺�����������������Ȩ���͹��ʹ�Լ�ı�����δ����Ȩ���Ը��ƻ�ɢ��������Ĳ��ֻ�ȫ�������������������º����´���������֪��Υ���߽����跨�ɷ�Χ�ڵ�ȫ���Ʋá�</P>";
            }
        }

		public AboutForm()
		{
			InitializeComponent();		
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.webBrowser.Navigate("about:blank");
		}

        private void llDeveloper_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.agilelab.cn");
            }
            catch
            {
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument html = this.webBrowser.Document;
            html.Body.InnerHtml = this.LicenceText;
        }
	}
}
