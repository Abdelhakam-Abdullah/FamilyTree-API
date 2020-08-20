using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IHomeRepo
    {
        Task<IEnumerable<ImagesDTO>> GetUserImages(int pageNo);
        Task<IEnumerable<ImagesDTO>> GetNewsImages(int pageNo);
    }
}
