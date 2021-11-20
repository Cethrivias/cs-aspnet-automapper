using System;
using System.Linq;
using AutoMapper;
using cs_aspnet_automapper.dtos;
using cs_aspnet_automapper.models;

namespace cs_aspnet_automapper
{
  public class MappingsProfile : Profile
  {
    public MappingsProfile()
    {
      CreateMap<User, UserDto>()
        .ForMember(
          dest => dest.Name, opt =>
          {
            opt.MapFrom(src => $"{src.FirstName} {src.LastName}");
            opt.AddTransform(value => value.Trim());
          }
        )
        .ForMember(
          dest => dest.Username, opt => opt.MapFrom(src => src.Email)
        );

      CreateMap<UserDto, User>()
        .ForMember(
          dest => dest.FirstName, opt => opt.MapFrom(
            src =>
              src.Name.Split(" ", StringSplitOptions.None).ElementAtOrDefault(0)
          )
        ).ForMember(
          dest => dest.LastName, opt => opt.MapFrom(
            src =>
              src.Name.Split(" ", StringSplitOptions.None).ElementAtOrDefault(1)
          )
        )
        .ForMember(
          dest => dest.Email, opt => opt.MapFrom(src => src.Username)
        );
      ;
    }
  }
}