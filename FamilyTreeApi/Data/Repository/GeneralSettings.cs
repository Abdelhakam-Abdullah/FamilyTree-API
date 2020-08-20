using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class GeneralSettings : IGeneralSettings, IDisposable
    {
        private readonly FamilyTreeContext _context;
        public GeneralSettings(FamilyTreeContext context)
        {
            _context = context;
        }

        public Settings GetSettings()
        {
            return _context.Set<Settings>().FromSql("GetSettings").FirstOrDefault();
        }

        public async Task<Settings> GetSettingsById(int id)
        {
            object[] parameters = {id};
            return await _context.Set<Settings>().FromSql("GetSettingsByID {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> Add(Settings settings)
        {
            object[] parameters =
                {
                    settings.AppName,
                    settings.MailAddress,
                    settings.MailServer,
                    settings.MailServerPort,
                    settings.MailUserName,
                    settings.MailPassword
            };
            var StoredName = "AddSettings {0},{1},{2},{3},{4},{5}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> Update(Settings settings)
        {
            object[] parameters =
               {
                    settings.Id,
                    settings.AppName,
                    settings.MailAddress,
                    settings.MailServer,
                    settings.MailServerPort,
                    settings.MailUserName,
                    settings.MailPassword
            };
            var StoredName = "UpdateSettings {0},{1},{2},{3},{4},{5},{6}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateLogo(SettingsDTO settings,string logoName)
        {
            object[] parameters = new object[3];
            parameters[0] = settings.Id;

            if (logoName == "AppLogo")
            {
                parameters[1] = settings.AppLogo;
            }
            else if(logoName == "CPanelLogo")
            {
                parameters[1] = settings.CPanelLogo;
            }
            else
            {
                parameters[1] = settings.LoginLogo;
            }

            parameters[2] = logoName;

            var StoredName = "UpdateImageSettings {0},{1},{2}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
