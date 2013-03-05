using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISubTourDAL : IBaseDAL
    {
        List<SubTour> GetSubToursByTourId(string tourId);
        SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId);

        int InsertSubTour(SubTour subTour, DbTransaction trans);
        int UpdateSubTour(SubTour subTour, DbTransaction trans);
        int DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId);
    }
}
