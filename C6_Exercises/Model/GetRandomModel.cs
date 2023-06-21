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
    public class GetRandomModel
    {
        private GetQuoteEndPoint _getQuoteEndPoint;

        public string Quote { get; set; }
        public string AuthorName { get; set; }

        public GetRandomModel()
        {
            _getQuoteEndPoint = new GetQuoteEndPoint();
        }

        public async Task<Result> GetRandomQuoteAsync()
        {
            
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var response = await _getQuoteEndPoint.GetRandomQuoteListAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var quotes = JsonConvert.DeserializeObject<Quote>(data);
                        Quote = quotes.Quotes;
                        AuthorName = quotes.Author;
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
                catch(Exception ex)
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

    }
}

