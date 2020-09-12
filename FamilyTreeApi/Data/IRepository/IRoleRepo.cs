using FamilyTreeApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IRoleRepo
    {
        Task<IEnumerable<RoleListDTO>> GetRoles();
        Task<IEnumerable<UsersRoleListDTO>> GetUsersRole(int roleId);
        Task<bool> Add(AddUserRoleDTO addUserRole);
        Task<bool> Delete(int Id);
        Task<bool> AddUserToRole(int userId, int roleId);
        Task<IEnumerable<UsersRoleListDTO>> SearchUsers(string search);
        int SearchUsersCount(string search);
        Task<UsersRoleListDTO> CheckUserInSameRole(int userId, int roleId);
        Task<UsersRoleListDTO> CheckUserInAnotherRole(int userId);
        Task<RoleListDTO> GetRoleNameByUser(int userId);
        Task<bool> DeleteUserFromRole(int userId);
        Task<bool> UpdateUserType(int userId, int userTypeId);
    }
}
