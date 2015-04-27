using System;
using System.Collections.Generic;
using System.Text;
using EAS.Explorer;

namespace Gas_test2.Res
{
    class XContext 
    {
        /// <summary>
        /// ��ǰ��¼�˺š�
        /// </summary>
        public static IAccount Account
        {
            get
            {
                return EAS.Application.Instance.Session.Client as IAccount;
            }
        }

        /// <summary>
        /// ����ģ�顣
        /// </summary>
        public static IList<EAS.Explorer.Entities.Module> ModuleList
        {
            get
            {
                return EAS.Data.Caching.Cache.Get<EAS.Explorer.Entities.Module>();
            }
        }

        /// <summary>
        /// ��Դ��
        /// </summary>
        internal static IResource ShellResource
        {
            get
            {
                return EAS.Explorer.ResourceManager.Resource;
            }
        }

        /// <summary>
        /// ����ر���ʼҳ��
        /// </summary>
        public static bool AllowClose
        {
            get;
            set;
        }
    }
}
