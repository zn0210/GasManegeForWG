using System;
using EAS.Explorer;

namespace Gas_test2.Res
{
	public class Resources:EAS.Explorer.IResource  
	{
        /// <summary>
        /// ������ͼ�ꡣ
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Icon GetMainIcon()
        {
            return Properties.Resources.Drugbasket;
        }

        /// <summary>
        /// Tabҳͼ��
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Image GetModuleIcon()
        {
            return Properties.Resources.Module.ToBitmap();
        }

        /// <summary>
        /// ���汳����
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Image GetDesktopImage()
        {
            return null;
        }

        /// <summary>
        /// Ӧ�ó������ơ�
        /// </summary>
        /// <returns></returns>
        public string GetApplicationName()
        {
            return "GasManagement.NET";
        }

        /// <summary>
        /// Ӧ�ó�����⡣
        /// </summary>
        /// <returns></returns>
        public string GetApplicationTitle()
        {
            return "��ԴԤ�����ϵͳ";
        }

        public object GetMainShell()
        {
            return new RibbonShell(); //Ribbon����Զ�����档
            //return new DockableShell(); //Dockable����Զ�����档
            //return new TabShell(); //TabMdi����Զ�����档
            //return null; //ʹ��AgileEAS.NET SOAƽ̨�Դ����档
        }

        /// <summary>
        /// ���ڴ��ڡ�
        /// </summary>
        /// <returns></returns>
        public object GetAboutForm()
        {
            return new AboutForm();
        }

        /// <summary>
        /// Bottom֪ͨ��
        /// </summary>
        /// <returns></returns>
        public object GetBottomControl()
        {
            return new BottomControl();
        }

        /// <summary>
        /// Top������
        /// </summary>
        /// <returns></returns>
        public object GetBannerControl()
        {
            return new Banner();
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        public object GetNavigationControl()
        {
            return new NavigationControl();
        }

        /// <summary>
        /// ��¼���ڡ�
        /// </summary>
        /// <returns></returns>
        public ILoginForm GetLoginForm()
        {
            return new LoginForm();
        }

        /// <summary>
        /// ��ʼҳ��
        /// </summary>
        /// <returns></returns>
        public object GetStartModule()
        {
            return new StartWF();
        }

        /// <summary>
        /// ��ʾ�˵���
        /// </summary>
        public bool DisplayMainMenu
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// ��ʾ������
        /// </summary>
        public bool DisplayNavigation
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// ��ʾ������������
        /// </summary>
        public bool DisplayNavigationTool
        {
            get
            {
                return true;
            }
        }

        #region IResource ��Ա


        public IAccountOriginal GetAccountOriginal()
        {
            return null;
        }

        #endregion
    }
}