﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;

namespace PizzaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizzasInStock()
        {
            try
            {
                var Res = await _pizzaService.GetAllPizzasInStock();
                // for each pizza add it's price 
                foreach (var pizza in Res)
                {
                    pizza.Price = pizza.GetPrice();
                }
                return Ok(Res);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPost]
        [Route("order")]
        public async Task<ActionResult<Pizza>> OrderPizzaById(int id)
        {
            try
            {
                var Res = await _pizzaService.OrderPizzaById(id);
                return Ok(Res);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
