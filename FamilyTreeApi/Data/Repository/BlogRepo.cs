using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class BlogRepo : IBlogRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;

        public BlogRepo(FamilyTreeContext context)
        {
            _context = context;
        }
        
        //get all blogs for all users
        public async Task<IEnumerable<BlogMDTO>> GetAllBlogs(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<BlogMDTO>().FromSql("GetBlogs {0}", parameters).ToListAsync();
        }

        //get all blogs for currrent user
        public async Task<IEnumerable<BlogsUserDTO>> GetAllBlogsByUser(int userId, int pageNo)
        {
            object[] parameters = { userId, pageNo };
            var StoredName = "GetBlogsByUser {0},{1}";
            return await _context.Set<BlogsUserDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<BlogsDTO>> GetBlogsByStatus(string status, int pageNo = 1)
        {
            object[] parameters = { status, pageNo };
            return await _context.Set<BlogsDTO>().FromSql("GetBlogsByStatus {0},{1}", parameters).ToListAsync();
        }

        public async Task<MyBlogDTO> GetMyBlogById(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetMyBlogById {0}";
            return await _context.Set<MyBlogDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<BlogDetailsDTO> GetBlogById(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetBlogById {0}";
            return await _context.Set<BlogDetailsDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<BlogsDTO> GetBlogById_4Admin(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetBlogById_4Admin {0}";
            return await _context.Set<BlogsDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }
       
        public async Task<bool> AddBlog(AddBlogDTO blog)
        {
            object[] parameters =
                {
                    blog.Title,
                    blog.Description,
                    blog.CreatedDateM,
                    blog.CreatedDateH,
                    blog.AllowComment,
                    blog.UserId,
                    blog.IsAccepted
            };
            var StoredName = "AddBlog {0},{1},{2},{3},{4},{5},{6}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateBlog(AddBlogDTO blog)
        {
            object[] parameters =
                {
                    blog.Id,
                    blog.Title,
                    blog.Description,                   
                    blog.AllowComment,
                    blog.UserId
            };
            var StoredName = "UpdateBlog {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> DeleteBlog(int blogId)
        {
            object[] parameters = { blogId };
            var StoredName = "DeleteBlog {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int GetBlogsCount_All()
        {
            var blods = _context.Blog.Where(b => b.IsDelete == false);
            return blods.Count();
        }

        public int GetBlogsCount_byStatus(string status)
        {
            if (status == "1")
            {
                var blods = _context.Blog.Where(b => b.IsDelete == false && b.IsAccepted == true);
                return blods.Count();
            }
            else if(status == "0")
            {
                var blods = _context.Blog.Where(b => b.IsDelete == false && b.IsAccepted == false);
                return blods.Count();
            }
            else
            {
                var blods = _context.Blog.Where(b => b.IsDelete == false && b.IsAccepted == null);
                return blods.Count();
            } 
        }

        public async Task<IEnumerable<BlogsDTO>> FilterBlogs(FiltersDTO filter)
        {
            object[] parameters = 
                {
                    //filter.SearchBy.Trim(),
                    filter.SearckKey.Trim(),
                    filter.DateFrom,
                    filter.DateTo
                };
            return await _context.Set<BlogsDTO>().FromSql("FilterBlogs {0},{1},{2}", parameters).ToListAsync();
        }

        public async Task<bool> SetAcceptStatus(bool status, int blogId)
        {
            object[] parameters = {blogId, status};
            var StoredName = "SetBlogStatus {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> SetBlogWatting(int blogId)
        {
            object[] parameters = { blogId };
            var StoredName = "SetBlogWatting {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<BlogsDTO>> GetAllBlogs_4admin(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<BlogsDTO>().FromSql("GetBlogs_4admin {0}", parameters).ToListAsync();
        }       

        public int GetBlogComments_Watting_Count(int blogId)
        {
            var blogComNotAccepted = _context.BlogComment.Where(nc => nc.IsDelete == false && nc.IsAccepted == null && nc.BlogId == blogId);
            return blogComNotAccepted.Count();
        }

        public int GetBlogComments_Refuse_Count(int blogId)
        {
            var blogComNotAccepted = _context.BlogComment.Where(nc => nc.IsDelete == false && nc.IsAccepted == false && nc.BlogId == blogId);
            return blogComNotAccepted.Count();
        }

        public async Task<bool> AcceptUserBlogComment(int blogId, int commentId, bool status)
        {
            object[] parameters = { blogId, commentId, status };
            var StoredName = "AcceptUserBlogComment {0},{1},{2}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetBlogCommentsWatting(int newsId, int pageNo)
        {
            object[] parameters = { newsId, pageNo };
            var StoredName = "GetBlogCommentsWatting {0},{1}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetBlogRefusalComments(int newsId, int pageNo)
        {
            object[] parameters = { newsId, pageNo };
            var StoredName = "GetBlogRefusalComments {0},{1}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }


        //public Task<UtilitiesDTO> GetBlogsCount()
        //{
        //    return await _context.Set<UtilitiesDTO>().FromSql("GetBlogs_Count").FirstOrDefaultAsync();
        //}
    }
}
