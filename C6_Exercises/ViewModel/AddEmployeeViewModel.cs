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
    public class AddEmployeeViewModel :INotifyPropertyChanged
    {

        public event EventHandler<Result> AddEventHandler;
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _email { get; set; }
        private AddEmployeeModel _model { get; set; }
        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }

        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Add { get; private set; }
        public AddEmployeeViewModel()
        {
            _model = new AddEmployeeModel();
            Add = new Command(AddEmployee);
        }

        private async void AddEmployee()
        {
            _model.FirstName = FirstName;
            _model.LastName = LastName;
            _model.Email = Email;
            var result = await _model.AddEmployeesAsync();
            AddEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
