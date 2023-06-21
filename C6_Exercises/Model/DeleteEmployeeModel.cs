using C6_Exercises.EndPoint;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
    public class DeleteEmployeeModel
    {
        public int Id { get; set; }
        public GetEmployeesEndPoint _getEmployeesEndPoint;

        public DeleteEmployeeModel()
        {
            _getEmployeesEndPoint = new GetEmployeesEndPoint();
        }

        public async Task<Result> DeleteEmployeeAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                _getEmployeesEndPoint.Id = Id;

                var response = await _getEmployeesEndPoint.DeleteEmployeeDetailsAsync();
                if (response.IsSuccessStatusCode)
                {
                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "Employee Deleted Successfully",
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
    }
}
