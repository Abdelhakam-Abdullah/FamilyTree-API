using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // Get all (list)
        public async Task<IEnumerable<TEntity>> GetAll(string StoredName)
        {
            return await _context.Set<TEntity>().FromSql(StoredName).ToListAsync();
        }

        // Get all by param (list)
        public async Task<IEnumerable<TEntity>> GetAllByParam(string StoredName, object[] parameters)
        {
            return await _context.Set<TEntity>().FromSql(StoredName, parameters).ToListAsync();
        }

        // Get by param (object)
        public async Task<TEntity> GetByParam(string StoredName, object[] parameters)
        {
            return await _context.Set<TEntity>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        // Execute insert / update / delete
        public async Task<int> ExecuteCommand(string StoredName)
        {
            return await _context.Database.ExecuteSqlCommandAsync(StoredName);
        }

        // Execute insert / update / delete (by param)
        public async Task<int> ExecuteCommandWithParam(string StoredName, object[] parameters)
        {
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters);
        }
    }
}
