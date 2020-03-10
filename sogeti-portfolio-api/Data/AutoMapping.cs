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

            CreateMap<CoreSkill, CoreSkillDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.name, source => source.MapFrom(src => src.name))
            .ForMember(dest => dest.display, source => source.MapFrom(src => src.display))
            .ForMember(dest => dest.displayOrder, source => source.MapFrom(src => src.displayOrder));

            CreateMap<TechnicalSkill, TechnicalSkillDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.name, source => source.MapFrom(src => src.name))
            .ForMember(dest => dest.display, source => source.MapFrom(src => src.display))
            .ForMember(dest => dest.displayOrder, source => source.MapFrom(src => src.displayOrder));

            CreateMap<Education, EducationDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.school, source => source.MapFrom(src => src.school))
            .ForMember(dest => dest.subject, source => source.MapFrom(src => src.subject))
            .ForMember(dest => dest.levelOfDegree, source => source.MapFrom(src => src.levelOfDegree))
            .ForMember(dest => dest.startDate, source => source.MapFrom(src => src.startDate))
            .ForMember(dest => dest.endDate, source => source.MapFrom(src => src.endDate));

            CreateMap<Certification, CertificationDTO>()
            .ForMember(dest => dest.GuidString, source => source.MapFrom(src => src.GuidString))
            .ForMember(dest => dest.name, source => source.MapFrom(src => src.name))
            .ForMember(dest => dest.title, source => source.MapFrom(src => src.title))
            .ForMember(dest => dest.dateRecieved, source => source.MapFrom(src => src.dateRecieved));
        }
    }
}