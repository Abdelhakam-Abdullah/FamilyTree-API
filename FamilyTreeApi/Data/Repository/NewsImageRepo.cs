using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class NewsImageRepo: INewsImageRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;

        public NewsImageRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewsImage(NewsImageDTO newsImage)
        {
            object[] parameters =
            {
                newsImage.ImagePath,
                newsImage.IsMain,
                newsImage.CreatedDateM,
                newsImage.CreatedDateH,
                newsImage.NewsId
            };
            var StoredName = "AddNewsImage {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
