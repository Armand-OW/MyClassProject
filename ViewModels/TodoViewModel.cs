using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyClassProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.ViewModels
{
    public partial class TodoViewModel: ObservableObject
    {

        public TodoViewModel()
        {
            Todos = new ObservableCollection<Todo>(App.TodoRepo.GetAllTodos());

            ListOfUsers = new List<User>(App.UserRepo.GetAllUsers());
            TotalTodos = App.TodoRepo.GetTotalTodos();
        }

        [ObservableProperty]
        ObservableCollection<Todo> todos;

        [ObservableProperty]
        List<User> listOfUsers;

        //entry field
        [ObservableProperty]
        string title;

        [ObservableProperty]
        int userId;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        bool isCompleted;

        [ObservableProperty]
        User selectedUser;

        [ObservableProperty]
        int totalTodos;


        [RelayCommand]
        public void AddTodo()
        {
            var todoItem = new Todo()
            {
                Title = Title,
                IsCompleted = false,
                UserId = SelectedUser.Id
            };

            Debug.WriteLine(todoItem.Title);

            App.TodoRepo.CreateNewTodo(todoItem);

            Todos = new ObservableCollection<Todo>(App.TodoRepo.GetAllTodos());
        }


        [RelayCommand]
        public void HandleComplete(int todoId)
        {
            Debug.WriteLine("CHANGED! " + todoId);

            App.TodoRepo.MarkTodoCompleted(todoId);
            Todos = new ObservableCollection<Todo>(App.TodoRepo.GetAllTodos());
            //Call our update function
        }

    }
}
