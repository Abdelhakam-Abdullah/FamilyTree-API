using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IDefinitionLineageRepo
    {
        Task<DefinitionLineage> GetDefinitionLineage();
        Task<bool> Add(DefinitionLineage definition);
        Task<bool> Update(DefinitionLineage definition);
    }
}
