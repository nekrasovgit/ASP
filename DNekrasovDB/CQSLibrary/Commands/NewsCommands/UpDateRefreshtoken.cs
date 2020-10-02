using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Commands.NewsCommands
{
    public class UpDateRefreshtoken : IRequest<bool>
    {
        public RefreshToken RefreshTokens { get; set; }

        public UpDateRefreshtoken(RefreshToken refreshToken)
        {
            RefreshTokens = refreshToken;
        }
    }
}
