using System;
using System.Collections.Generic;
using System.Text;

namespace Lemmatization
{
    public interface IAfinneService
    {
        Dictionary<string, string> LoadDictionary();
    }
}
