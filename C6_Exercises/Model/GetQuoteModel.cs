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
    public class GetQuoteModel
    {
        private GetQuoteEndPoint _getQuoteEndPoint;

        public ObservableCollection<Quote> Quotes;
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }

        public GetQuoteModel()
        {
            _getQuoteEndPoint = new GetQuoteEndPoint();
        }

        public async Task<Result> GetQuotesListAsync()
        {
            IsVisibleCollectionView = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getQuoteEndPoint.GetQuoteListAsync();
                if(response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var quotes = JsonConvert.DeserializeObject<GetQuoteResponseModel> (data);
                    Quotes = new ObservableCollection<Quote>(quotes.Quotes);
                    IsLoading = false;
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
