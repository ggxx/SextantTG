using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public sealed class DALFactory
    {
        private static readonly string DAL = "SextantTG.SQLiteDAL"; 
        private static readonly string BLOG = "SextantTG.SQLiteDAL.BlogDAL";

        //private string dal = System.Configuration.ConfigurationManager.AppSettings["SQLITEDAL"];
        //private string blog =  System.Configuration.ConfigurationManager.AppSettings["BLOGDAL"];

        public static IBlogDAL CreateBlogDAL()
        {
            return (IBlogDAL)System.Reflection.Assembly.Load(DAL).CreateInstance(BLOG);
        }


    }
}
