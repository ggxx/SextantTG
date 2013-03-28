using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ICityDAL : IBaseDAL
    {
        List<City> GetCities();

        int InsertCity(City city, DbTransaction trans);
        int UpdateCity(City city, DbTransaction trans);
        int DeleteCity(City city, DbTransaction trans);
    }
}
