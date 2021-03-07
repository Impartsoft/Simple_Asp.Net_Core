using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
