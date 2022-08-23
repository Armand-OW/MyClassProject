using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyClassProject.Models;
using MyClassProject.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace MyClassProject.ViewModels
{
    //ObservableObject class inheritance, declares this as ViewModel
    public partial class ProfileViewModel: ObservableObject
    {
        //constructor to declare our user object
        public ProfileViewModel()
        {
            Profile = new User();

            //Getting our list of users and converting to collection
            Users = new ObservableCollection<User>(App.UserRepo.GetAllUsers());
            
        }

        //properties behave as useState in React
        //this ObservableProperty wrapper, sets that the state/values can change

        [ObservableProperty]
        User profile;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string role;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string password;


        [ObservableProperty]
        ObservableCollection<User> users;

        //method that can be called from our view to change our binding data
        //[ICommand] //[ReplyCommand]
        public void Save()
        {
            /* if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Role))
                 return;
 */

            Profile.Username = Username;
            Profile.Role = Role;
            Profile.Password = Password;

            //debug
            Debug.WriteLine(Profile.Username);

            //Insert new user
            try
            {
                App.UserRepo.CreateNewUser(Profile);
                Users = new ObservableCollection<User>(App.UserRepo.GetAllUsers());
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        [RelayCommand]
        void Delete(int id)
        {
            Debug.WriteLine("Id: "+ id.ToString());
            try
            {
                App.UserRepo.DeleteUser(id);
                Users = new ObservableCollection<User>(App.UserRepo.GetAllUsers());
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
