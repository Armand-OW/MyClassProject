using MyClassProject.ViewModels;

namespace MyClassProject.Views;

public partial class TodoPage : ContentPage
{
	public TodoPage(TodoViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}