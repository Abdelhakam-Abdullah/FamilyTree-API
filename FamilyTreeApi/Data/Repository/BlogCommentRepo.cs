using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class BlogCommentRepo : IBlogCommentRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;

        public BlogCommentRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlodCommentsDTO>> GetAllCommentsByBlog(int blogId, int pageNo)
        {
            object[] parameters = { blogId, pageNo };
            var StoredName = "GetCommentsByBlogId {0},{1}";
            return await _context.Set<BlodCommentsDTO>().FromSql(StoredName, parameters).ToListAsync();
        }


        public int GetCountBlogsComments_ByBlogId(int blogId)
        {
            var blodsCom = _context.BlogComment.Where(bc => bc.IsDelete == false && bc.BlogId == blogId && bc.IsAccepted == true);
            return blodsCom.Count();
        }

        public async Task<bool> AddComment(AddBlogCommentDTO blogComment)
        {
            object[] parameters ={
                    blogComment.Comment,
                    blogComment.CreatedDateM,
                    blogComment.CreatedDateH,
                    blogComment.BlogId,
                    blogComment.UserId,
                    blogComment.IsAccepted
            };
            var StoredName = "AddBlogComment {0},{1},{2},{3},{4},{5}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            object[] parameters = { "BlogComment", commentId };
            var StoredName = "DeleteComment {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
