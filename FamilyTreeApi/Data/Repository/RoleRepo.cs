using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly FamilyTreeContext _context;

        public RoleRepo(FamilyTreeContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(AddUserRoleDTO addUserRole)
        {
            object[] parameters =
            {
                    addUserRole.FullName,
                    addUserRole.UserName,
                    addUserRole.Password,
                    addUserRole.Email,
                    addUserRole.PhoneNumber
            };
            var StoredName = "AddUserRole {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AddUserToRole(int userId, int roleId)
        {
            object[] parameters = { userId, roleId };

            var StoredName = "AddUserToRole {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleListDTO>> GetRoles()
        {
            return await _context.Set<RoleListDTO>().FromSql("GetRoles").ToListAsync();
        }

        public async Task<IEnumerable<UsersRoleListDTO>> GetUsersRole(int roleId)
        {
            object[] parameters = { roleId };
            return await _context.Set<UsersRoleListDTO>().FromSql("GetUsersRole {0}", parameters).ToListAsync();
        }

        public async Task<IEnumerable<UsersRoleListDTO>> SearchUsers(string search)
        {
            object[] parameters = { search };
            return await _context.Set<UsersRoleListDTO>().FromSql("SearchUsers {0}", parameters).ToListAsync();
        }

        public int SearchUsersCount(string search)
        {
            var users = _context.User.Where(u => u.IsDelete == false && u.AcceptedAdd == true && u.IsLouck == false);
            var count = users.Where(u => u.FullName.Contains(search)).Count();
            return count;
        }

        public async Task<UsersRoleListDTO> CheckUserInSameRole(int userId, int roleId)
        {
            object[] parameters = { userId , roleId };
            return await _context.Set<UsersRoleListDTO>().FromSql("CheckUserInSameRole {0},{1}", parameters).FirstOrDefaultAsync();
        }

        public async Task<UsersRoleListDTO> CheckUserInAnotherRole(int userId)
        {
            object[] parameters = { userId };
            return await _context.Set<UsersRoleListDTO>().FromSql("CheckUserInAnotherRole {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<RoleListDTO> GetRoleNameByUser(int userId)
        {
            object[] parameters = { userId };
            return await _context.Set<RoleListDTO>().FromSql("GetRoleNameByUser {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteUserFromRole(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "DeleteUserFromRole {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateUserType(int userId, int userTypeId)
        {
            object[] parameters = { userId, userTypeId };
            var StoredName = "UpdateUserType {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

    }
}
