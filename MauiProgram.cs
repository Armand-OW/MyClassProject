using MyClassProject.Services;
using MyClassProject.ViewModels;
using MyClassProject.Views;

namespace MyClassProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		//Views & ViewModels
		builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<ProfileViewModel>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<TodoPage>();
        builder.Services.AddSingleton<TodoViewModel>();


        //DB Repos
        string userDbPath = FileAccessHelper.GetLocalFilePath("projectDatabase.db3");
        builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, userDbPath));
        builder.Services.AddSingleton<TodoRepository>(s => ActivatorUtilities.CreateInstance<TodoRepository>(s, userDbPath));

        return builder.Build();
	}
}
