using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IUserRepo
    {
        //Task<IEnumerable<GetUsersDTO>> GetUsers_Async_Enumerable();
        //Task<List<GetUsersDTO>> GetUsers_Async_Queryable();
        //Task<IQueryable<GetUsersDTO>> GetUsers_Async_Queryable2();

        Task<UserIdentityDTO> CheckExsistIdentityNumeber(string identityNumber);
        Task<UserFilterDTO> GetUsersByIdentityNum(string IdentityNum);
        //string GetNewIdentityNumber(int? parentId, int familyId);

        Task<bool> AcceptAddUser(int userId);
        Task<bool> AcceptAddChildren(int userId);
        Task<bool> AcceptAddFamilyChar(int userId);
        Task<bool> AllowNews(int userId);
        Task<bool> AllowBlog(int userId);
        Task<IEnumerable<UserPermissionDTO>> GetUserPermission(int pageNo);
        Task<bool> UpdatePermission(UserPermissionUpdateDTO userPermissionUpdateDTO);
        int GetUserPermission_AllCount();
        Task<IEnumerable<UserPermissionDTO>> FilterUserPermission(FilterUserPermissionDTO filter);
        Task<IEnumerable<UserPermissionDTO>> FilterUserPermissions(int userId, string search);
        Task<List<TreeAdminDTO>> GetFamilyTree_4Admin();
        Task<List<TreeDTO>> GetFamilyTree(); 
        Task<UserDataDTO> GetUserById(int id);
        Task<UserDataDTO> GetMyFamily(int id);
        Task<IEnumerable<UserReturnDTO>> GetUsers(int userId,int pageNo);
        int GetUser_AllCount();
        Task<UserProfileDataDTO> GetUser_ById(int id);
        Task<bool> UpdateUserStatus(int Id, bool status);
        Task<IEnumerable<UserReturnDTO>> GetUsersByStatus(bool status);
        Task<IEnumerable<UserReturnDTO>> FilterUsers(int userId,string search);
        Task<List<TreeAdminDTO>> FilterFamilyTree(string search);
        Task<IEnumerable<Gender>> GetGenderTypes();
        Task<IEnumerable<UserReturnDTO>> GetUsersNotAccepted(int pageNo);
        int GetUser_AllCountNotAccepted();
        Task<UserReturnDTO> GetFather(int parentId);
        Task<bool> AcceptUserAdd(int userId, bool acceptAdd);
        Task<IEnumerable<UserReturnDTO>> FilterUserNotAccepted(int userId, string search);
        Task<UserProfileDTO> GetUserProfileById(int id);
        string GenerateRandomIdentity(int familyId);
        UserFilterDTO CheckUsersByIdentityNum(string IdentityNum);
        Task<UserInfoDTO> GetUserInfo(int id);
        Task<IEnumerable<UserInfoDTO>> GetUserChildren(int parentId);
        Task<bool> UpdateUserInfo(UserInfoDTO userInfo);
        Task<bool> UpdateUserNotifications(UserNotifyUpdateDTO userNotifyUpdate);
        Task<bool> SetIsRead(int id);
        Task<IEnumerable<UserNotificationsDTO>> GetUserNotifications(int userId, int pageNo);
        int GetUserNotificationCount(int userId);
        Task<bool> AddUserNotifications(UserNotificationsDTO userNotification);
        Task<List<TreeDTO>> GetFamilyTree_4Mobile(int pageNo);
        Task<IEnumerable<UserParentsDTO>> GetParents();
        Task<bool> DeleteUser(int userId);
    }
}
