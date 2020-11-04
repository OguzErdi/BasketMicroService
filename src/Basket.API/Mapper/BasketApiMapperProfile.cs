using AutoMapper;
using Basket.API.ViewModels;
using Basket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Mapper
{
    public class BasketApiMapperProfile : Profile
    {
        public BasketApiMapperProfile()
        {
            CreateMap<BasketItemViewModel, BasketItemModel>();
        }
    }
}
