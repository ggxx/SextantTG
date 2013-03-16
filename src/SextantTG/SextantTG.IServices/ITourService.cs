using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface ITourService : IBaseService
    {
        List<Tour> GetToursByUserId(string userId);
        Tour GetTourByTourId(string tourId);
        List<Tour> GetToursBySightsId(string sightsId);
        List<Tour> GetToursByDate(DateTime date);
        List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date);
        
        bool InsertTour(Tour tour, out string message);
        bool UpdateTour(Tour tour, out string message);
        bool DeleteTourByTourId(string tourId, bool deletePictures, out string message);
        bool SaveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours, out string msg);

        List<SubTour> GetSubToursByTourId(string tourId);
        SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId);
        List<SubTour> GetSubToursByUserId(string userId);
        List<SubTour> GetSubToursBySightsId(string sightsId);

        List<Picture> GetPicturesByTourId(string tourId);
        List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId);

        bool InsertSubTour(SubTour subTour, out string message);
        bool UpdateSubTour(SubTour subTour, out string message);
        bool DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId, out string message);




    }
}
