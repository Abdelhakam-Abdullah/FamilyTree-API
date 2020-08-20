using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class NewsCommentRepo : INewsCommentRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;

        public NewsCommentRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetComments(int newsId, int pageNo)
        {
            object[] parameters = { newsId, pageNo };
            var StoredName = "GetCommentsByNewsId {0},{1}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetNewsCommentsWatting(int newsId, int pageNo)
        {
            object[] parameters = { newsId, pageNo };
            var StoredName = "GetNewsCommentsWatting {0},{1}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetComments(int newsId)
        {
            object[] parameters = { newsId };
            var StoredName = "GetCommentsByNewsId {0}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<bool> AddNewsComment(AddNewsCommentDTO newsComment)
        {
            object[] parameters = {
                    newsComment.Comment,
                    newsComment.CreatedDateM,
                    newsComment.CreatedDateH,
                    newsComment.NewsId,
                    newsComment.UserId,
                    newsComment.IsAccepted
            }; 
            var StoredName = "AddNewsComment {0},{1},{2},{3},{4},{5}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            object[] parameters = { "NewsComment", commentId };
            var StoredName = "DeleteComment {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public int GetCommentsCountByNewsId(int newsId)
        {
            var newsC = _context.NewsComment.Where(b => b.IsDelete == false && b.NewsId == newsId && b.IsAccepted == true);
            return newsC.Count();
        }

        public async Task<bool> AddComment(AddNewsCommentDTO newsComment)
        {
            object[] parameters ={
                    newsComment.Comment,
                    newsComment.CreatedDateM,
                    newsComment.CreatedDateH,
                    newsComment.NewsId,
                    newsComment.UserId,
                    newsComment.IsAccepted
            };
            var StoredName = "AddNewsComment {0},{1},{2},{3},{4},{5}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AcceptUserComment(int newsId, int commentId)
        {
            object[] parameters = { newsId , commentId };
            var StoredName = "AcceptUserComment {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> RefuseUserComment(int newsId, int commentId)
        {
            object[] parameters = { newsId, commentId };
            var StoredName = "refuseUserComment {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int GetAllComments_ByNews(int newsId)
        {
            var NewsComment = _context.NewsComment.Where(b => b.IsDelete == false && b.NewsId == newsId);
            return NewsComment.Count();
        }
    }
}
