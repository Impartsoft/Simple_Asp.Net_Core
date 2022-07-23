using AutoMapper;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Profiles
{
    public class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            //Source -> Target
            CreateMap<Goods, GoodsReadDto>();
            CreateMap<GoodsCreateDto, Goods>();
            CreateMap<GoodsUpdateDto, Goods>();
            CreateMap<Goods, GoodsUpdateDto>();
        }
    }
}
