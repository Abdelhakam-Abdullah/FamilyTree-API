using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IGeneralSettings
    {
        Settings GetSettings();
        Task<Settings> GetSettingsById(int id);
        Task<bool> Add(Settings settings);
        Task<bool> Update(Settings settings);
        Task<bool> UpdateLogo(SettingsDTO settings, string logoName);
    }
}
