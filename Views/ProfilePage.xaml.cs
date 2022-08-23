using MyClassProject.ViewModels;

namespace MyClassProject.Views;

public partial class ProfilePage : ContentPage
{
	ProfileViewModel vm = new ProfileViewModel();
	public ProfilePage()
	{
		InitializeComponent();
		//use our viewModel to bind data on this View
		BindingContext = vm;

	}

	private void Save_Clicked(object sender, EventArgs e)
	{
		vm.Save();
	}
}