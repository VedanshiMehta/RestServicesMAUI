using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetRecipiesEndPoint
    {
        
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IRecipiesApi>("https://run.mocky.io/v3").GetRecipiesList();
        }

       
    }
}
