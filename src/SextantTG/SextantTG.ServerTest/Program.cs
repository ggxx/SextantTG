﻿using SextantTG.ActiveRecord;
using SextantTG.IDAL;
using SextantTG.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.STGNLog;
using SextantTG.DbUtil;

namespace SextantTG.ServerTest
{
    class Program
    {
        private static readonly IDictService dictSrv = ServiceFactory.CreateService<IDictService>();

        static void Main(string[] args)
        {

            //测试Factory模式
            //IBlogDAL blogDal = IDAL.DALFactory.CreateDAL<IBlogDAL>();
            //if (blogDal != null)
            //{
            //    System.Console.WriteLine(blogDal.GetType().ToString());
            //}
            //else
            //{
            //    System.Console.WriteLine("null");
            //}

            //List<City> allCity = dictSrv.GetCities();

            //System.Console.WriteLine("dictSrv.GetCities().count=" + dictSrv.GetCities().Count);
            //System.Console.WriteLine("all_city.count=" + allCity.Count);

            //List<City> list = dictSrv.GetCitiesByCountryId("001");

            //System.Console.WriteLine("GetCitiesByCountryId");
            //System.Console.WriteLine("china_city.count=" + list.Count);


            //City c = new City();
            //c.CityId = "nnnn";
            //c.CityName  = "vvvv";
            //list.Insert(0, c);

            //System.Console.WriteLine("Insert");

            //System.Console.WriteLine("dictSrv.GetCities().count=" + dictSrv.GetCities().Count);
            //System.Console.WriteLine("all_city.count=" + allCity.Count);
            //System.Console.WriteLine("china_city.count=" + list.Count);
            DbHelper db = new DbHelper("Data Source=db/sgt.db3;Version=3;", DbProviderType.SQLite);
            db.ExecuteDataTable("select * from stg_user");

        }
    }
}
