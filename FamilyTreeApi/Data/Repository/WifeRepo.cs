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
    public class WifeRepo : IWifeRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public WifeRepo(FamilyTreeContext context) { _context = context; }

        public async Task<IEnumerable<WifeDTO>> GetWifesByUser(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "GetWifes {0}";
            return await _context.Set<WifeDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<bool> AddWife(Wife wife)
        {
            object[] parameters =
              {
                    wife.WName,
                    wife.Age,
                    wife.Address,
                    wife.UserId
            };
            var StoredName = "AddWife {0},{1},{2},{3}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateWife(Wife wife)
        {
            object[] parameters =
              {
                    wife.Id,
                    wife.WName,
                    wife.Age,
                    wife.Address,
                    wife.UserId
            };
            var StoredName = "UpdateWife {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> DeleteWife(int Id)
        {
            object[] parameters = { Id };
            var StoredName = "DeleteWife {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
