using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface INewsCommentRepo
    {
        Task<IEnumerable<NewsCommentDTO>> GetComments(int newsId);
        Task<IEnumerable<NewsCommentDTO>> GetComments(int newsId, int pageNo);
        Task<bool> AddNewsComment(AddNewsCommentDTO comment);
        Task<bool> DeleteComment(int commentId);
        int GetCommentsCountByNewsId(int newsId);
        Task<bool> AddComment(AddNewsCommentDTO newsComment);
        Task<IEnumerable<NewsCommentDTO>> GetNewsCommentsWatting(int newsId, int pageNo);
        Task<bool> AcceptUserComment(int newsId, int commentId);
        int GetAllComments_ByNews(int newsId);
        Task<bool> RefuseUserComment(int newsId, int commentId);
    }
}
