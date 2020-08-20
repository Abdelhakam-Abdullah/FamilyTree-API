using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IWifeRepo
    {
        Task<IEnumerable<WifeDTO>> GetWifesByUser(int userId);
        Task<bool> AddWife(Wife wife);
        Task<bool> DeleteWife(int Id);
        Task<bool> UpdateWife(Wife wife);
    }
}
