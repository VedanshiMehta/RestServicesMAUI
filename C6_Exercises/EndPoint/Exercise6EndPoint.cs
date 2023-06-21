using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.EndPoint
{
    public class Exercise6EndPoint
    {
        public LoginRequestModel LoginRequest { get; set; }
        public RegisterRequestModel RegisterRequest { get; set; }

        public async Task<HttpResponseMessage> LoginUserAsync()
        {
            return await RestService.For<ILoginApi>("https://reqres.in/api").LoginUser(LoginRequest);
        }

        public async Task<HttpResponseMessage> RegisterUserAsync()
        {
            return await RestService.For<ILoginApi>("https://reqres.in/api").RegisterUser(RegisterRequest);
        }
    }
}
