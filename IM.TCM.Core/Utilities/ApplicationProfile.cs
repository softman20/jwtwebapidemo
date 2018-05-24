﻿using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IM.TCM.Core.Utilities
{


    public class ApplicationProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApplicationProfile()
        {
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<ApplicationUser, UserDto>()
               
            //    .ForMember(vm => vm.Roles, m => m.MapFrom(u => u.UserRoles != null ? u.UserRoles.Select(e => e.Role.Name) : null))
            //    .ForMember(bu => bu.BusinessUnits, m => m.MapFrom(u => u.UserBusinessUnits != null ? u.UserBusinessUnits.Select(e => e.BusinessUnit != null ? new BusinessUnit { Id = e.BusinessUnit.Id, Name = e.BusinessUnit.Name } : null) : null))
            //    .ForMember(bu => bu.BusinessUnitsId, m => m.MapFrom(u => u.UserBusinessUnits != null ? u.UserBusinessUnits.Select(e => e.BusinessUnit != null ? e.BusinessUnit.Id : 0) : null))
               ;

            CreateMap<UserAuthorizationDto, UserAuthorization>();
            CreateMap<UserAuthorization, UserAuthorizationDto>();

            CreateMap<BusinessUnitDto, BusinessUnit>();
            CreateMap<BusinessUnit, BusinessUnitDto>();

            CreateMap<MasterDto, Company>();
            CreateMap<Company, MasterDto>();

            CreateMap<MasterDto, ApplicationRole>();
            CreateMap<ApplicationRole, MasterDto>();

            CreateMap<MasterDto, ProcessType>();
            CreateMap<ProcessType, MasterDto>();

        }


    }

}