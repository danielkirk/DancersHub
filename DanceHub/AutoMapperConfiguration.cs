using AutoMapper;
using DanceHub.Models;
using DanceHub.Models.DTOs;

namespace DanceHub
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Dancer, DancerDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<DanceTeam, DanceTeamDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<Achievement, AchievementDTO>());
        }
    }
}