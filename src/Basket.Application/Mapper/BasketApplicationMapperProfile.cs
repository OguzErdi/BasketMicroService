using AutoMapper;
using Basket.Application.Models;
using Basket.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

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
