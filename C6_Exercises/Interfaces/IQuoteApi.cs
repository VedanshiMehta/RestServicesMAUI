using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public interface IQuoteApi
    {
        [Get("/quotes")]
        Task<HttpResponseMessage> GetQuoteList();
    }
}
