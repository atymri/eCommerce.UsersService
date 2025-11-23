using AutoMapper;
using eCommerce.Core.Domain.Entities;

namespace eCommerce.Core.DTOs.MappingProfiles;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthResponse>()
            .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dst => dst.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dst => dst.IsSuccess, opt => opt.Ignore())
            .ForMember(dst => dst.Token, opt => opt.Ignore());

        CreateMap<RegisterDTO, ApplicationUser>()
            .ForMember(dst => dst.UserId, opt => opt.Ignore())
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dst => dst.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}

