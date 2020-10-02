
using GoodNewsBlog.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GoodNewsBlog.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private const string KEY = "236bYdjYiHdqOrfktH506mZMSH2FFAnkMSU2Z-TyiHFMwdXOKn4sgxA8zXCUpAwdbheld6WgdX15c7EmglQKrmadvprJq-u-D9MH7udWz6JtZnqDpYs9QCRRg4-FNlkm9vsBlgVz_Nr0KnSqHu29ssBwKAVOQIGnszSxVaIdycc";

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<string> RegisterUser(string email, string password)
        {
            var newUser = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                EmailConfirmed = true,
                UserName = email,
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                return newUser.Id;
            }
            return null;
        }

        public async Task<AuthenticateResponcse> Login(string email, string password)
        {
            var findUser = await _userManager.FindByEmailAsync(email);
            if(findUser == null)
            {
                return null;
            }

            var jwtToken = GenerateJwtToken(findUser);
            var refreshToken = GenerateRefreshToken();
            //await _refreshtokenRepo.Add(refreshToken);
            return new AuthenticateResponcse(user, jwtToken, refreshToken);
        }

        private RefreshToken GenerateRefreshToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randombytes = new byte[64];
                rng.GetBytes(randombytes);
                return new RefreshToken()
                    {
                        Token = Convert.ToBase64String(randombytes),
                        Expires = DateTime.UtcNow.AddDays(7),
                        Created = DateTime.UtcNow
                    };
            }

        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KEY);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = roles.Select(s => new Claim(ClaimTypes.Role, s)).ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.Id));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<AuthenticateResponcse> RefreshToken(string refreshToken)
        {
            var tokenInDb = await refreshTokenRepo.GetRefreshTokenByToken(refreshToken);
            var user = tokenInDb.User;
            if(user == null && !tokenInDb.IsActive)
            {
                return null;
            }

            var newRefreshToken = GenerateRefreshToken();

            tokenInDb.Revoked = DateTime.UtcNow;
            tokenInDb.ReplacedByToken = newRefreshToken.Token;

            //await _refreshTokenRepository.Add(newRefrashToken);

            //await _refreshTokenRepository.UpDateRefreshToken(tokenInDb);

            var jwtToken = await GenerateJwtToken(user);
            return new AuthenticateResponcse(user, jwtToken, newRefreshToken.Token);
        }





    }
}
