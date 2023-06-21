
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C6_Exercises
{
    public class GetRecipieModel
    {
        private GetRecipiesEndPoint _getRecipiesEndpoint;


        public ObservableCollection<Recipe> Recipies { get; set; }

        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }
     

        public GetRecipieModel()
        {
            
            _getRecipiesEndpoint = new GetRecipiesEndPoint();
        }

        public async Task<Result> GetRecipieDetailsAsync()
        {
            
            IsVisibleCollectionView = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getRecipiesEndpoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var recipies = JsonConvert.DeserializeObject<GetRecipieResponseModel>(data);
                    Recipies = new ObservableCollection<Recipe>(recipies.Recipes);
                    IsLoading = false;
                    IsVisibleCollectionView= true;
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
