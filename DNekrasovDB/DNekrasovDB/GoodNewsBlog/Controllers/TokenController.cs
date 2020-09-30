using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodNewsBlog.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodNewsBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest authenticateRequest)
        {
            var response = _userService.Login(Request.Email, Request.Password);

            if(response == null)
            {
                return BadRequest( new { message = "Invalid username or password" });
            }

            SetCookieToken(response.RerfershToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthenticateRequest authenticateRequest)
        {
            var refreshToken = Request.Cookies["refeshToken"];

            var response = await _userService.RefreshToken(refreshToken);

            if (refreshtoken == null)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

            SetCookieToken(response.RerfershToken);
            return Ok(response);
        }

        public void SetCookieToken(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", token, cookieOptions);

            return Ok(response);
        }
    }
}