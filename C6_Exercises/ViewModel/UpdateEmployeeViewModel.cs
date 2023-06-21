using C6_Exercises.Model;
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
    public class UpdateEmployeeViewModel : INotifyPropertyChanged
    {
        public event EventHandler<Result> UpdateEventHandler;
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _email { get; set; }
        private string _avtar { get; set; }
        private int _id { get; set; }
        private UpdateEmployeeModel _model { get; set; }

        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Avtar { get => _avtar; set { _avtar = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Update { get; private set; }
        public UpdateEmployeeViewModel()
        {
            _model = new UpdateEmployeeModel();
            Update = new Command(UpdateActivity);
        }

        private async void UpdateActivity()
        {
            _model.Id = Id;
            _model.FirstName = FirstName;
            _model.LastName = LastName;
            _model.Email = Email;
            _model.Avtar = Avtar;
            var result = await _model.UpdateEmployeeAsync();
            UpdateEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
