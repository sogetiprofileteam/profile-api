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
            //.ForMember(dest => dest.id, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email));
            
        }
    }
}