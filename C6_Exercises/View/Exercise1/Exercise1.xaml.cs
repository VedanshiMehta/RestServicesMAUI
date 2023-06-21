using C6_Exercises.ViewModel;

namespace C6_Exercises;

public partial class Exercise1 : ContentPage
{
	private GetRecipieViewModel _viewModel;

	public Exercise1()
	{
		InitializeComponent();
		GetInstance();
	}

   

    private void GetInstance()
    {
		_viewModel = (GetRecipieViewModel)BindingContext;
    }

}

