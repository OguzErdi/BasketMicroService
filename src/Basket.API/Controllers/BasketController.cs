using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        private IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PostBasketCartItem([FromBody]BasketItemViewModel basketCartItemViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
