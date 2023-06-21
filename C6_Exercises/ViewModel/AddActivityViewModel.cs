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
    public class AddActivityViewModel : INotifyPropertyChanged
    {

        public event EventHandler<Result> AddEventHandler;
        private string _title { get; set; }
        private DateTime _dueDate { get; set; }
        private bool _isCompleted { get; set; }
        private AddActivityModel _model { get; set; }
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public DateTime DueDate { get => _dueDate; set { _dueDate = value; OnPropertyChanged(); } }

        public bool IsCompleted { get => _isCompleted; set { _isCompleted = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Add { get; private set; }
        public AddActivityViewModel()
        {
            _model = new AddActivityModel();
            Add = new Command(AddActivity);
        }

        private async void AddActivity()
        {
            _model.Title = Title;
            _model.DueDate = DueDate;
            _model.IsCompleted = IsCompleted;
            var result = await _model.AddActivities();
            AddEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
