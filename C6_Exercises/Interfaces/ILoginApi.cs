using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace C6_Exercises
{
    public interface ILoginApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> LoginUser([Body] LoginRequestModel loginRequestModel);

        [Post("/register")]
        Task<HttpResponseMessage> RegisterUser([Body] RegisterRequestModel registerRequestModel);
    }
}
