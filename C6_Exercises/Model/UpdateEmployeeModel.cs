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
    public class UpdateEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Avtar { get; set; }
        public int Id { get; set; }
        public GetEmployeesEndPoint _getEmployeesEndPoint;
        private string _message;

        public UpdateEmployeeModel()
        {
            _getEmployeesEndPoint = new GetEmployeesEndPoint();
        }

        public async Task<Result> UpdateEmployeeAsync()
        {
            if (IsValidFirstName() && IsValidLastName() && IsValidEmail())
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var requestModel = new EmployeeRequestModel()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email,
                        Avatar = Avtar
                    };
                    _getEmployeesEndPoint.Id = Id;
                    _getEmployeesEndPoint.Employee = requestModel;
                    var response = await _getEmployeesEndPoint.UpdateEmployeeDetailsAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeeRequestModel>(data);
                        return new Result()
                        {
                            IsSuccess = true,
                            Message = "Employee Updated Successfully",
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
            else if (!IsValidFirstName() || !IsValidLastName() || !IsValidEmail())
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

        private bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                _message = "Enter email";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidLastName()
        {
            if (string.IsNullOrEmpty(LastName))
            {
                _message = "Enter last name";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidFirstName()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                _message = "Enter first name";
                return false;
            }
            _message = string.Empty;
            return true;
        }


    }
}
