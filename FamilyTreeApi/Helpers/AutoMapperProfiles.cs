using AutoMapper;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDTO, User>();
            CreateMap<AddChilredDTO, User>();
            CreateMap<User, UserToReturnDTO>();
            CreateMap<User, UserCompleteRegisterDTO>();
            CreateMap<User, UserUpdateReturnDTO>();
            CreateMap<AddUserRoleDTO, User>();
        }
        
    }
}
