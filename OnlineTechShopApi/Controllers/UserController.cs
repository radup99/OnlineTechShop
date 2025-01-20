using Microsoft.AspNetCore.Mvc;
using OnlineTechShopApi.Entities;
using OnlineTechShopApi.Enums;
using OnlineTechShopApi.Models;
using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Services;

namespace OnlineTechShopApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(ILogger<UserController> logger, UserService userService) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterPostModel registerModel)
        {
            var result = await _userService.RegisterUser(registerModel);
            switch (result) 
            {
                case RegisterResult.Success:
                    return Ok();
                case RegisterResult.ExistingUsername:
                    return BadRequest("Username already exists");
                case RegisterResult.ExistingEmail:
                    return BadRequest("Email already exists");
                default:
                    return BadRequest("Unknown error");
            }
        }
    }
}
