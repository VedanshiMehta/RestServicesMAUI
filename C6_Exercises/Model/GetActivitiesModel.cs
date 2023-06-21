using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetActivitiesModel
    {
        private GetActivitesEndPoint _activitesEndPoint;

       

        public ObservableCollection<GetActivitiesResponseModel> ActivityList { get; set; }
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }

        public GetActivitiesModel()
        {
            _activitesEndPoint = new GetActivitesEndPoint();
        }

        public async Task<Result> GetActivitiesList()
        {
            
            IsVisibleCollectionView = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _activitesEndPoint.ExecuteActivityAsync();
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var recipies = JsonConvert.DeserializeObject<List<GetActivitiesResponseModel>>(data);
                        ActivityList = new ObservableCollection<GetActivitiesResponseModel>(recipies);
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
