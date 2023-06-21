using C6_Exercises.Interfaces;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetProductsEndPoint
    {
       
        public string SelectedProduct { get; set; }
        public async Task<HttpResponseMessage> GetProductAsync()
        {
            return await RestService.For<IProductsApi>("https://dummyjson.com/products").GetProductsList();
        }
        public async Task<HttpResponseMessage> GetSelectedProductAsync()
        {
            return await RestService.For<IProductItemApi>("https://dummyjson.com/products").GetProductItemList(SelectedProduct);
        }
    }
}
