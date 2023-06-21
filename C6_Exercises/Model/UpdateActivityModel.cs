using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
    public class UpdateActivityModel
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
        public int Id { get; set; }
        public GetActivitesEndPoint _activitesEndPoint;

        public UpdateActivityModel()
        {
            _activitesEndPoint = new GetActivitesEndPoint();
        }

        public async Task<Result> UpdateActivity()
        {

            if (CrossConnectivity.Current.IsConnected)
            {      
                var requestModel = new ActivitiesRequestModel()
                {
                    Completed = IsCompleted,
                    DueDate = DueDate,
                    Title = Title,
                };
                _activitesEndPoint.Id = Id;
                _activitesEndPoint.ActivitiesRequest = requestModel;
                var response = await _activitesEndPoint.UpdateActivityAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ActivitiesRequestModel>(data);
                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "Activity Updated Successfully",
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
