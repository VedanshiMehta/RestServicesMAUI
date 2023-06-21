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
    class RegisterViewModel : INotifyPropertyChanged
    {
        
        private string _email { get; set; }
        private string _password { get; set; }
        private string _name { get; set; }
        private RegisterModel _registerModel;


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<Result> RegisterEventHandler;
        public string Email { get =>_email; set { _email = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public string Name { get => _name;set { _name = value;OnPropertyChanged(); } }
        public ICommand RegisterUser { get; private set; }
        public RegisterViewModel()
        {
            RegisterUser = new Command(StartRegister);
            _registerModel = new RegisterModel();
        }

        private async void StartRegister()
        {
            _registerModel.Name = Name;
            _registerModel.Email = Email;
            _registerModel.Password = Password;
            var result = await _registerModel.RegisterUsers();
            RegisterEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
