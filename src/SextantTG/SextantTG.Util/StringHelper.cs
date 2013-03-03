using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Util
{
    public class StringHelper
    {
        /// <summary>
        /// 获得字符串的真实长度，一个汉字算2个字节
        /// </summary>
        /// <param name="s">要输入的字符串</param>
        /// <returns></returns>
        public static int GetStringLength(string s)
        {
            return System.Text.Encoding.Default.GetBytes(s).Length;
        }

        /// <summary>
        ///  合并字符串组
        /// </summary>
        /// <param name="array">要合并的字符串组</param>
        /// <param name="ind">间隔符</param>
        /// <param name="prefix">前缀</param>
        /// <param name="suffix">后缀</param>
        /// <returns>输出的字符串</returns>
        public static string JoinStrings(string[] array, string ind, string prefix, string suffix)
        {
            string val = "";
            int i;
            for (i = 0; i < array.Length - 1; i++)
            {
                val += prefix + array[i] + suffix + ind;
            }
            return val + prefix + array[i] + suffix;
        }

        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
