using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface ITermsRepo
    {
        Task<Terms> Get();
        Task<bool> Add(Terms definition);
        Task<bool> Update(Terms definition);
    }
}
