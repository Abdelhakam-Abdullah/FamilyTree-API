using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class FamilyRepo : IFamilyRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public FamilyRepo(FamilyTreeContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<FamilyDTO>> GetFamilies()
        {
            return await _context.Set<FamilyDTO>().FromSql("GetFamiles").ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
