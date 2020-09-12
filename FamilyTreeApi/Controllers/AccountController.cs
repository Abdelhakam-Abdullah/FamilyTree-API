using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public SignInManager<User> _signInManager;
        public AppSettings _options { get; }
        private readonly IUserRepo _userRepo;
        private readonly IUtitlities _utitlities;
        private readonly IUploaderRepo _uploaderRepo;
        private readonly IGeneralSettings _generalSettings;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IRoleRepo _roleRepo;

        public AccountController(IMapper mapper,
                           IUserRepo userRepo,
                           IUtitlities utitlities,
                           UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           IOptions<AppSettings> options,
                           IHostingEnvironment HostingEnvironment,
                           IUploaderRepo UploaderRepo,
                           IGeneralSettings generalSettings,
                           IRoleRepo roleRepo)
        {
            _userRepo = userRepo;
            _utitlities = utitlities;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options.Value;
            _hostingEnvironment = HostingEnvironment;
            _uploaderRepo = UploaderRepo;
            _generalSettings = generalSettings;
            _roleRepo = roleRepo;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.UserName = user.Email;
                    user.Password = user.Email;
                    var userToCreate = _mapper.Map<User>(user);
                    userToCreate.UserTypeId = 2;
                    userToCreate.ParentId = user.ParentId;
                    userToCreate.FamilyId = user.FamilyId;
                    //userToCreate.IdentityNumber = _userRepo.GetNewIdentityNumber(user.ParentId, user.FamilyId);
                    userToCreate.IdentityNumber = _userRepo.GenerateRandomIdentity(user.FamilyId);
                    userToCreate.CreatedDateM = DateTime.UtcNow.AddHours(3);
                    userToCreate.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(userToCreate.CreatedDateM));
                    userToCreate.GenderId = user.GenderId;

                    var result = await _userManager.CreateAsync(userToCreate, user.Password);
                    if (result.Succeeded)
                        return Ok();
                    else return BadRequest(result.Errors);
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //****login user
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                if (user.IsLouck == true || user.IsLouck == null)
                    return BadRequest();

                if (user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
                {
                    var usertoReturn = _mapper.Map<UserToReturnDTO>(user);
                    return Ok(new
                    {
                        token = _utitlities.GenerateToken(user, _options),
                        user = usertoReturn
                    });
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [AllowAnonymous]
        [HttpPost("register2")]
        public async Task<IActionResult> Register2(UserRegisterDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userToCreate = _mapper.Map<User>(user);

                    userToCreate.UserName = user.UserName;
                    userToCreate.UserTypeId = 2;
                    userToCreate.ParentId = user.ParentId;
                    userToCreate.FamilyId = user.FamilyId;
                    userToCreate.IdentityNumber = _userRepo.GenerateRandomIdentity(user.FamilyId);
                    userToCreate.CreatedDateM = DateTime.UtcNow.AddHours(3);
                    userToCreate.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(userToCreate.CreatedDateM));
                    userToCreate.GenderId = user.GenderId;
                    userToCreate.StatusId = user.StatusId;
                    userToCreate.AcceptedAdd = true;
                    userToCreate.BirthDateM = user.BirthDateM;
                    userToCreate.BirthDateH = user.BirthDateH;

                    var result = await _userManager.CreateAsync(userToCreate, user.Password);
                    if (result.Succeeded)
                        return Ok();
                    else return BadRequest(result.Errors);
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //****Get user data by identity number
        [AllowAnonymous]
        [HttpGet("checkIdentityNumber/{id}")]
        public async Task<IActionResult> CheckIdentityNumber(string id)
        {
            var result = await _userRepo.CheckExsistIdentityNumeber(id.ToUpper().Trim());
            if (result == null)
                return NotFound();
            else
            {
                if (result.AcceptedAdd)
                    return Ok(result);
                else
                    return BadRequest("User not accepted yet");
            }
        }

        //****Complete registeration
        [AllowAnonymous]
        [HttpPost("completeRegister")]
        public async Task<IActionResult> CompleteRegister(UserCompleteRegisterDTO user)
        {
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            if (_user != null)
            {
                _user.IsLouck = true;
                _user.UserName = user.UserName;
                _user.BirthDateM = user.BirthDateM;
                _user.BirthDateH = Convert.ToDateTime(_utitlities.ToHijri(user.BirthDateM));            
                var result = await _userManager.ChangePasswordAsync(_user, _user.Email, user.Password);

                if (result.Succeeded)
                    return Ok();

                return BadRequest(result.Errors);
            }
            return BadRequest();
        }

        //****login admins
        [AllowAnonymous]
        [HttpPost("adminLogin")]
        public async Task<IActionResult> AdminLogin(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                var role = await _roleRepo.GetRoleNameByUser(user.Id);
                if (user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
                {
                    if (user.UserTypeId == 2)
                        return NotFound();
                    else if (user.IsLouck == true || user.IsLouck == null)
                        return BadRequest();
                    else
                    {
                        var usertoReturn = _mapper.Map<UserToReturnDTO>(user);
                        var CPanelLogo = _generalSettings.GetSettings().CPanelLogo;
                        var AppName = _generalSettings.GetSettings().AppName;
                        return Ok(new
                        {
                            token = _utitlities.GenerateToken(user, _options),
                            user = usertoReturn,
                            cPanelLogo = CPanelLogo,
                            appName = AppName,
                            roleName = role.NameEn
                        });
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //****Update user profile and admin profile
        [AllowAnonymous]
        [HttpPost("updateProfile")]
        public async Task<IActionResult> UpdateProfile(UserUpdateProfileDTO user)
        {
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            if (_user != null)
            {
                _user.UserName = user.UserName;
                _user.FullName = user.FullName;
                _user.Email = user.Email;
                _user.PhoneNumber = user.PhoneNumber;
                _user.BirthDateM = user.BirthDateM;
                _user.BirthDateH = Convert.ToDateTime(_utitlities.ToHijri(user.BirthDateM));
                _user.GenderId = user.GenderId;
                _user.JobTitle = user.JobTitle;
                _user.Address = user.Address;
                _user.WorkAddress = user.WorkAddress;
                _user.FaceBookAcc = user.FaceBookAcc;
                _user.TwitterAcc = user.TwitterAcc;
                _user.Lat = user.Lat;
                _user.Lng = user.Lng;

                var result = await _userManager.UpdateAsync(_user);
                if (result.Succeeded)
                {
                    var usertoReturn = _mapper.Map<UserUpdateReturnDTO>(_user);
                    return Ok(usertoReturn);
                }
                else
                    return BadRequest();
            }
            return NoContent();
        }

        //****Update user password and admin password
        //[AllowAnonymous]
        [HttpPost("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UserUpdatePassDTO user)
        {
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            if (_user != null)
            {
                var result = await _userManager.ChangePasswordAsync(_user, user.OldPassword, user.NewPassword);
                if (result.Succeeded)
                    return Ok();

                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("getUserLogin")]
        public async Task<IActionResult> GetUserrLogin()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var user = await _userRepo.GetUser_ById(Convert.ToInt32(userId));
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("uploadUserImage")]
        public async Task<IActionResult> UploadUserImage(UserUpdateProfileDTO user)
        {
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            string oldImage = _user.Image;
            if (_user != null)
            {
                _user.Image = user.Image;

                var result = await _userManager.UpdateAsync(_user);
                if (result.Succeeded)
                {
                    _uploaderRepo.DeleteFiles(oldImage, "UserImages", _hostingEnvironment);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && (await _userManager.IsEmailConfirmedAsync(user)))
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                   "/Account/ResetPassword",
                   pageHandler: null,
                   values: new { code },
                   protocol: Request.Scheme);
                return Ok(code);
            }
            return BadRequest();
        }

        public string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpGet("getLoginLogo")]
        public IActionResult GetLoginLogo()
        {
            try
            {
                var LoginLogo = _generalSettings.GetSettings().LoginLogo;
                return Ok
                (
                    new { loginLogo = LoginLogo }
                );
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        #region Admin operation
        //*************************** Admin operations ********************************************************************


        //[HttpPost("updateUser")]
        //public async Task<IActionResult> Update(UserDTO user)
        //{
        //    var _user = await _userManager.FindByIdAsync(user.Id.ToString());
        //    if (_user != null)
        //    {
        //        var oldImage = (_user.ImagePath == "" || _user.ImagePath == null) ? null : _user.ImagePath;
        //        var newImage = (user.ImagePath == "" || user.ImagePath == null) ? _user.ImagePath : user.ImagePath;

        //        var updateUserPass = await _userManager.ChangePasswordAsync(_user, user.OldPassword, user.NewPassword);
        //        if (updateUserPass.Succeeded)
        //        {
        //            _user.UserName = user.UserName;
        //            _user.FullName = user.FullName;
        //            _user.Email = user.Email;
        //            _user.PhoneNumber = user.PhoneNumber.ToString();
        //            _user.IsActive = user.IsActive;
        //            _user.ImagePath = newImage;

        //            var result = await _userManager.UpdateAsync(_user);
        //            if (result.Succeeded)
        //            {
        //                if (newImage != oldImage)
        //                {
        //                    _unitOfWork.FileUploadRepository.DeleteFiles(oldImage, "UserImages", _hostingEnvironment);
        //                }
        //                return Ok();
        //            }

        //            else return BadRequest("error in update user");
        //        }
        //        else
        //            return BadRequest("error in update password");
        //    }
        //    return BadRequest("User not exsist!");
        //}

        ////For users
        //[AllowAnonymous]
        //[HttpPost("UpdateProfile")]
        //public async Task<IActionResult> UpdateUserProfile(UpdateUserProfileDTO newUser)
        //{
        //    var _user = await _userManager.FindByIdAsync(newUser.Id.ToString());
        //    if (_user != null)
        //    {
        //        var oldImage = _user.ImagePath;
        //        var newImage = (newUser.ImagePath == "") ? _user.ImagePath : newUser.ImagePath;

        //        _user.UserName = newUser.UserName;
        //        _user.FullName = newUser.FullName;
        //        _user.Email = newUser.Email;
        //        _user.ImagePath = newImage;

        //        var result = await _userManager.UpdateAsync(_user);
        //        if (result.Succeeded)
        //        {
        //            if (oldImage != newImage && newImage != "")
        //                _unitOfWork.FileUploadRepository.DeleteFiles(oldImage, "UserImages", _hostingEnvironment);

        //            return Ok();
        //        }

        //        else return BadRequest();
        //    }
        //    return BadRequest();
        //}

        #endregion


    }
}