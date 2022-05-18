using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Dtos;

namespace CommandAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command,CommandReadDto>();
        }
    }
}