using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class DefinitionLineageRepo : IDefinitionLineageRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public DefinitionLineageRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<DefinitionLineage> GetDefinitionLineage()
        {
            return await _context.Set<DefinitionLineage>().FromSql("GetDefinitionLineage").FirstOrDefaultAsync();
        }

        public async Task<bool> Add(DefinitionLineage definition)
        {
            object[] parameters = { definition.TreeDefinition };
            var StoredName = "AddDefinitionLineage {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> Update(DefinitionLineage definition)
        {
            object[] parameters = { definition.Id, definition.TreeDefinition };
            var StoredName = "UpdateDefinitionLineage {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
