using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DNekrasovDB.Models.DB;
using DNekrasovDB.ModelView;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace DNekrasovDB.Controllers
{
    public class AccountController : Controller
    {
        private readonly GoodNewsContext _goodNewsContext;

        public AccountController(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _goodNewsContext.Users
                    .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Roles)
                    .FirstOrDefaultAsync(usr => 
                    usr.Email == loginModel.Email && usr.Password == loginModel.Password);


                if (user != null)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect model or password");
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel regModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _goodNewsContext.Users.FirstOrDefaultAsync
                (usr => usr.Email == regModel.Email);


                if (user == null)
                {
                    var newUser = _goodNewsContext.Users.Add(new User()
                    {
                        Id = Guid.NewGuid(),
                        
                        Password = regModel.Password,
                        Email = regModel.Email
                    });

                    var role = await _goodNewsContext.Roles.FirstOrDefaultAsync(r => r.Name.Equals("User"));

                    await _goodNewsContext.UserRoles.AddAsync(new UserRoles()
                    { Id = Guid.NewGuid(), User = newUser.Entity, Roles = role});

                    await _goodNewsContext.SaveChangesAsync();

                    await Authenticate(newUser.Entity);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "User with that Email already exists");
            }
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            claims.AddRange(user.UserRoles.Select(ur => 
            new Claim(ClaimsIdentity.DefaultRoleClaimType, ur.Roles.Name))
                .ToList());

            var identity = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultRoleClaimType,
                ClaimsIdentity.DefaultRoleClaimType);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}