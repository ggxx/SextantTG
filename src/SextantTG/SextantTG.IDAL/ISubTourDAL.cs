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
        List<SubTour> GetSubToursByUserId(string userId);
        List<SubTour> GetSubToursBySightsId(string sightsId);

        int InsertSubTour(SubTour subTour, DbTransaction trans);
        //int UpdateSubTour(SubTour subTour, DbTransaction trans);
        int UpdateSubTourFromOld(SubTour newItem, SubTour oldItem, DbTransaction trans);
        //int DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId, DbTransaction trans);
        int DeleteSubTour(SubTour subTour, DbTransaction trans);
        //int DeleteSubTourByTourId(string tourId, DbTransaction trans);




    }
}
