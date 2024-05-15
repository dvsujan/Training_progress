using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;
using PizzaShopApi.Models.DTOs;

namespace PizzaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login(UserLoginDTO userloginDTO)
        {
            try {
                var Res = await _userService.Login(userloginDTO);
                return Ok(Res);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(userRegisterDTO userRegisterDTO)
        {
            try
            {
                var Res = await _userService.Register(userRegisterDTO);
                return Ok(Res);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
