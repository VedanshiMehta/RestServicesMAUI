using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise2;

public partial class UpdateActivity : ContentPage
{
	private UpdateActivityViewModel _viewModel;
	public UpdateActivity(ActivitiesRequestModel addActivityModel)
	{
		InitializeComponent();
		_viewModel  = (UpdateActivityViewModel)BindingContext;
		_viewModel.Title = addActivityModel.Title;
		_viewModel.DueDate = addActivityModel.DueDate;
		_viewModel.IsCompleted = addActivityModel.Completed;
		_viewModel.Id = addActivityModel.Id;
        _viewModel.AddEventHandler += ViewModel_AddEventHandler;
	}

    private async void ViewModel_AddEventHandler(object sender, Result e)
    {
        if (!string.IsNullOrEmpty(entryName.Text))
        {
            if (e.IsSuccess)
            {
                await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                await Navigation.PopAsync();
            }
        }
        else
        {
            await Toast.Make("Add Name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}