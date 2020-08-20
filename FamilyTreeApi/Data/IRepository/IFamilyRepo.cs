using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IFamilyRepo
    {
        Task<IEnumerable<FamilyDTO>> GetFamilies();
    }
}
