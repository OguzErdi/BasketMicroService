using AutoMapper;
using Basket.Application.Models;
using Basket.Core.Entites;

namespace Basket.Application.Mapper
{
    public class BasketApplicationMapperProfile : Profile
    {
        public BasketApplicationMapperProfile()
        {
            CreateMap<BasketItem, BasketItemModel>().ReverseMap();
        }
    }
}