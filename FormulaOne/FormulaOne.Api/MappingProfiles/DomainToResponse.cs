﻿using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api;

public class DomainToResponse : Profile
{
  public DomainToResponse()
  {
    CreateMap<Achievement, DriverAchievementResponse>()
      .ForMember(
          dest => dest.Wins,
          opt => opt.MapFrom(src => src.RaceWins)
          );
  }
}
