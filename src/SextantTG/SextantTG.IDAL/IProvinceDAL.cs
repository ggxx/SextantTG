using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IProvinceDAL : IBaseDAL
    {
        List<Province> GetProvinces();

        int InsertProvince(Province province, DbTransaction trans);
        int UpdateProvince(Province province, DbTransaction trans);
        int DeleteProvinceByProvinceId(string provinceId, DbTransaction trans);
    }
}
