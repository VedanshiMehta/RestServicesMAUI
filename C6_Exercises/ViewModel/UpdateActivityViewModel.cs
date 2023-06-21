using C6_Exercises.Model;
using C6_Exercises.View.Exercise2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C6_Exercises.ViewModel
{
    public class UpdateActivityViewModel : INotifyPropertyChanged
    {
         public event EventHandler<Result> AddEventHandler;
        private string _title { get; set; }
        private DateTime _dueDate { get; set; }
        private bool _isCompleted { get; set; }
        private int _id { get; set; }
        private UpdateActivityModel _model { get; set; }

        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public DateTime DueDate { get => _dueDate; set { _dueDate = value; OnPropertyChanged(); } }
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public bool IsCompleted { get => _isCompleted; set { _isCompleted = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Update { get; private set; }
        public UpdateActivityViewModel()
        {
            _model = new UpdateActivityModel();
            Update = new Command(UpdateActivity);
        }

        private async void UpdateActivity()
        {
            _model.Id = Id;
            _model.Title = Title;
            _model.DueDate = DueDate;
            _model.IsCompleted = IsCompleted;
            var result = await _model.UpdateActivity();
            AddEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
