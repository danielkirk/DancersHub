using AutoMapper;
using DanceHub.Models;
using DanceHub.Models.DTOs;

namespace DanceHub
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DancerDTO, Dancer>().ReverseMap();
                cfg.CreateMap<DanceTeamDTO, DanceTeam>().ReverseMap();
                cfg.CreateMap<AchievementDTO, Achievement>().ReverseMap();
            });
        }
    }
}