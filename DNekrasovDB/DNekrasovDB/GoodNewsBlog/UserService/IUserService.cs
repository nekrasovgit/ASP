using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.UserService
{
    public interface IUserService
    {
        Task<string> RegisterUser(string email, string password);
        Task<AuthenticateResponcse> Login(string email, string password);
        Task<AuthenticateResponcse> RefreshToken(string refreshToken);

        /*AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);*/

        //Task<refreshToken> UpDateRefreshToken(RefreshToken);
    }
}
