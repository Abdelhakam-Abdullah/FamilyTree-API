using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IFamilyCharactersRepo
    {
        Task<IEnumerable<FamilyCharactersDTO>> GetFamilyCharacters(int pageNo);
        Task<bool> Add(FamilyCharAddDTO FamilyChar);
        Task<IEnumerable<FamilyCharactersSearchDTO>> FilterFamilyCharacters(string sreachKey);
        Task<FamilyCharacterDetailsDTO> GetFamilyCharacterDetails(int id);
        Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharacters_4Admin(int pageNo);
        Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharByStatus(bool status, int pageNo);
        Task<IEnumerable<FamilyCharactersAdminDTO>> FilterFamilyCharacters_4Admin(string sreachKey);
        Task<bool> DeleteFamilyChar(int blogId);
        Task<bool> SetAcceptStatus(int Id, bool status);
        Task<FamilyCharactersAdminDTO> GetFamilyCharactersById_4Admin(int id);
        Task<bool> UpdateFamilyChar(FamilyCharUpdateDTO familyChar);
        int GeFCCount_All();
        Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharWattings(int pageNo);
        int GetFamilyCharWattings_Count();
        Task<IEnumerable<FamilyCharactersAdminDTO>> GetFamilyCharWatting(int pageNo);
        Task<bool> UpdateFamilyCharStatus(int fcId, bool status);
        int GetFamilyByStatus_Count(bool status);
    }
}
