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

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUtitlities _utitlities;

        public UserController(IMapper mapper, IUserRepo userRepo,UserManager<User> userManager, IUtitlities utitlities)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
            _utitlities = utitlities;
        }

        [AllowAnonymous]
        [HttpGet("getFamilyTree")]
        public async Task<IActionResult> GetTree()
        {
            var res = await _userRepo.GetFamilyTree();
            return Ok(res);
        }

        //****Get user by identity number
        [AllowAnonymous]
        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUserByIdentityNumber(string id)
        {
            var result = await _userRepo.GetUsersByIdentityNum(id.Trim());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("getMyFamily/{id}")]
        public async Task<IActionResult> GetMyFamily(int id)
        {
            try
            {
                var result = await _userRepo.GetMyFamily(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("getUserProfile/{id}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            try
            {
                var result = await _userRepo.GetUserProfileById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("addChildren")]
        public async Task<IActionResult> AddChildren(AddChilredDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.UserName = user.UserName == "" ? user.Email : user.UserName;
                    user.Password = user.Password == "" ? user.Email : user.Password;
                    var userToCreate = _mapper.Map<User>(user);

                 
                    userToCreate.BirthDateH = Convert.ToDateTime(_utitlities.ToHijri(user.BirthDateM));
                    userToCreate.UserTypeId = 2;
                    userToCreate.IdentityNumber = _userRepo.GenerateRandomIdentity(user.FamilyId);
                    userToCreate.AcceptedAdd = false;

                    userToCreate.CreatedDateM = DateTime.UtcNow.AddHours(3);
                    userToCreate.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(userToCreate.CreatedDateM));
                    userToCreate.IsLouck = true;

                    var result = await _userManager.CreateAsync(userToCreate, user.Password);
                    if (result.Succeeded)
                        return Ok();
                    else return BadRequest(result.Errors);
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateUserNotifications")]
        public async Task<IActionResult> UpdateUserNotifications(UserNotifyUpdateDTO userNotification)
        {
            try
            {
                var result = await _userRepo.UpdateUserNotifications(userNotification);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("setIsRead/{id}")]
        public async Task<IActionResult> SetIsRead(int id)
        {
            try
            {
                var result = await _userRepo.SetIsRead(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getUserNotifications/{id}")]
        public async Task<IActionResult> GetUserNotifications(int id, int pageNo = 1)
        {
            var result = await _userRepo.GetUserNotifications(id, pageNo);
            return Ok(result);
        }

        [HttpPost("addUserNotifications")]
        public async Task<IActionResult> AddUserNotifications(UserNotificationsDTO userNotification)
        {
            try
            {
                userNotification.AddDateM = DateTime.UtcNow.AddHours(3);
                userNotification.AddDateH = Convert.ToDateTime(_utitlities.ToHijri(userNotification.AddDateM));
                userNotification.IsRead = false;

                var result = await _userRepo.AddUserNotifications(userNotification);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //[AllowAnonymous]
        //[HttpGet("getUsers_IEnumerable")]
        //public async Task<IActionResult> GetUsers_IEnumerable()
        //{
        //    var result = await _userRepo.GetUsers_Async_Enumerable();
        //    return Ok(result);
        //}

        //[AllowAnonymous]
        //[HttpGet("getUsers_IQueryable")]
        //public async Task<IActionResult> GetUsers_IQueryable()
        //{
        //    var result = await _userRepo.GetUsers_Async_Queryable();
        //    var result2 = await _userRepo.GetUsers_Async_Queryable2();

        //    return Ok(result);
        //}

        //[AllowAnonymous]
        //[HttpGet("getUsers_IQueryable_s")]
        //public async Task<IActionResult> GetUsers_IQueryable_s()
        //{
        //    var result = await _userRepo.GetUsers_Async_Queryable();
        //    var result2 = await _userRepo.GetUsers_Async_Queryable2();

        //    return Ok(result);
        //}

    }
}