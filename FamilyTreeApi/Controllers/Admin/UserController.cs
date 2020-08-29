using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepo _userRepo;
        private readonly IUtitlities _utitlities;
        private readonly IMapper _mapper;
        private readonly IWifeRepo _wifeRepo;

        public UserController(UserManager<User> userManager, IUserRepo userRepo, IUtitlities utitlities, IMapper mapper,
            IWifeRepo wifeRepo)
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _utitlities = utitlities;
            _mapper = mapper;
            _wifeRepo = wifeRepo;
        }

        //[HttpGet("acceptedUserAdd/{id}")]
        //public async Task<IActionResult> AcceptedUserAdd(int id)
        //{
        //    var _user = await _userManager.FindByIdAsync(id.ToString());
        //    if (_user != null)
        //    {
        //        var emails = new List<string>();
        //        emails.Add(_user.Email);
        //        if (await _userRepo.AcceptAddUser(id) && _utitlities.SendMailAsync(emails, "Your Identity Number is : " + _user.IdentityNumber, "Family app"))
        //            return Ok();

        //        return BadRequest();
        //    }
        //    return NotFound();
        //}

        [HttpGet("getUserPermission")]
        public async Task<IActionResult> GetUserPermission(int pageNo = 1)
        {
            var Data = await _userRepo.GetUserPermission(pageNo);
            return Ok(new
            {
                data = Data,
                count = _userRepo.GetUserPermission_AllCount()
            });
        }

        [HttpPost("updatePermission")]
        public async Task<IActionResult> UpdatePermission(UserPermissionUpdateDTO userPermission)
        {
            try
            {
                var result = await _userRepo.UpdatePermission(userPermission);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("filterUserPermissions")]
        public async Task<IActionResult> FilterUserPermissions(string search)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var Data = await _userRepo.FilterUserPermissions( Convert.ToInt32(userId), search);
                return Ok(new
                {
                    data = Data,
                    count = Data.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("getFamilyTree")]
        public async Task<IActionResult> GetTree()
        {
            var res =  await _userRepo.GetFamilyTree_4Admin();
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("getFamilyTreeForMobile")]
        public async Task<IActionResult> GetFamilyTreeForMobile()
        {
            var res = await _userRepo.GetFamilyTree_4Admin();
            //var res = await _userRepo.GetFamilyTree_4Mobile(1);
            return Ok(res);
        }

        [HttpGet("filterFamilyTree")]
        public async Task<IActionResult> FilterFamilyTree(string search)
        {
            var res = await _userRepo.FilterFamilyTree(search);
            return Ok(res);
        }

        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var result = await _userRepo.GetUserById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers(int pageNo = 1)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var result = await _userRepo.GetUsers(Convert.ToInt32(userId),pageNo);
                return Ok(new
                {
                    data = result,
                    count = _userRepo.GetUser_AllCount()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getFather/{id}")]
        public async Task<IActionResult> GetFather(int id)
        {
            try
            {
                var result = await _userRepo.GetFather(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await _userRepo.GetUser_ById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("updateUserStatus/{status}/{id}")]
        public async Task<IActionResult> UpdateUserStatus(bool status, int id)
        {
            var result = await _userRepo.UpdateUserStatus(id, status);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getUsersByStatus/{status}")]
        public async Task<IActionResult> GetUsersByStatus(bool status)
        {
            try
            {
                var Data = await _userRepo.GetUsersByStatus(status);
                return Ok(new
                {
                    data = Data,
                    count = Data.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ///////////////////// Revision
        [HttpGet("filterUsers")]
        public async Task<IActionResult> FilterUsers(string search)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var Data = await _userRepo.FilterUsers(Convert.ToInt32(userId), search);
                return Ok(new
                {
                    data = Data,
                    count = Data.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getBirthDateH")]
        public IActionResult GetBirthDateH(DateTime dateM)
        {
            try
            {
                var dateH = Convert.ToDateTime(_utitlities.ToHijri(Convert.ToDateTime(dateM)));
                return Ok(dateH.ToString("yyyy/MM/dd"));
            }
            catch (Exception)
            {
                return Ok("");
            }
        }

        [HttpGet("getGenderTypes")]
        public async Task<IActionResult> GetGenderTypes()
        {
            try
            {
                var result = await _userRepo.GetGenderTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getUsersNotAccepted")]
        public async Task<IActionResult> GetUsersNotAccepted(int pageNo = 1)
        {
            try
            {
                var result = await _userRepo.GetUsersNotAccepted(pageNo);
                return Ok(new
                {
                    data = result,
                    count = _userRepo.GetUser_AllCountNotAccepted()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("acceptUserAdd/{id}/{userMail}/{IDn}")]
        public async Task<IActionResult> AcceptUserAdd(int id, string userMail, string IDn)
        {
            
            List<string> mails = new List<string>();
            var isUpdated = false;
            var isSendMail = false;
            var subject = "أسرة الثنيان";
            var body = "<b>مرحباً</b> <br /><br /> الرقم التعريفى للسيد الوالد : " + IDn + "<br /><br /> <b>إدارة اسرة الثنيان</b> ";
            mails.Add(userMail);

            isUpdated = await _userRepo.AcceptUserAdd(id, true);
            isSendMail = _utitlities.SendMail(mails, body, subject);

            if (isUpdated && isSendMail)
            {
                var result = await _userRepo.GetUsersNotAccepted(1);
                return Ok(new
                {
                    data = result,
                    count = _userRepo.GetUser_AllCountNotAccepted()
                });
            }
            else
            {
                await _userRepo.AcceptUserAdd(id, false);
                return BadRequest();
            }


        }

        [HttpGet("filterUserNotAccepted")]
        public async Task<IActionResult> FilterUserNotAccepted(string searchKey)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var Data = await _userRepo.FilterUserNotAccepted(Convert.ToInt32(userId), searchKey);
                return Ok(new
                {
                    data = Data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("addChildren")]
        public async Task<IActionResult> AddChildren(AddChilredDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //user.UserName = user.UserName == "" ? user.Email : user.UserName;
                    //user.Password = user.Password == "" ? user.Email : user.Password;
                    var userToCreate = _mapper.Map<User>(user);


                    userToCreate.BirthDateH = Convert.ToDateTime(_utitlities.ToHijri(user.BirthDateM));
                    userToCreate.UserTypeId = 2;
                    userToCreate.IdentityNumber = _userRepo.GenerateRandomIdentity(user.FamilyId);
                    userToCreate.AcceptedAdd = true;
                    userToCreate.IsLouck = user.IsLouck;

                    userToCreate.CreatedDateM = DateTime.UtcNow.AddHours(3);
                    userToCreate.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(userToCreate.CreatedDateM));

                    var result = await _userManager.CreateAsync(userToCreate, user.Password);
                    if (result.Succeeded)
                        return Ok();
                    else return BadRequest(result.Errors);
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getUserInfo/{id}")]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            try
            {
                var UserInfo = await _userRepo.GetUserInfo(id);
                var Wifes = await _wifeRepo.GetWifesByUser(id);
                var Children = await _userRepo.GetUserChildren(id);

                return Ok(new
                {
                    userInfo = UserInfo,
                    wifes = Wifes,
                    children = Children
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getUserChildren/{id}")]
        public async Task<IActionResult> GetUserChildren(int id)
        {
            try
            {
                var Children = await _userRepo.GetUserChildren(id);
                return Ok(Children);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("updateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo(UserInfoDTO user)
        {
            try
            {
                //user.UserName = user.UserName == "" ? user.Email : user.UserName;
                //user.Password = user.Password == "" ? user.Email : user.Password;
                //var userToCreate = _mapper.Map<User>(user);
                var result = await _userRepo.UpdateUserInfo(user);
                if (result)
                    return Ok();

                else return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("updateUserLoginData")]
        public async Task<IActionResult> UpdatePassword(UpdateUserLoginDataDTO user)
        {
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            if (_user != null)
            {
                _user.UserName = user.UserName;
                var result = await _userManager.ChangePasswordAsync(_user, user.OldPassword, user.NewPassword);
                if (result.Succeeded)
                    return Ok();

                return BadRequest(result.Errors);
            }
            return BadRequest();
        }

        [HttpGet("getParents")]
        public async Task<IActionResult> GetParents()
        {
            var result = await _userRepo.GetParents();
            return Ok(result);
        }

        [HttpGet("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepo.DeleteUser(id);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}