using C6_Exercises.EndPoint;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
    public class GetEmployeeModel
    {
        private GetEmployeesEndPoint _getEmployeesEndPoint;

       

        public ObservableCollection<Datum> EmployeeList { get; set; }
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }
        public GetEmployeeModel()
        {
            _getEmployeesEndPoint = new GetEmployeesEndPoint();
        }
        public async Task<Result> GetEmployeeList()
        {

            IsVisibleCollectionView = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getEmployeesEndPoint.GetEmployeeDetailsAsync();
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var employeeData = JsonConvert.DeserializeObject<GetEmployeeResponseModel>(data);
                        EmployeeList = new ObservableCollection<Datum>(employeeData.Data);
                        IsLoading = false;
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                    }
                    IsVisibleCollectionView = true;
                    return new Result()
                    {
                        IsSuccess = true,
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
