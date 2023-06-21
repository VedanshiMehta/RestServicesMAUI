using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class AddActivityModel 
    {
        private GetActivitesEndPoint _activitesEndPoint;
        

        public string Title { get; set; }
        public DateTime DueDate {  get; set; } 

        public bool IsCompleted { get; set; }

        public AddActivityModel()
        {
            _activitesEndPoint = new GetActivitesEndPoint();
        }

        public async Task<Result> AddActivities()
        {
            
                if (CrossConnectivity.Current.IsConnected)
                {
                    var requestData = new ActivitiesRequestModel()
                    {
                        Title = Title,
                        DueDate = DueDate,
                        Completed = IsCompleted,
                    };
                    _activitesEndPoint.ActivitiesRequest = requestData;

                    var response = await _activitesEndPoint.AddActivityAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var activityData = JsonConvert.DeserializeObject<ActivitiesRequestModel>(data);
                        return new Result()
                        {
                            IsSuccess = true,
                            Message = "Activity Added Successfully",
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
