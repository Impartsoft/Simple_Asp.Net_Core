using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class FTPFilesProfile : Profile
    {
        public FTPFilesProfile()
        {
            //Source -> Target
            CreateMap<FTPFile, FTPFileReadDto>();
            CreateMap<FTPFileCreateDto, FTPFile>();
        }
    }
}
