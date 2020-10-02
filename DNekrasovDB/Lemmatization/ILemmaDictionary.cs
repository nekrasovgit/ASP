using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lemmatization
{
    public interface ILemmaDictionary
    {
        Task<string[]> DictionaryLemmaContentn(string content);
    }
}
