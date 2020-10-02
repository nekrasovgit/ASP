using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lemmatization
{
    public interface IRatingService
    {
        Task<double?> GetContentRating(string content, Dictionary<string, string> affinDictionary);
    }
}
