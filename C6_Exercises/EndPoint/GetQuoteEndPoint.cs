using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetQuoteEndPoint
    {
        public async Task<HttpResponseMessage> GetQuoteListAsync()
        {
            return await RestService.For<IQuoteApi>("https://dummyjson.com/").GetQuoteList();
        }
        public async Task<HttpResponseMessage> GetRandomQuoteListAsync()
        {
            return await RestService.For<IRandomQuoteApi>("https://dummyjson.com/quotes").GetRandomQuote();
        }
    }
}
