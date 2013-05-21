using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            string uploadPath = HttpContext.Current.Server.MapPath("~/pic/");
            if (!System.IO.Directory.Exists(uploadPath))
            {
                System.IO.Directory.CreateDirectory(uploadPath);
            }


            System.IO.Stream stream = context.Request.InputStream;//这是你获得的流 

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);     //将流的内容读到缓冲区 

            System.IO.FileStream fs = new System.IO.FileStream(uploadPath + "test.jpg", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }   
    }
}