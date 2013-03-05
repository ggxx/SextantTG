using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //这里是Factory设计模式
            IBlogDAL blogDal = IDAL.DALFactory.CreateDAL<IBlogDAL>();
            if (blogDal != null)
            {
                System.Console.WriteLine(blogDal.GetType().ToString());
            }
            else
            {
                System.Console.WriteLine("null");
            }













            System.Console.Read();

        }
    }
}
