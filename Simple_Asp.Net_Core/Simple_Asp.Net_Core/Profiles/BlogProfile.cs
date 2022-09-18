using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            //Source -> Target
            CreateMap<Blog, BlogReadDto>();
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();
            CreateMap<Blog, BlogUpdateDto>();
        }
    }
}
