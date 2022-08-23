using MyClassProject.Services;

namespace MyClassProject;

public partial class App : Application
{
	public static UserRepository UserRepo { get; private set; }
    public static TodoRepository TodoRepo { get; private set; }


    public App(TodoRepository todoRepo, UserRepository userRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        //Initialising our user repo
        TodoRepo = todoRepo;
        UserRepo = userRepo;
       
    }
}
