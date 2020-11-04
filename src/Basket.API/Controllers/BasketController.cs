using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Basket.API.ViewModels;
using Basket.Application.Interfaces;
using Basket.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;
        private readonly IMapper _mapper;

        public BasketController(IBasketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PostBasketCartItem([FromBody]BasketItemViewModel basketCartItemViewModel)
        {
            var mapped = _mapper.Map<BasketItemModel>(basketCartItemViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }

            return await _service.AddItemToBasket(mapped);
        }
    }
}
