using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IBlogCommentRepo
    {
        Task<IEnumerable<BlodCommentsDTO>> GetAllCommentsByBlog(int blogId, int pageNo = 1);
        Task<bool> DeleteComment(int commentId);
        Task<bool> AddComment(AddBlogCommentDTO blogComment);
        int GetCountBlogsComments_ByBlogId(int blogId);
    }
}
