using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class UserRepo : IUserRepo, IDisposable
    {
        private readonly FamilyTreeContext _context;
        private List<User> listAllUsers;
        public UserRepo(FamilyTreeContext context)
        {
            _context = context;
            listAllUsers = new List<User>();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<UserIdentityDTO> CheckExsistIdentityNumeber(string identityNumber)
        {
            object[] parameters = { identityNumber };
            return await _context.Set<UserIdentityDTO>().FromSql("CheckExsistIdentityNumeber {0}", parameters).FirstOrDefaultAsync();
        }
                
        public async Task<bool> AcceptAddUser(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "AcceptedUserAdd {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AcceptAddChildren(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "AcceptedUserAdd {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AcceptAddFamilyChar(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "AcceptedUserAdd {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AllowNews(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "AcceptedUserAdd {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> AllowBlog(int userId)
        {
            object[] parameters = { userId };
            var StoredName = "AcceptedUserAdd {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<UserPermissionDTO>> GetUserPermission(int pageNo)
        {
            object[] parameters ={pageNo };
            var StoredName = "GetUserPermission {0}";
            return await _context.Set<UserPermissionDTO>().FromSql(StoredName ,parameters).ToListAsync();
        }

        public int GetUserPermission_AllCount()
        {
            return _context.User.Where(u => u.AcceptedAdd == true && u.IsDelete == false).Count();
        }

        public int GetUser_AllCount()
        {
            return _context.User.Where(u => u.IsDelete == false).Count();
        }

        public int GetUser_AllCountNotAccepted()
        {
            return _context.User.Where(u => u.IsDelete == false && u.AcceptedAdd == false).Count();
        }

        public async Task<bool> UpdatePermission(UserPermissionUpdateDTO userPermissionUpdateDTO)
        {
            object[] parameters = 
                {
                    userPermissionUpdateDTO.Id,
                    userPermissionUpdateDTO.IsAddChild,
                    userPermissionUpdateDTO.IsAddFamilyChar,
                    userPermissionUpdateDTO.IsAddBlogs,
                    userPermissionUpdateDTO.IsAddNews
                };
            var StoredName = "UpdateUSerPermission {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<UserPermissionDTO>> FilterUserPermission(FilterUserPermissionDTO filter)
        {
            object[] parameters =
                {
                    filter.SearchBy.Trim(),
                    filter.SearckKey.Trim()
                };
            return await _context.Set<UserPermissionDTO>().FromSql("FilterUserPermission {0},{1}", parameters).ToListAsync();
        }

        public async Task<IEnumerable<UserPermissionDTO>> FilterUserPermissions(int userId,string search)
        {
            object[] parameters = { userId, search };
            return await _context.Set<UserPermissionDTO>().FromSql("FilterUserPermission {0},{1}", parameters).ToListAsync();
        }
        
        public async Task<List<TreeAdminDTO>> GetFamilyTree_4Admin()
        {
            listAllUsers = await _context.User
                                    .Where(u => u.IsDelete == false)
                                    .Where(u => u.AcceptedAdd == true)
                                    .ToListAsync();
            var lstResult = new List<TreeAdminDTO>();

            var lstParentUsers = listAllUsers.Where(x => x.ParentId == null).ToList();
            foreach (var user in lstParentUsers)
            {
                var oItem = new TreeAdminDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.IdentityNum = user.IdentityNumber;
                oItem.UserImage = user.Image;
                oItem.Gender = user.GenderId;
                oItem.Status = user.StatusId;

                oItem.Children = GetUserChilds_4Admin(user.Id);
                lstResult.Add(oItem);
            }
            return lstResult;
        }

        private List<TreeAdminDTO> GetUserChilds_4Admin(int parentId)
        {
            var lstChilds = new List<TreeAdminDTO>();
            foreach (var user in listAllUsers.Where(x => x.ParentId == parentId))
            {
                var oItem = new TreeAdminDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.IdentityNum = user.IdentityNumber;
                oItem.UserImage = user.Image;
                oItem.Gender = user.GenderId;
                oItem.Status = user.StatusId;
                //oItem.Parent_Id = acc.ParentId;

                oItem.Children = GetUserChilds_4Admin(user.Id);
                lstChilds.Add(oItem);
            }
            return lstChilds;
        }
       
        public async Task<UserDataDTO> GetUserById(int id)
        {
            var UserData = new UserDataDTO();
            object[] parameters = {id};

            UserData.UserData = await _context.Set<UserToReturnDTO>().FromSql("GetUserById {0}", parameters).FirstOrDefaultAsync();

            UserData.Parent = await _context.Set<UserRelationDTO>().FromSql("GetUser_Parent {0}", parameters).FirstOrDefaultAsync();
            UserData.GrandParent = await _context.Set<UserRelationDTO>().FromSql("GetUser_GrandParent {0}", parameters).FirstOrDefaultAsync();
            UserData.Children = await _context.Set<UserRelationDTO>().FromSql("GetUser_Children {0}", parameters).ToListAsync();
            UserData.Brothers = await _context.Set<UserRelationDTO>().FromSql("GetUser_Brothers {0}", parameters).ToListAsync();
            UserData.Uncles = await _context.Set<UserRelationDTO>().FromSql("GetUser_Uncles {0}", parameters).ToListAsync();
            UserData.Wifes = await _context.Set<WifeDTO>().FromSql("GetWifes {0}", parameters).ToListAsync();

            return UserData;
        }

        public async Task<UserDataDTO> GetMyFamily(int id)
        {
            var UserData = new UserDataDTO();
            object[] parameters = { id };

            UserData.Parent = await _context.Set<UserRelationDTO>().FromSql("GetUser_Parent {0}", parameters).FirstOrDefaultAsync();
            UserData.GrandParent = await _context.Set<UserRelationDTO>().FromSql("GetUser_GrandParent {0}", parameters).FirstOrDefaultAsync();
            UserData.Children = await _context.Set<UserRelationDTO>().FromSql("GetUser_Children {0}", parameters).ToListAsync();
            UserData.Brothers = await _context.Set<UserRelationDTO>().FromSql("GetUser_Brothers {0}", parameters).ToListAsync();
            UserData.Uncles = await _context.Set<UserRelationDTO>().FromSql("GetUser_Uncles {0}", parameters).ToListAsync();
            UserData.Wifes = await _context.Set<WifeDTO>().FromSql("GetWifes {0}", parameters).ToListAsync();

            return UserData;
        }

        public async Task<IEnumerable<UserReturnDTO>> GetUsers(int userId, int pageNo)
        {
            object[] parameters = { userId, pageNo };
            return await _context.Set<UserReturnDTO>().FromSql("GetUsers {0},{1}", parameters).ToListAsync();
        }

        public async Task<UserReturnDTO> GetFather(int parentId)
        {
            object[] parameters = { parentId };
            return await _context.Set<UserReturnDTO>().FromSql("GetFather {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<UserProfileDataDTO> GetUser_ById(int id)
        {
            object[] parameters = { id };
            return await _context.Set<UserProfileDataDTO>().FromSql("GetUser_ById {0}", parameters).FirstOrDefaultAsync();            
        }

        public async Task<UserProfileDTO> GetUserProfileById(int id)
        {
            object[] parameters = { id };
            return await _context.Set<UserProfileDTO>().FromSql("GetUserProfile {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserStatus(int Id, bool status)
        {
            object[] parameters = { Id, status };
            var StoredName = "UpdateUserStatus {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<UserReturnDTO>> GetUsersByStatus(bool status)
        {
            object[] parameters = { status };
            return await _context.Set<UserReturnDTO>().FromSql("GetUsersByStatus {0}", parameters).ToListAsync();
        }

        public async Task<IEnumerable<UserReturnDTO>> FilterUsers(int userId,string search)
        {
            object[] parameters = { userId, search.Trim() };
            return await _context.Set<UserReturnDTO>().FromSql("FilterUsers {0},{1}", parameters).ToListAsync();
        }

        //===================================
        public async Task<List<TreeDTO>> GetFamilyTree()
        {
            listAllUsers = await _context.User
                                    .Where(u => u.IsDelete == false)
                                    .Where(u => u.AcceptedAdd == true)
                                    .ToListAsync();
            var lstResult = new List<TreeDTO>();

            var lstParentUsers = listAllUsers.Where(x => x.ParentId == null).ToList();
            foreach (var user in lstParentUsers)
            {
                var oItem = new TreeDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.Children = GetUserChilds(user.Id);
                oItem.UserImage = user.Image;
                lstResult.Add(oItem);
            }
            return lstResult;
        }

        private List<TreeDTO> GetUserChilds(int parentId)
        {
            var lstChilds = new List<TreeDTO>();
            foreach (var user in listAllUsers.Where(x => x.ParentId == parentId))
            {
                var oItem = new TreeDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.UserImage = user.Image;

                oItem.Children = GetUserChilds(user.Id);
                lstChilds.Add(oItem);
            }
            return lstChilds;
        }
        //=======================================

        public async Task<List<TreeAdminDTO>> FilterFamilyTree(string search)
        {
            string searchKey = search.Trim();
            listAllUsers = await _context.User
                                    .Where(u => u.IsDelete == false)
                                    .Where(u => u.AcceptedAdd == true && u.FullName.Contains(searchKey) || u.IdentityNumber == searchKey)
                                    .ToListAsync();
            var lstResult = new List<TreeAdminDTO>();

            var lstParentUsers = listAllUsers.Where(x => x.ParentId == null).ToList();
            foreach (var user in lstParentUsers)
            {
                var oItem = new TreeAdminDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.IdentityNum = user.IdentityNumber;
                oItem.Children = FilterChild(user.Id);
                oItem.UserImage = user.Image;
                lstResult.Add(oItem);
            }
            return lstResult;
        }

        private List<TreeAdminDTO> FilterChild(int parentId)
        {
            var lstChilds = new List<TreeAdminDTO>();
            foreach (var user in listAllUsers.Where(x => x.ParentId == parentId))
            {
                var oItem = new TreeAdminDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.IdentityNum = user.IdentityNumber;
                oItem.UserImage = user.Image;
                //oItem.Parent_Id = acc.ParentId;

                oItem.Children = GetUserChilds_4Admin(user.Id);
                lstChilds.Add(oItem);
            }
            return lstChilds;
        }

        public async Task<IEnumerable<Gender>> GetGenderTypes()
        {
            return await _context.Set<Gender>().FromSql("GetGenderType").ToListAsync();
        }

        public async Task<IEnumerable<UserReturnDTO>> GetUsersNotAccepted(int pageNo)
        {
            object[] parameters = { pageNo };
            return await _context.Set<UserReturnDTO>().FromSql("GetUsersNotAccepted {0}", parameters).ToListAsync();
        }

        public async Task<bool> AcceptUserAdd(int userId,  bool acceptAdd)
        {
            object[] parameters = { userId , acceptAdd };
            var StoredName = "AcceptUserAdd {0},{1}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<UserReturnDTO>> FilterUserNotAccepted(int userId, string search)
        {
            object[] parameters = { userId, search.Trim() };
            return await _context.Set<UserReturnDTO>().FromSql("FilterUserNotAccepted {0},{1}", parameters).ToListAsync();
        }

        public async Task<UserDataDTO> GetUserProfile(int id)
        {
            var UserData = new UserDataDTO();
            object[] parameters = { id };

            UserData.UserData = await _context.Set<UserToReturnDTO>().FromSql("GetUserById {0}", parameters).FirstOrDefaultAsync();

            UserData.Parent = await _context.Set<UserRelationDTO>().FromSql("GetUser_Parent {0}", parameters).FirstOrDefaultAsync();
            UserData.GrandParent = await _context.Set<UserRelationDTO>().FromSql("GetUser_GrandParent {0}", parameters).FirstOrDefaultAsync();
            UserData.Children = await _context.Set<UserRelationDTO>().FromSql("GetUser_Children {0}", parameters).ToListAsync();
            UserData.Brothers = await _context.Set<UserRelationDTO>().FromSql("GetUser_Brothers {0}", parameters).ToListAsync();
            UserData.Uncles = await _context.Set<UserRelationDTO>().FromSql("GetUser_Uncles {0}", parameters).ToListAsync();
            UserData.Wifes = await _context.Set<WifeDTO>().FromSql("GetWifes {0}", parameters).ToListAsync();

            return UserData;
        }

        //===========================================
        //public string GetNewIdentityNumber(int? parentId, int familyId)
        //{
        //    string newIdentity = "";
        //    int userCount = 0;
        //    var usersCount = 0;
        //    string parentIdentityNumber = "";
        //    int newUserCount = 0;

        //    usersCount = _context.User.Count();
        //    var familySymbole = _context.Family.Where(f => f.Id == familyId).FirstOrDefault();

        //    if (usersCount == 0)
        //    {
        //        newIdentity = familySymbole.Symbole + "-" + "01";
        //    }
        //    else
        //    {
        //        userCount = _context.User.Where(u => u.ParentId == parentId).Count();
        //        newUserCount = userCount + 1;
        //        parentIdentityNumber = _context.User.Where(u => u.Id == parentId).FirstOrDefault().IdentityNumber;

        //        if (userCount < 9)
        //            newIdentity = familySymbole.Symbole + "-" + string.Join(string.Empty, parentIdentityNumber.Skip(2)) + "0" + newUserCount;
        //        else
        //            newIdentity = familySymbole.Symbole + "-" + string.Join(string.Empty, parentIdentityNumber.Skip(2)) + newUserCount;
        //    }
        //    return newIdentity;
        //}

        public string GenerateRandomIdentity(int familyId)
        {
            var familySymbole = _context.Family.Where(f => f.Id == familyId).FirstOrDefault();
            var FamilySymbole = familySymbole.Symbole + "-";
            while (true)
            {
                var _numbers = "0123456789";
                var random = new Random();
                var builder = new StringBuilder(14);
                var numbers = "";
                
                for (var i = 0; i < 6; i++)
                    builder.Append(_numbers[random.Next(0, _numbers.Length)]);
                numbers = builder.ToString();
                
                var result = CheckUsersByIdentityNum(FamilySymbole + numbers);
                if (result == null)
                {
                    var identityNum = FamilySymbole + numbers;
                    return identityNum;
                }
            }
        }

        public UserFilterDTO CheckUsersByIdentityNum(string IdentityNum)
        {
            object[] parameters = { IdentityNum };
            return _context.Set<UserFilterDTO>().FromSql("GetUserByIdentityNum {0}", parameters).FirstOrDefault();
        }

        public async Task<UserFilterDTO> GetUsersByIdentityNum(string IdentityNum)
        {
            object[] parameters = { IdentityNum };
            return await _context.Set<UserFilterDTO>().FromSql("GetUserByIdentityNum {0}", parameters).FirstOrDefaultAsync();
        }

        //==============================================

        public async Task<UserInfoDTO> GetUserInfo(int id)
        {
            object[] parameters = { id };
            return await _context.Set<UserInfoDTO>().FromSql("GetUserInfo {0}", parameters).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserInfoDTO>> GetUserChildren(int parentId)
        {
            object[] parameters = { parentId };
            return await _context.Set<UserInfoDTO>().FromSql("GetUserChildren {0}", parameters).ToListAsync();
        }

        public async Task<bool> UpdateUserInfo(UserInfoDTO userInfo)
        {
            object[] parameters = 
            {
                userInfo.Id,
                userInfo.FullName,
                userInfo.UserName,
                userInfo.Email,
                userInfo.PhoneNumber,
                userInfo.BirthDateM,
                userInfo.BirthDateH,
                userInfo.JobTitle,
                userInfo.WorkAddress,
                userInfo.Address,
                userInfo.GenderId,
                userInfo.StatusId,
                userInfo.FamilyId,
                userInfo.MotherId,
                userInfo.FaceBookAcc,
                userInfo.TwitterAcc,
                userInfo.Image,

                userInfo.AllowAddChildren,
                userInfo.AllowAddFamilyChar,
                userInfo.AllowBlog,
                userInfo.AllowNews,

            };
            var StoredName = "UpdateUserInfo {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> UpdateUserNotifications(UserNotifyUpdateDTO userNotifyUpdate)
        {
            object[] parameters = {
                userNotifyUpdate.UserId,
                userNotifyUpdate.Allow_GeneralNews,
                userNotifyUpdate.Allow_Monasabat,
                userNotifyUpdate.Allow_Mawaled,
                userNotifyUpdate.Allow_Wafeaat
            };
            var StoredName = "UpdateUserNotifications {0},{1},{2},{3},{4}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<bool> SetIsRead(int id)
        {
            object[] parameters = {id};
            var StoredName = "setIsRead {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        public async Task<IEnumerable<UserNotificationsDTO>> GetUserNotifications(int userId, int pageNo)
        {
            object[] parameters = { userId, pageNo };
            var StoredName = "GetUserNotifications {0},{1}";
            return await _context.Set<UserNotificationsDTO>().FromSql(StoredName, parameters).ToListAsync();
        }

        public int GetUserNotificationCount(int userId)
        {
            return _context.UserNotification.Where(un => un.UserId == userId && un.IsDelete == false).Count();
        }

        public async Task<bool> AddUserNotifications(UserNotificationsDTO userNotification)
        {
            object[] parameters = {
                userNotification.UserId,
                userNotification.NewsId,
                userNotification.IsRead,
                userNotification.NotifyName,
                userNotification.NotifyType,
                userNotification.AddDateM,
                userNotification.AddDateH
            };
            var StoredName = "AddUserNotification {0},{1},{2},{3},{4},{5},{6}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }

        //========= test tree
        public async Task<List<TreeDTO>> GetFamilyTree_4Mobile(int pageNo)
        {
            listAllUsers = await _context.User
                                    .Where(u => u.IsDelete == false)
                                    .Where(u => u.AcceptedAdd == true)
                                    .ToListAsync();
            var lstResult = new List<TreeDTO>();

            var lstParentUsers = listAllUsers.Where(x => x.ParentId == null).ToList();
            foreach (var user in lstParentUsers)
            {
                var oItem = new TreeDTO();
                oItem.Id = user.Id;
                oItem.Name = user.FullName;
                oItem.Children = GetUserChilds(user.Id);
                oItem.UserImage = user.Image;
                lstResult.Add(oItem);
            }
            var data = lstResult.Skip(10).Take(5).ToList();
            return data;
        }


        public async Task<IEnumerable<UserParentsDTO>> GetParents()
        {
            return await _context.Set<UserParentsDTO>().FromSql("GetParents").ToListAsync();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            object[] parameters =
                {
                    userId
                };
            var StoredName = "DeleteUser {0}";
            return await _context.Database.ExecuteSqlCommandAsync(StoredName, parameters) > 0;
        }


    }
}
