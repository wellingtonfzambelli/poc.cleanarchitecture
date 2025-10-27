using AutoMapper;
using CleanArchitecture.Application.UseCases.Auth.CreateUser;

namespace CleanArchitecture.Application.AutoMapper;

internal sealed class AuthConfigurationMapping : Profile
{
    public AuthConfigurationMapping()
    {
        CreateMap<CreateUserRequestDto, CreateUserCommandDto>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<CreateUserCommandDto, CreateUserRequestDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }
}