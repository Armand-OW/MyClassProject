namespace MyClassProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Routing.RegisterRoute("monkeydetails", typeof(MonkeyDetailPage));

		Routing.RegisterRoute("Details", typeof(DetailPage1));

    }
}
