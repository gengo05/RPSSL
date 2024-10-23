using AutoMapper;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = CreateMap<Choice, ChoiceDto>();
            _ = CreateMap<GameResult, GameResultDto>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.GameOutcome.ToFriendlyString()))
                .ForMember(dest => dest.PlayerMove, opt => opt.MapFrom(src => src.PlayerMove.ToString()))
                .ForMember(dest => dest.OpponentMove, opt => opt.MapFrom(src => src.OpponentMove.ToString()));
        }
    }
}

