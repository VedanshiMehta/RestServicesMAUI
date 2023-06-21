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
    public class GetProductsModel
    {
        private GetProductsEndPoint _getProductsEndPoint;
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }
        
        public string SelectedProduct { get; set; }
        public ObservableCollection<string> ProductsList { get; set; }
        public ObservableCollection<Product> Product { get; set; }
        public GetProductsModel()
        {
            _getProductsEndPoint = new GetProductsEndPoint();
        }

        public async Task<Result> GetProductsDetailsAsync()
        {
            IsVisibleCollectionView = false;
            if (CrossConnectivity.Current.IsConnected)
            {               
                    var response = await _getProductsEndPoint.GetProductAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            var products = JsonConvert.DeserializeObject<List<string>>(data);
                            ProductsList = new ObservableCollection<string>(products);
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.Message);
                        }
                        if (SelectedProduct == null)
                        {
                            SelectedProduct = ProductsList.FirstOrDefault();
                        }
                        _getProductsEndPoint.SelectedProduct = SelectedProduct;
                        var productresponse = await _getProductsEndPoint.GetSelectedProductAsync();
                        if (productresponse.IsSuccessStatusCode)
                        {
                            
                            var productData = await productresponse.Content.ReadAsStringAsync();
                            var productList = JsonConvert.DeserializeObject<GetProductsResponseModel>(productData);
                            Product = new ObservableCollection<Product>(productList.Products);
                            IsLoading = false;
                            IsVisibleCollectionView = true;

                        }
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
