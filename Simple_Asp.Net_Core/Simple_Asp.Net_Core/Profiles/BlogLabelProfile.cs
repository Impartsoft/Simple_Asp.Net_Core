using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class BlogLabelProfile : Profile
    {
        public BlogLabelProfile()
        {
            //Source -> Target
            CreateMap<BlogLabel, BlogLabelReadDto>();
            CreateMap<BlogLabelCreateDto, BlogLabel>();
            CreateMap<BlogLabelUpdateDto, BlogLabel>();
            CreateMap<BlogLabel, BlogLabelUpdateDto>();
        }
    }
}
