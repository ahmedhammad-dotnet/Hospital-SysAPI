using AutoMapper;
using HospitalSysAPI.DTOs;
using HospitalSysAPI.Models;

namespace HospitalSysAPI.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDTO, Cart>();

        }
    }
}
