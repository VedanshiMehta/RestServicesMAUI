using C6_Exercises.EndPoint;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
     public class LoginModel
    {
        private string _message;
        public string Email { get; set; }
        public string Password { get; set; }


        private Exercise6EndPoint _exercise6EndPoint;

        public LoginModel()
        {
            _exercise6EndPoint = new Exercise6EndPoint();
        }

        public async Task<Result> LoginUsers()
        {
            if (IsValidEmail() && IsValidPassword())
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    try
                    {
                        var requestData = new LoginRequestModel()
                        {
                            Email = Email,
                            Password = Password,
                        };
                        _exercise6EndPoint.LoginRequest = requestData;

                        var response = await _exercise6EndPoint.LoginUserAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            var activityData = JsonConvert.DeserializeObject<LoginRequestModel>(data);
                            return new Result()
                            {
                                IsSuccess = true,
                                Message = "Login Successfull",
                            };
                        }
                        else
                        {
                            return new Result()
                            {
                                IsSuccess = false,
                                Message = "Something went wrong"
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Result()
                        {
                            IsSuccess = false,
                            Message = ex.Message,
                        };
                    }
                }
                else
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        IsInternetError = true,
                        Message = "No Internet Connection"
                    };
                }



            }
            else if (!IsValidEmail() || !IsValidPassword())
            {
                return new Result()
                {
                    IsSuccess = false,
                    Message = _message,
                };

            }
            return new Result()
            {
                IsSuccess = false,
                Message = string.Empty,
            };

        }

      

        private bool IsValidPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                _message = "Enter Password";
                return false;
            }
            else if (Password.Length <= 8)
            {
                _message = "Enter Password";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                _message = "Enter Email";
                return false;
            }
            _message = string.Empty;
            return true;
        }
    }
}
