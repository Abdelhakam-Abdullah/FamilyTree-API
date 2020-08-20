using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IBlogRepo
    {
        Task<IEnumerable<BlogMDTO>> GetAllBlogs(int pageNo);
        Task<IEnumerable<BlogsDTO>> GetAllBlogs_4admin(int pageNo);
        Task<IEnumerable<BlogsDTO>> GetBlogsByStatus(string status, int pageNo);
        //Task<UtilitiesDTO> GetBlogsCount();
        int GetBlogsCount_All();
        int GetBlogsCount_byStatus(string status);
        Task<IEnumerable<BlogsUserDTO>> GetAllBlogsByUser(int userId, int pageNo);

        Task<MyBlogDTO> GetMyBlogById(int id);
        Task<BlogDetailsDTO> GetBlogById(int id);

        Task<bool> DeleteBlog(int blogId);
        Task<bool> AddBlog(AddBlogDTO blog);
        Task<bool> UpdateBlog(AddBlogDTO blog);
        Task<BlogsDTO> GetBlogById_4Admin(int id);
        Task<IEnumerable<BlogsDTO>> FilterBlogs(FiltersDTO filter);
        Task<bool> SetAcceptStatus(bool status, int blogId);
        Task<IEnumerable<NewsCommentDTO>> GetBlogCommentsWatting(int newsId, int pageNo);
        int GetBlogComments_Watting_Count(int blogId);
        Task<bool> AcceptUserBlogComment(int blogId, int commentId, bool status);
        Task<IEnumerable<NewsCommentDTO>> GetBlogRefusalComments(int newsId, int pageNo);
        int GetBlogComments_Refuse_Count(int blogId);
        Task<bool> SetBlogWatting(int blogId);
    }
}
