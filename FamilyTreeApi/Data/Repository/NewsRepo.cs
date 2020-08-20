using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class NewsRepo : INewsRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public NewsRepo(FamilyTreeContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<NewsDTO>> GetLatestNews(string orderType, int pageNo)
        {
            object[] parameters = { orderType , pageNo };
            var StoredName = "GetLatestNews {0},{1}";
            return await _context.Set<NewsDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsDTO>> GetNewsByNewsType(int NewsTypeId, int pageNo)
        {
            object[] parameters = { NewsTypeId, "M", pageNo };
            var StoredName = "GetNewsByNewsType {0},{1},{2}";
            return await _context.Set<NewsDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<NewsDetailsDTO> GetNewsDetails(int NewsId)
        {
            object[] parameters = { NewsId };
            var StoredName = "GetNewsDetails {0}";
            return await _context.Set<NewsDetailsDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NewsImagesDTO>> GetNewsImages(int NewsId)
        {
            object[] parameters = { NewsId};
            var StoredName = "GetNewsImages {0}";
            return await _context.Set<NewsImagesDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsImagesEditDTO>> Get_NewsImages(int NewsId)
        {
            object[] parameters = { NewsId };
            var StoredName = "Get_NewsImages {0}";
            return await _context.Set<NewsImagesEditDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<NewsTypeDTO>> GetNewsType()
        {
            return await _context.Set<NewsTypeDTO>().FromSql("GetNewsType").ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<NewsListDTO>> GetAllNews_4admin(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<NewsListDTO>().FromSql("GetNews_4admin {0}", parameters).ToListAsync();
        }

        public int GetNewsCount_All()
        {
            var news = _context.News.Where(b => b.IsDelete == false);
            return news.Count();
        }

        public int GetNewsCommentsCount_Watting(int newsId)
        {
            var newsComWatting = _context.NewsComment.Where(nc => nc.IsDelete == false && nc.IsAccepted == null && nc.NewsId == newsId);
            return newsComWatting.Count();
        }

        public async Task<NewsDetailsAdminDTO> GeNewsById_4Admin(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetNewsById_4admin {0}";
            return await _context.Set<NewsDetailsAdminDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<NewsEditDTO> Get_NewsById(int id)
        {
            object[] parameters = { id };
            var StoredName = "Get_NewsById {0}";
            return await _context.Set<NewsEditDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NewsListDTO>> GetNewsByStatus(bool status,int pageNo)
        {
            object[] parameters = { status, pageNo };
            return await _context.Set<NewsListDTO>().FromSql("GetNewsByStatus {0},{1}", parameters).ToListAsync();
        }

        public async Task<bool> DeleteNews(int newsId)
        {
            object[] parameters = { newsId };
            var StoredName = "DeleteNews {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<NewsListDTO>> FilterNews(FiltersDTO filter)
        {
            object[] parameters =
                {
                    //filter.SearchBy.Trim(),
                    filter.SearckKey.Trim(),
                    filter.DateFrom,
                    filter.DateTo
                };
            return await _context.Set<NewsListDTO>().FromSql("FilterNews {0},{1},{2}", parameters).ToListAsync();
        }

        public async Task<bool> AddNews(AddNewsDTO news)
        {
            object[] parameters =
               {
                    news.Title,
                    news.Description,
                    news.NewsPlace,
                    news.CreatedDateM,
                    news.CreatedDateH,
                    news.NewsTypeId,
                    news.IsAccepted,
                    news.AllowComment,
                    news.UserId
            };
            var StoredName = "AddNews {0},{1},{2},{3},{4},{5},{6},{7},{8}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateNews(NewsOperDTO newdEdit)
        {
            object[] parameters =
                {
                    newdEdit.Id,
                    newdEdit.Title,
                    newdEdit.Description,
                    newdEdit.AllowComment,
                    newdEdit.NewsTypeId
            };
            var StoredName = "UpdateNews {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<NewsTypeDTO>> GetNewsTypes()
        {
            return await _context.Set<NewsTypeDTO>().FromSql("GetNewsTypes").ToListAsync();
        }

        public async Task<ReturnDTO> AddNews(NewsOperDTO news)
        {
            object[] parameters =
                {
                    news.Title,
                    news.NewsTypeId,
                    news.Description,
                    news.CreatedDateM,
                    news.CreatedDateH,
                    news.AllowComment,
                    news.UserId,
                    news.IsAccepted
            };
            var StoredName = "AddNews {0},{1},{2},{3},{4},{5},{6},{7}";
            return await _context.Set<ReturnDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> SetAcceptStatus(bool status, int newsId)
        {
            object[] parameters = { newsId, status };
            var StoredName = "SetNewsStatus {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<NewsAddedDTO> GetNewsById(int newsId)
        {
            object[] parameters = { newsId };
            var StoredName = "GetNewsById {0}";
            return await _context.Set<NewsAddedDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> SetNewsWatting(int newsId)
        {
            object[] parameters = { newsId };
            var StoredName = "SetNewsWatting {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> DeleteImage(int id)
        {
            object[] parameters = {id};
            var StoredName = "DeleteImage {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateImags(NewsImageDTO newsImage)
        {
            object[] parameters = { newsImage.NewsId };
            var StoredName = "UpdateImags {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> SetImageMain(int id)
        {
            object[] parameters = { id };
            var StoredName = "SetImageMain {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<NewsListDTO>> GetNewsWatting(int pageNo = 1)
        {
            object[] parameters = { pageNo };
            return await _context.Set<NewsListDTO>().FromSql("GetNewsWatting {0}",parameters).ToListAsync();
        }

        public int GetNewsCount_Watting()
        {
            var news = _context.News.Where(b => b.IsDelete == false && b.IsAccepted == null);
            return news.Count();
        }

        public int GetNewsCount_ByStatus(bool status)
        {
            var news = _context.News.Where(b => b.IsDelete == false && b.IsAccepted == status);
            return news.Count();
        }

        public async Task<IEnumerable<NewsCommentDTO>> GetNewsRefusalComments(int newsId, int pageNo)
        {
            object[] parameters = { newsId, pageNo };
            var StoredName = "GetNewsRefusalComments {0},{1}";
            return await _context.Set<NewsCommentDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public int GetNewsComments_Refuse_Count(int newsId)
        {
            var newsComNotAccepted = _context.NewsComment.Where(nc => nc.IsDelete == false && nc.IsAccepted == false && nc.NewsId == newsId);
            return newsComNotAccepted.Count();
        }

        //public async Task<IEnumerable<BlodCommentsDTO>> GetAllCommentsByNews(int newsId)
        //{
        //    object[] parameters = { newsId };
        //    var StoredName = "GetCommentsByBlogId {0}";
        //    return await _context.Set<BlodCommentsDTO>().FromSql(StoredName, parameters).ToListAsync();
        //}

    }
}
