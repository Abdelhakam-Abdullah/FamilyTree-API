using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface INewsRepo
    {
        Task<IEnumerable<NewsDTO>> GetLatestNews(string orderType, int pageNo);
        Task<IEnumerable<NewsDTO>> GetNewsByNewsType(int NewsTypeId, int pageNo);
        Task<NewsDetailsDTO> GetNewsDetails(int NewsId);
        Task<IEnumerable<NewsImagesDTO>> GetNewsImages(int NewsId);
        Task<bool> AddNews(AddNewsDTO news);
        Task<bool> DeleteNews(int newsId);
        Task<IEnumerable<NewsTypeDTO>> GetNewsType();
        Task<IEnumerable<NewsListDTO>> GetAllNews_4admin(int pageNo);
        int GetNewsCount_All();
        Task<NewsDetailsAdminDTO> GeNewsById_4Admin(int id);
        Task<IEnumerable<NewsListDTO>> GetNewsByStatus(bool status, int pageNo);
        Task<IEnumerable<NewsListDTO>> FilterNews(FiltersDTO filter);
        Task<IEnumerable<NewsTypeDTO>> GetNewsTypes();
        Task<ReturnDTO> AddNews(NewsOperDTO news);
        Task<bool> SetAcceptStatus(bool status, int newsId);
        Task<NewsEditDTO> Get_NewsById(int id);
        Task<IEnumerable<NewsImagesEditDTO>> Get_NewsImages(int NewsId);
        Task<bool> UpdateNews(NewsOperDTO newdEdit);
        Task<bool> DeleteImage(int id);
        Task<bool> SetImageMain(int id);
        Task<bool> UpdateImags(NewsImageDTO newsImage);
        int GetNewsCommentsCount_Watting(int newsId);
        Task<IEnumerable<NewsListDTO>> GetNewsWatting(int pageNo);
        int GetNewsCount_Watting();
        int GetNewsCount_ByStatus(bool status);
        Task<IEnumerable<NewsCommentDTO>> GetNewsRefusalComments(int newsId, int pageNo);
        int GetNewsComments_Refuse_Count(int newsId);
        Task<NewsAddedDTO> GetNewsById(int newsId);
        Task<bool> SetNewsWatting(int newsId);
    }
}
