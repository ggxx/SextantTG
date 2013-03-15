using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ITourDAL : IBaseDAL
    {
        List<Tour> GetToursByUserId(string userId);
        Tour GetTourByTourId(string tourId);
        List<Tour> GetToursBySightsId(string sightsId);
        List<Tour> GetToursByDate(DateTime date);
        List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date);

        int InsertTour(Tour tour, DbTransaction trans);
        int UpdateTour(Tour tour, DbTransaction trans);
        int DeleteTourByTourId(string tourId, DbTransaction trans);
    }
}
