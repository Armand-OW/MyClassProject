using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.ViewModels
{
    public partial class LoginViewModel: ObservableObject
    {

        //Changable Fields
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        bool stayLoggedOn = false;

        [ObservableProperty]
        string errorMessage;

        [RelayCommand]
        public void CheckLoginSuccess()
        {
            bool search = App.UserRepo.UserLoginAuth(Username, Password);

            if (search) //user found
            {
                Debug.WriteLine("Found the USER!");
                

                
                Preferences.Set("StayLoggedOn", stayLoggedOn);
               
                
               
                ErrorMessage = "";

                Debug.WriteLine(Preferences.Get("StayLoggedOn", false));
                Debug.WriteLine(Preferences.Get("currentUser", 0));
                //TODO: Navigate to dashboard
                //Shell.Current.GoToAsync("/ProfilePage");
            } else
            {
                ErrorMessage = "Invalid Username and/or Password. Please try again.";
                Debug.WriteLine("Nope!");
 
            }
        }

    }
}
