using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise7;

public partial class Exercise7 : ContentPage
{
	private GetEmployeeViewModel _viewModel;
    private EmployeeRequestModel _employeeRequestModel;
	public Exercise7()
	{
		InitializeComponent();
        _employeeRequestModel = new EmployeeRequestModel();
		_viewModel = (GetEmployeeViewModel)BindingContext;
        _viewModel.UpdateEmployeeData += ViewModel_UpdateEmployeeData;
        _viewModel.DeleteEmployeeData += ViewModel_DeleteEmployeeData;
	}

    private void ViewModel_DeleteEmployeeData(object sender, Result e)
    {
       Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
    }

    private async void ViewModel_UpdateEmployeeData(object sender, UpdateEmployeeDataEventArgs e)
    {
        _employeeRequestModel.Email = e.Email;
        _employeeRequestModel.FirstName = e.FirstName;
        _employeeRequestModel.LastName = e.LastName;
        _employeeRequestModel.Avatar = e.Avtar;
        _employeeRequestModel.Id = e.Id;
        await Navigation.PushAsync(new UpdateEmployee(_employeeRequestModel));
    }

    private async void ImageButtonAdd_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddEmployee());
    }
}