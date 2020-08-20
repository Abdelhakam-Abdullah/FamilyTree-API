using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class FamilyCharactersRepo : IFamilyCharactersRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public FamilyCharactersRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FamilyCharactersDTO>> GetFamilyCharacters(int pageNo)
        {
            object[] parameters = { pageNo };
            var StoredName = "GetFamilyCharacters {0}";
            return await _context.Set<FamilyCharactersDTO>().FromSql(StoredName,parameters).ToListAsync();
        }

        public async Task<bool> Add(FamilyCharAddDTO FamilyChar)
        {
            object[] parameters ={
                    FamilyChar.CharId,
                    FamilyChar.Title,
                    FamilyChar.Description,
                    FamilyChar.UserId,
                    FamilyChar.CreatedDateM,
                    FamilyChar.CreatedDateH,
                    FamilyChar.IsAccepted
            };
            var StoredName = "AddFamilyCharacter {0},{1},{2},{3},{4},{5},{6}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<FamilyCharactersSearchDTO>> FilterFamilyCharacters(string sreachKey)
        {
            object[] parameters = { sreachKey };
            var StoredName = "FilterFamilyCharacters {0}";
            return await _context.Set<FamilyCharactersSearchDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<FamilyCharacterDetailsDTO> GetFamilyCharacterDetails(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetFamilyCharacterDetails {0}";
            return await _context.Set<FamilyCharacterDetailsDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharacters_4Admin(int pageNo)
        {
            object[] parameters = { pageNo };
            var StoredName = "GetFamilyCharacters_4Admin {0}";
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public int GeFCCount_All()
        {
            var blods = _context.FamilyCharacters.Where(fc => fc.IsDelete == false);
            return blods.Count();
        }

        public async Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharByStatus(bool status, int pageNo)
        {
            object[] parameters = { status , pageNo };
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql("GetFamilyCharByStatus {0},{1}", parameters).ToListAsync();
        }

        public async Task<IEnumerable<FamilyCharactersAdminDTO>> FilterFamilyCharacters_4Admin(string sreachKey)
        {
            object[] parameters = { sreachKey };
            var StoredName = "FilterFamilyCharacters_4Admin {0}";
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public async Task<bool> DeleteFamilyChar(int blogId)
        {
            object[] parameters = { blogId };
            var StoredName = "DeleteFamilyChar {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> SetAcceptStatus(int Id, bool status)
        {
            object[] parameters = { Id, status };
            var StoredName = "SetFamilyCharStatus {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<FamilyCharactersAdminDTO> GetFamilyCharactersById_4Admin(int id)
        {
            object[] parameters = { id };
            var StoredName = "GetFamilyCharactersById_4Admin {0}";
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql(StoredName, parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFamilyChar(FamilyCharUpdateDTO familyChar)
        {
            object[] parameters =
                {
                    familyChar.Id,
                    familyChar.Title,
                    familyChar.Description
                };
            var StoredName = "UpdateFamilyChar {0},{1},{2}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharWattings(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql("GetFamilyCharWattings {0}", parameters).ToListAsync();
        }

        public int GetFamilyCharWattings_Count()
        {
            var fChar = _context.FamilyCharacters.Where(fc => fc.IsDelete == false && fc.IsAccepted == null);
            return fChar.Count();
        }

        public int GetFamilyByStatus_Count(bool status)
        {
            var fChar = _context.FamilyCharacters.Where(fc => fc.IsDelete == false && fc.IsAccepted == status);
            return fChar.Count();
        }

        public async Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharWatting(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<FamilyCharactersAdminDTO>().FromSql("GetFamilyCharWatting {}",parameters).ToListAsync();
        }

        public async Task<bool> UpdateFamilyCharStatus(int fcId, bool status)
        {
            object[] parameters =
                {
                    fcId,
                    status
                };
            var StoredName = "UpdateFamilyCharStatus {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

    }
}
