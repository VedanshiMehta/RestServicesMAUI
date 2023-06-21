using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise7;

public partial class UpdateEmployee : ContentPage
{
	private UpdateEmployeeViewModel _viewModel;
	public UpdateEmployee(EmployeeRequestModel _employeeRequestModel)
	{
		InitializeComponent();
		_viewModel = (UpdateEmployeeViewModel)BindingContext;
		_viewModel.Email = _employeeRequestModel.Email;
		_viewModel.FirstName = _employeeRequestModel.FirstName;
		_viewModel.LastName = _employeeRequestModel.LastName;
		_viewModel.Id = _employeeRequestModel.Id;
		_viewModel.Avtar = _employeeRequestModel.Avatar;
        _viewModel.UpdateEventHandler += ViewModel_UpdateEventHandler;
	}

    private async void ViewModel_UpdateEventHandler(object sender, Result e)
    {
        await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        if (e.IsSuccess)
        {
            await Navigation.PopAsync();
        }
    }
}