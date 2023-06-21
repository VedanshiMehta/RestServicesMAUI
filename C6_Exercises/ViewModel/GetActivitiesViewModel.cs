                using C6_Exercises.Model;
using Newtonsoft.Json;
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
    public class GetActivitiesViewModel:INotifyPropertyChanged
    {
        private GetActivitiesModel _model;
        private DeleteActivityModel _deleteActivityModel;
        private bool _isLoading = true;
        private bool _isRefreshing;
        private bool _isVisibleCollectionView;
        private ObservableCollection<GetActivitiesResponseModel> _activities;

       

        public ObservableCollection<GetActivitiesResponseModel> ActivityList { get => _activities; set { _activities = value; OnPropertyChanged(); } }
        public bool IsVisibleCollectionView { get => _isVisibleCollectionView; set { _isVisibleCollectionView = value; OnPropertyChanged(); } }
        public bool IsRefreshing { get => _isRefreshing; set { _isRefreshing = value; OnPropertyChanged(); } }
        public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<Result> ActivityDeletedResult;
        public event EventHandler<UpdateDataEventArgs> UpdateData;

        public ICommand RefreshContent { get; private set; }
        public ICommand DeleteActivity { get; private set; }
        public ICommand UpdateActivity { get; private set; }
        public GetActivitiesViewModel()
        {

            RefreshContent = new Command(LoadData);
            DeleteActivity = new Command<GetActivitiesResponseModel>(DelteActivites);
            UpdateActivity = new Command<GetActivitiesResponseModel>(UpdateActivities);
            _model = new GetActivitiesModel();
            _deleteActivityModel = new DeleteActivityModel();
            IsRefreshing = true;
            _model.IsLoading = IsLoading;
            _=GetActivityList();
        }

        private void UpdateActivities(GetActivitiesResponseModel activityResponse)
        {
            UpdateData?.Invoke(this, new UpdateDataEventArgs() { 
                                                                 Title = activityResponse.Title,
                                                                 Id = activityResponse.Id, 
                                                                 Completed = activityResponse.Completed,
                                                                 DueDate = activityResponse.DueDate,
                                                               });
        }

        private async void DelteActivites(GetActivitiesResponseModel activityResponse)
        {
             _deleteActivityModel.Id = activityResponse.Id;
             var result = await _deleteActivityModel.DeleteActivity();
             ActivityDeletedResult?.Invoke(this, result);
        }



        private async Task  GetActivityList()
        {
            await _model.GetActivitiesList();
            ActivityList = _model.ActivityList;
            IsRefreshing = false;
            IsLoading = _model.IsLoading;
            IsVisibleCollectionView = _model.IsVisibleCollectionView;
        }

        private void LoadData()
        {
            _ = GetActivityList();     
            IsRefreshing = false;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class UpdateDataEventArgs : EventArgs
    {
      
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool Completed { get; set; }
    }
}
