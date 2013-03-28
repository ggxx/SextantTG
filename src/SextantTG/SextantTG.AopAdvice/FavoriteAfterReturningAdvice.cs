using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using SextantTG.ActiveRecord;
using SextantTG.Util;
using AopAlliance.Intercept;

namespace SextantTG.AopAdvice
{
    public class FavoriteAfterReturningAdvice : IAfterReturningAdvice
    {
        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            switch (method.Name)
            {
                case "InsertFavorite":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户新增了一个景点评分，" + (args[0] as Favorite).ToString());
                    break;
                case "UpdateFavorite":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户修改了一个景点评分，" + (args[0] as Favorite).ToString());
                    break;
                case "DeleteFavorite":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户删除了一个景点评分，" + (args[0] as Favorite).ToString());
                    break;
                default:
                    break;
            }


            //string message = "";
            //if (method.Name == "Login")
            //{
            //    message = GetOutTime() + "用户登录:";
            //    if (args != null)
            //    {
            //        string username = (string)args[0];
            //        message += "用户名称:" + username;
            //    }
            //    LogHelper.Info(message);
            //}
            //else if (method.Name == "SaveFavorite")
            //{
            //    message = GetOutTime();

            //    if (args != null)
            //    {
            //        Favorite fav = (Favorite)args[0];
            //        message += "用户：" + /*userDal.GetUserByUserId(fav.UserId).LoginName +*/ "更新了收藏信息：景点名称：" + /*sightsDal.GetSightBySightsId(fav.SightsId).SightsName +*/ "；是否已游览：" + fav.Visited + "；评分：" + fav.Stars;
            //        LogHelper.Info(message);
            //    }
            //}
        }
    }
}
