using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    /// <summary>
    /// 评论业务操作的接口
    /// </summary>
    public interface ICommentService : IBaseService
    {
        /// <summary>
        /// 获取指定图片的评论
        /// </summary>
        /// <param name="pictureId">图片ID</param>
        /// <returns>图片评论列表</returns>
        List<PictureComment> GetPictureCommentsByPictureId(string pictureId);

        /// <summary>
        /// 获取指定景点的评论
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>景点评论列表</returns>
        List<SightsComment> GetSightsCommentsBySightsId(string sightsId);

        /// <summary>
        /// 获取指定旅行的评论
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>旅行评论列表</returns>
        List<TourComment> GetTourCommentsByTourId(string tourId);

        /// <summary>
        /// 获取关于指定用户的评论
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户评论列表</returns>
        List<UserComment> GetUserCommentsByUserId(string userId);

        /// <summary>
        /// 新增一条图片评论
        /// </summary>
        /// <param name="comment">图片评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertPictureComment(PictureComment comment, out string message);

        /// <summary>
        /// 更新一条图片评论
        /// </summary>
        /// <param name="comment">图片评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdatePictureComment(PictureComment comment, out string message);

        /// <summary>
        /// 删除一条图片评论
        /// </summary>
        /// <param name="comment">图片评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeletePictureComment(PictureComment comment, out string message);

        /// <summary>
        /// 新增一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertSightsComment(SightsComment comment, out string message);

        /// <summary>
        /// 更新一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateSightsComment(SightsComment comment, out string message);

        /// <summary>
        /// 删除一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteSightsComment(SightsComment comment, out string message);

        /// <summary>
        /// 新增一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertTourComment(TourComment comment, out string message);

        /// <summary>
        /// 更新一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateTourComment(TourComment comment, out string message);

        /// <summary>
        /// 删除一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteTourComment(TourComment comment, out string message);

        /// <summary>
        /// 新增一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertUserComment(UserComment comment, out string message);

        /// <summary>
        /// 更新一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateUserComment(UserComment comment, out string message);

        /// <summary>
        /// 删除一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteUserComment(UserComment comment, out string message);
    }
}
