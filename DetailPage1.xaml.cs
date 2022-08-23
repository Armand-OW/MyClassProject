namespace MyClassProject;

public partial class DetailPage1 : ContentPage
{
	//Binding Variable
	string helloText;

	public DetailPage1()
	{
		InitializeComponent();

		helloText = "Hello Armand";

    }

	private async void Back_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}