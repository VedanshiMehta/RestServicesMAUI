using C6_Exercises.View.Exercise2;
using C6_Exercises.View.Exercise3;
using C6_Exercises.View.Exercise4;
using C6_Exercises.View.Exercise5;
using C6_Exercises.View.Exercise6;
using C6_Exercises.View.Exercise7;

namespace C6_Exercises;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Exercise7())
		{
			BarBackgroundColor = Color.Parse("#609EA0"),
			BarTextColor = Color.Parse("#ffffff"),
		};

	}
}
