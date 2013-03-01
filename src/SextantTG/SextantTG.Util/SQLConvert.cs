using System;
using System.Collections.Generic;
using System.Text;

namespace SextantTG.Util
{
    public class SQLConvert
    {
        /// <summary>
        /// SQL语句转换。
        /// 将"WHERE ID=:id"的参数表示方式转换为"WHERE ID=?"的表示方式
        /// </summary>
        /// <param name="sql">要转换的SQL语句</param>
        /// <returns>转换后的SQL语句</returns>
        public static string ConvertSQL1(string sql)
        {
            string result = "";

            string[] arr = sql.Split(new char[] { '\'' }, StringSplitOptions.None);

            for (int i = 0; i < arr.Length; i = i + 2)
            {
                int head = arr[i].IndexOf(':');
                while (head >= 0)
                {
                    int end = arr[i].Length;
                    int end1 = arr[i].IndexOf(',', head);
                    int end2 = arr[i].IndexOf(' ', head);
                    int end3 = arr[i].IndexOf('\r', head);
                    int end4 = arr[i].IndexOf('\t', head);
                    int end5 = arr[i].IndexOf('\n', head);

                    if (end1 >= 0)
                        end = Math.Min(end, end1);
                    if (end2 >= 0)
                        end = Math.Min(end, end2);
                    if (end3 >= 0)
                        end = Math.Min(end, end3);
                    if (end4 >= 0)
                        end = Math.Min(end, end4);
                    if (end5 >= 0)
                        end = Math.Min(end, end5);

                    arr[i] = arr[i].Remove(head, end - head).Insert(head, "?");

                    head = arr[i].IndexOf(':');
                    //System.Text.RegularExpressions.Regex.Replace(arr[i], @":\S+[ |,|$]", "? ");
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i] + '\'';
            }

            if (result.EndsWith("'"))
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        /// <summary>
        /// SQL语句转换。
        /// 将"WHERE ID=:id"的参数表示方式转换为"WHERE ID=@id"的表示方式
        /// </summary>
        /// <param name="sql">要转换的SQL语句</param>
        /// <returns>转换后的SQL语句</returns>
        public static string ConvertSQL2(string sql)
        {
            string result = "";

            string[] arr = sql.Split(new char[] { '\'' }, StringSplitOptions.None);

            for (int i = 0; i < arr.Length; i = i + 2)
            {
                arr[i] = arr[i].Replace(':', '@');
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i] + '\'';
            }

            if (result.EndsWith("'"))
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        /// <summary>
        /// SQL语句转换。
        /// 将"WHERE ID=@id"的参数表示方式转换为"WHERE ID=:id"的表示方式
        /// </summary>
        /// <param name="sql">要转换的SQL语句</param>
        /// <returns>转换后的SQL语句</returns>
        public static string ConvertSQL3(string sql)
        {
            string result = "";

            string[] arr = sql.Split(new char[] { '\'' }, StringSplitOptions.None);

            for (int i = 0; i < arr.Length; i = i + 2)
            {
                arr[i] = arr[i].Replace('@', ':');
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i] + '\'';
            }

            if (result.EndsWith("'"))
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
    }
}