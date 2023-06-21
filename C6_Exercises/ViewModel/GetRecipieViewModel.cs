
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
    public class GetRecipieViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> _recipiesList;
        public event PropertyChangedEventHandler PropertyChanged;
        private GetRecipieModel _model;
        private bool _isLoading = true;
        private bool _isRefreshing;
        private bool _isVisibleCollectionView;

        public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }
        public bool IsRefreshing { get => _isRefreshing; set { _isRefreshing = value; OnPropertyChanged(); } }
        public bool IsVisibleCollectionView { get => _isVisibleCollectionView; set { _isVisibleCollectionView = value; OnPropertyChanged(); } }
        public ObservableCollection<Recipe> RecipesList { get => _recipiesList; set {_recipiesList=value; OnPropertyChanged(); } }
        public ICommand StopRefreshing { get; private set; }
        public GetRecipieViewModel()
        {
            StopRefreshing = new Command(LoadData);
            _model = new GetRecipieModel();
            IsRefreshing = true;
            _model.IsLoading = IsLoading;
            _ =  GetRecipieList();
       
        }

        private  void LoadData()
        { 
            _ = GetRecipieList();
        }

        public async Task GetRecipieList()
        {
          
            await _model.GetRecipieDetailsAsync();
            RecipesList = _model.Recipies;
            IsRefreshing = false;
            IsLoading = _model.IsLoading;
            IsVisibleCollectionView = _model.IsVisibleCollectionView;

            
        }
        public void OnPropertyChanged([CallerMemberName]string propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
