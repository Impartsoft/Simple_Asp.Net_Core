using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            //Source -> Target
            CreateMap<Comment, CommentReadDto>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentUpdateDto>();
        }
    }
}
