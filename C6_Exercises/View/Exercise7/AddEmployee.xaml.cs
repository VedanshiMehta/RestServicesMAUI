using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise7;

public partial class AddEmployee : ContentPage
{
	private AddEmployeeViewModel _viewModel;
	public AddEmployee()
	{
		InitializeComponent();
		_viewModel = (AddEmployeeViewModel)BindingContext;
        _viewModel.AddEventHandler += ViewModel_AddEventHandler;
	}

    private async void ViewModel_AddEventHandler(object sender, Result e)
    {
        await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        if (e.IsSuccess)
        {
                await Navigation.PopAsync();
        }
            
        
    }
}