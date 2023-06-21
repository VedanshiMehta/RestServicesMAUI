using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
     public interface IRandomQuoteApi
    {
        [Get("/random")]
        Task<HttpResponseMessage> GetRandomQuote();
    }
}
