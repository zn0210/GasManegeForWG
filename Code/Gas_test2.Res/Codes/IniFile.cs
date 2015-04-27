using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Gas_test2.Res
{
    /// <summary>
    /// Ini�ļ���д�ࡣ
    /// </summary>
    class IniFile
    {
        #region API

        class API
        {
            /// <summary>
            /// дIni�ļ���
            /// </summary>
            /// <param name="section"></param>
            /// <param name="key"></param>
            /// <param name="val"></param>
            /// <param name="filePath"></param>
            /// <returns></returns>
            [DllImport("kernel32")]
            public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

            /// <summary>
            /// ��Ini�ļ���
            /// </summary>
            /// <param name="section"></param>
            /// <param name="key"></param>
            /// <param name="def"></param>
            /// <param name="retVal"></param>
            /// <param name="size"></param>
            /// <param name="filePath"></param>
            /// <returns></returns>
            [DllImport("kernel32")]
            public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        }

        #endregion

        private string path = string.Empty;

        internal IniFile()
        {
        }

        internal IniFile(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// ·����
        /// </summary>
        internal string FilePath
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }

        /// <summary>
        /// д��Iniָ�����ý�ָ�����ü���ֵ��
        /// </summary>
        /// <param name="section">�ڡ�</param>
        /// <param name="key">����</param>
        /// <param name="value">ֵ��</param>
        internal void WriteValue(string section, string key, string value)
        {
            API.WritePrivateProfileString(section, key, value, this.path);
        }

        /// <summary>
        /// ��ȡIniָ�����ý�ָ�����ü���ֵ
        /// </summary>
        /// <param name="section">�ڡ�</param>
        /// <param name="key">����</param>
        /// <returns></returns>
        internal string ReadValue(string section, string key)
        {
            StringBuilder dataBuffer = new StringBuilder(1024 * 10);
            int i = API.GetPrivateProfileString(section, key, string.Empty, dataBuffer, 1024 * 10, this.path);
            return dataBuffer.ToString();
        }
    }
}
