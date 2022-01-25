using AutoMapper;
using NetCore.Model.DTO.SystemModels.User;
using NetCore.Repository.Entitys.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Services.AutoFacExtension
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, GetUserListOutput>();
        }
    }
}
