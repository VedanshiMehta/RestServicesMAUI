
using C6_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C6_Exercises.View.Exercise2;

public partial class Exercise2 : ContentPage
{
	private GetActivitiesViewModel viewModel;
    private ActivitiesRequestModel _addActivityModel;
	public Exercise2()
	{
		InitializeComponent();
		viewModel = (GetActivitiesViewModel)BindingContext;
        _addActivityModel = new ActivitiesRequestModel(); 
        viewModel.ActivityDeletedResult += ViewModel_ActivityDeletedResult;
        viewModel.UpdateData += ViewModel_UpdateData;
		
	}

    private async void ViewModel_UpdateData(object sender, UpdateDataEventArgs e)
    {
        _addActivityModel.DueDate = e.DueDate;
        _addActivityModel.Title = e.Title;
        _addActivityModel.Completed = e.Completed;
        _addActivityModel.Id = e.Id;
        await Navigation.PushAsync(new UpdateActivity(_addActivityModel));
    }

    private void ViewModel_ActivityDeletedResult(object sender, Result e)
    {
        if(e.IsSuccess)
        {
            Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();    
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddActivity());
    }
}