using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lemmatization
{
    public interface IClientService
    {
        Task<string> SendRequest(string requstContent, string url);
    }
}
