using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.Data
{
    public class RefreshTokenrepository
    {
        /*private readonly Contesxt _contesxt;

        public RefreshTokenrepository(Contesxt contesxt)
        {
            _contesxt = contesxt;
        }

        public asynk Task<int> Add(RefreshToken refreshToken)
        {
            var result = await _contesxt.RefreshToken.AddAsync(RefreshToken);
            var executionresult = await _contesxt.SaveChangeAsync();
            return executionresult;
        }*/

        public async Task<RefreshToken> GetRefreshTokenByToken(string token)
        {
            var result = _contesxt.RefreshToken.AsNoTracking()
                .Include(refreshToken => refreshToken.User)
                .FirstOrdefaultAsync(refreshToken => refreshToken.Token.Equals(token));
        }

        public async Task<int> UpDateRefreshToken(RefreshToken)
        {
            _contexst.RefreshTokens.Update(token);
            return await _contexst.SaveChange();
        }

    }
}
