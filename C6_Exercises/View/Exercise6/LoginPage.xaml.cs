using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise6;

public partial class LoginPage : ContentPage
{
	private LoginViewModel _loginViewModel;
	public LoginPage()
	{
		InitializeComponent();
		_loginViewModel = (LoginViewModel)BindingContext;
        _loginViewModel.LoginEventHandler += LoginViewModel_LoginEventHandler;
	}

    private void LoginViewModel_LoginEventHandler(object sender, Result e)
    {
        
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        
    }

    private async void LabelSignIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}