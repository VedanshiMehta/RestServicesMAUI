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
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email { get; set; }
        private string _password { get; set; }
        private LoginModel _loginModel;


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<Result> LoginEventHandler;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public ICommand LoginUser { get; private set; }
        public LoginViewModel()
        {
            LoginUser = new Command(StartLogin);
            _loginModel = new LoginModel();
        }

        private async void StartLogin()
        {
            
            _loginModel.Email = Email;
            _loginModel.Password = Password;
            var result = await _loginModel.LoginUsers();
            LoginEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
