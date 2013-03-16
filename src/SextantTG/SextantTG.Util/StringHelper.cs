using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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
            string val = string.Empty;
            int i;
            for (i = 0; i < array.Length - 1; i++)
            {
                val += prefix + array[i] + suffix + ind;
            }
            return val + prefix + array[i] + suffix;
        }


        /// <summary>
        /// 生成一个32位的GUID字符串
        /// </summary>
        /// <returns></returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        /// <summary>
        /// 生成哈希
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            byte[] buffer = MD5.Create().ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("X2"));
            }
            return builder.ToString();
        }

        /// <summary>
        /// 验证哈希
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            string x = GetMd5Hash(input);
            return (StringComparer.OrdinalIgnoreCase.Compare(x, hash) == 0);
        }


        private static readonly string emailRegexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        private static readonly Regex emailRegex = new Regex(emailRegexString);

        public static bool IsEmail(string inputEmail)
        {
            if (!string.IsNullOrEmpty(inputEmail))
            {
                if (emailRegex.IsMatch(inputEmail))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
