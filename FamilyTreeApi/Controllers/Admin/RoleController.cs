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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public SignInManager<User> _signInManager;
        private readonly IUtitlities _utitlities;
        public RoleManager<Role> _roleManager;

        public RoleController(IRoleRepo roleRepo, IMapper mapper, 
                           UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           IUtitlities utitlities,
                           RoleManager<Role> roleManager)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
            _utitlities = utitlities;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var result = await _roleRepo.GetRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUsersRole/{id}")]
        public async Task<IActionResult> GetUsersRole(int id)
        {
            try
            {
                var result = await _roleRepo.GetUsersRole(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addSuperAdmin")]
        public async Task<IActionResult> AddSuperAdmin(AddUserRoleDTO addUserRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userToCreate = _mapper.Map<User>(addUserRole);

                    userToCreate.UserName = addUserRole.UserName;
                    userToCreate.UserTypeId = 2;
                    userToCreate.FamilyId = 1;
                    userToCreate.CreatedDateM = DateTime.UtcNow.AddHours(3);
                    userToCreate.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(userToCreate.CreatedDateM));
                    userToCreate.AcceptedAdd = true;

                    var result = await _userManager.CreateAsync(userToCreate, addUserRole.Password);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(userToCreate.Email);
                        var role = await _roleManager.FindByIdAsync(addUserRole.RoleId.ToString());

                        var result2 = await _roleRepo.AddUserToRole(user.Id, role.Id);
                        if(result2)
                        {
                            return Ok();
                        }
                        else
                        {
                            await _userManager.DeleteAsync(user);
                            return BadRequest();
                        }
                    }
                    else return BadRequest(result.Errors);
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("removeFromRole")]
        public async Task<IActionResult> RemoveFromRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            try
            {
                var result = await _roleRepo.DeleteUserFromRole(user.Id);
                var userUpdated = await _roleRepo.UpdateUserType(user.Id, 2);
                if (result && userUpdated)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("searchUsers")]
        public async Task<IActionResult> SearchUsers(string search)
        {
            try
            {
                var Data = await _roleRepo.SearchUsers(search);
                var Count = _roleRepo.SearchUsersCount(search);
                return Ok(new
                {
                    data = Data,
                    count = Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("addUerToRole")]
        public async Task<IActionResult> AddSuperAdmin(AddUserToRoleDTO userRole)
        {
            try
            {
                //check user in same role
                var userInSameRole = await _roleRepo.CheckUserInSameRole(userRole.UserId, userRole.RoleId);
                if (userInSameRole != null)
                    return BadRequest(new
                    {
                        status = "foundInSameRole"
                    });

                //check user in another role
                var userInAnotherRole = await _roleRepo.CheckUserInAnotherRole(userRole.UserId);
                if (userInAnotherRole != null)
                    return BadRequest(new
                    {
                        status = "foundAnotherRole"
                    });

                //save
                var user = await _userManager.FindByIdAsync(userRole.UserId.ToString());
                var userUpdated = await _roleRepo.UpdateUserType(user.Id, 1);
                var result = await _roleRepo.AddUserToRole(userRole.UserId, userRole.RoleId);
                if (result && userUpdated)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getRoleNameByUser/{id}")]
        public async Task<IActionResult> GetRoleNameByUser(int id)
        {
            try
            {
                var result = await _roleRepo.GetRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}