using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Interfaces
{
    public interface IProductItemApi
    {
        [Get("/category/{category}")]
        Task<HttpResponseMessage> GetProductItemList(string category);
    }
}
