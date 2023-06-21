using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
     public class DeleteActivityModel
     {
        public int Id { get; set; }
        public GetActivitesEndPoint _activitesEndPoint;

        public DeleteActivityModel()
        {
            _activitesEndPoint = new GetActivitesEndPoint();
        }

        public async Task<Result> DeleteActivity()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                
                _activitesEndPoint.Id = Id;

                var response = await _activitesEndPoint.DeleteActivityAsync();
                if (response.IsSuccessStatusCode)
                {
                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "Activity Deleted Successfully",
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
