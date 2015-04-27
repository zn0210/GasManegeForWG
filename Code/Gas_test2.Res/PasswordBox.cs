using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EAS.Modularization;
using EAS.Services;
using EAS.Explorer.BLL;

namespace Gas_test2.Res
{
    [Module("5FCF96C2-F5BB-47C9-8524-0AE2511AB1E3", "�����޸�", "AgileEAS.NETƽ̨WinForm/Wpf���������޸�ģ��")]
	partial class PasswordBox:Form 
	{
        [ModuleStart]
        public void Start()
        {
            System.Windows.Forms.Form shell = (EAS.Windows.Application.Instance as EAS.Windows.Application).Shell;

            this.LoginID = this.LoginID == null || this.LoginID == string.Empty ? XContext.Account.LoginID : this.LoginID;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MdiParent = null;

            if (shell != null)
                this.ShowDialog(shell);
            else
                this.ShowDialog();
        }

	    private string loginid;
		private bool canclose;

		public PasswordBox()
		{
			InitializeComponent();
			this.loginid = string.Empty;
			this.canclose = true;
			this.tbPassword.Focus();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = !this.canclose;
			this.canclose = true;
			base.OnClosing (e);
		}

		/// <summary>
		/// ��ȡ��������Ҫ����������ʻ��ĵ�¼ID��
		/// </summary>
		internal string LoginID
		{
			get
			{
				return this.loginid;
			}
			set
			{
				this.loginid = value;
			}
		} 	 

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.canclose = true;
			if(this.tbPassword.Text != this.tbCPassword.Text)
			{
				MessageBox.Show(this, "��������������벻һ�£�������ȷ�����롣", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.tbPassword.Focus();
				this.canclose = false;
				return;
			}

			if(this.tbPassword.Text == string.Empty)
			{
				if(MessageBox.Show(this, "��Ҫ����������Ϊ�����룬������ʹ���Ĺ��������ݺ����ױ���ȡ��\nϵͳǿ�ҽ�������Ҫ����������Ϊ�����룬�Ƿ�Ҫ�趨����Ϊ�����룿", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
				{
					this.tbPassword.Focus();
					this.canclose = false;
					return;
				}
			}

			Cursor c = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;

                IAccountService service = ServiceContainer.GetService<IAccountService>();
                service.UpdatePassword(this.loginid, this.tbPassword.Text);
				MessageBox.Show(this, "���Ѿ��ɹ����޸��ˡ�" + this.loginid + "���ĵ�¼���룬���μ����ո����õ����룡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show(this, "�������ù����г�����һ�����󣬿��������ݿ�������쳣����֪ͨϵͳ����Ա���������������������������⣡", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.canclose = false;
				return;
			}
			finally
			{
				this.Cursor = c;
			}
		}
	}
}
