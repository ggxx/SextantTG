using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SextantTG.Win
{
    internal class FileUtil
    {

        internal static void SaveFile(string fileFullPath, bool askForOpen)
        {
            FileInfo file = new FileInfo(fileFullPath);
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = string.Format("文件(*{0})|*{1}", file.Extension.ToUpper(), file.Extension);
                dialog.DefaultExt = file.Extension;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(file.FullName, dialog.FileName);
                    if (askForOpen)
                    {
                        try
                        {
                            if (MessageBox.Show("文件保存完毕，是否打开", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                ViewPicture(file.FullName);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("导出失败", "导出Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        internal static bool ViewPicture(string fileFullPath)
        {
            System.Diagnostics.Process pc = new System.Diagnostics.Process();
            pc.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            pc.StartInfo.FileName = "explorer.exe";
            pc.StartInfo.Arguments = "\"" + fileFullPath + "\"";//加上双引号，防止路径中的空格
            try
            {
                pc.Start();
                return true;
            }
            catch
            {
                pc.Dispose();
                return false;
            }
        }
    }
}
