using System;
using System.Collections.Generic;
using AutoMapper;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
            .ForMember(dest => dest.Username, source => source.MapFrom(src => src.Username))
            .ForMember(dest => dest.Role, source => source.MapFrom(src => src.Role));

            CreateMap<Consultant, ConsultantDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.firstName, source => source.MapFrom(src => src.firstName))
            .ForMember(dest => dest.lastName, source => source.MapFrom(src => src.lastName))
            .ForMember(dest => dest.email, source => source.MapFrom(src => src.email))
            .ForMember(dest => dest.practice, source => source.MapFrom(src => src.practice))
            .ForMember(dest => dest.summary, source => source.MapFrom(src => src.summary));
        }
    }
}