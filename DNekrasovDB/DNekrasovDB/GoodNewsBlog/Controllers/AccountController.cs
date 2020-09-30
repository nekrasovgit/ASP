using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodNewsBlog.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodNewsBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthenticateRequest authenticateRequest)
        {
            var registerResult = await _userService.RegisterUser(authenticateRequest.Email, authenticateRequest.Password);

            return Created($"/user/{registerResult}", registerResult);
        }
    }
}