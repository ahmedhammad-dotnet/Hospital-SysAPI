using AutoMapper;
using HospitalSysAPI.DTOs;
using HospitalSysAPI.Models;

namespace HospitalSysAPI.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUserDTOs, ApplicationUser>()
                .ForMember(dest => dest.UserName, option => option.MapFrom(sourse => sourse.name));
        }
    }
}
