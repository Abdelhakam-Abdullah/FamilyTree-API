using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface INewsImageRepo
    {
        Task<bool> AddNewsImage(NewsImageDTO newsImage);
    }
}
