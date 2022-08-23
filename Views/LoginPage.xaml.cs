using MyClassProject.ViewModels;

namespace MyClassProject.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}