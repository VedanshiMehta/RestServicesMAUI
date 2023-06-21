using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public interface IRecipiesApi
    {
        [Get("/19d42796-27a9-4b70-b753-5e710ae6e339")]
        Task<HttpResponseMessage> GetRecipiesList();
    }
}
