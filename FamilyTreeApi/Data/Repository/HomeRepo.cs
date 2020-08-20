using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class HomeRepo : IHomeRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public HomeRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImagesDTO>> GetUserImages(int pageNo)
        {
            object[] parameters = { pageNo };
            var StoredName = "GetUserImages {0}";
            return await _context.Set<ImagesDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<IEnumerable<ImagesDTO>> GetNewsImages(int pageNo)
        {
            object[] parameters = { pageNo };
            var StoredName = "GetNews_Images {0}";
            return await _context.Set<ImagesDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

      

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
