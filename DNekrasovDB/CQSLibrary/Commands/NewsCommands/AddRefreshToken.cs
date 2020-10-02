using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Commands.NewsCommands
{
    public class AddRefreshToken : IRequest<bool>
    {
        public RefreshToken RefreshTokens { get; set; }

        public AddRefreshToken(RefreshToken refreshToken)
        {
                RefreshTokens = refreshToken;
        }
    }
}
