using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class TermsRepo : ITermsRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public TermsRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<Terms> Get()
        {
            return await _context.Set<Terms>().FromSql("GetTerms").FirstOrDefaultAsync();
        }

        public async Task<bool> Add(Terms terms)
        {
            object[] parameters = { terms.Termss };
            var StoredName = "AddTerms {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> Update(Terms terms)
        {
            object[] parameters = { terms.Id, terms.Termss };
            var StoredName = "UpdateTerms {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }
    }
}
