using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C6_Exercises.ViewModel
{
    public class GetProductViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<string> _productList;
        public event PropertyChangedEventHandler PropertyChanged;
        private GetProductsModel _model;
        private bool _isLoading = true;
        private bool _isVisibleCollectionView;
        private string _selectedProduct;
        public ObservableCollection<Product> _product;
        public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }
        public bool IsVisibleCollectionView { get => _isVisibleCollectionView; set { _isVisibleCollectionView = value; OnPropertyChanged(); } }
        public ObservableCollection<string> ProductList { get => _productList; set { _productList = value; OnPropertyChanged(); } }
        public ObservableCollection<Product> Product { get => _product; set { _product = value; OnPropertyChanged(); } }
        public string SelectedProduct { get => _selectedProduct; set { _selectedProduct = value;OnPropertyChanged(); } }

        public ICommand SelectedProductItem { get; private set; }

        public GetProductViewModel()
        {
            SelectedProductItem = new Command(GetSelectedProductItem);
            _model = new GetProductsModel();
            _model.IsLoading = IsLoading;
            _ = GetProuductList();

        }

       

        public async Task GetProuductList()
        {

            await _model.GetProductsDetailsAsync();
            ProductList = _model.ProductsList;
            SelectedProduct = _model.SelectedProduct;
            //Product = _model.Product;



        }
        private async void GetSelectedProductItem()
        {
            _model.SelectedProduct = SelectedProduct;
            await _model.GetProductsDetailsAsync();
            Product = _model.Product;
            IsLoading = _model.IsLoading;
            IsVisibleCollectionView = _model.IsVisibleCollectionView;

        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
