
using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise6;

public partial class Exercise6 : ContentPage
{
	private RegisterViewModel _viewModel;
	public Exercise6()
	{
		InitializeComponent();
		_viewModel = (RegisterViewModel)BindingContext;
        _viewModel.RegisterEventHandler += ViewModel_RegisterEventHandler;
	}

    private void ViewModel_RegisterEventHandler(object sender, Result e)
    {
        
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();	
		
    }

    private async void LabelSignIn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginPage());
    }
}