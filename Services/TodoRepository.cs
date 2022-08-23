using MyClassProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.Services
{
    public class TodoRepository
    {
        string _dbPath; //this property -> our db file path

        private SQLiteConnection conn;

        //initialises our DB connection each time
        private void Init()
        {
            //Connect to DB
            if (conn != null) //if already connected, don't again
                return;

            //connecting to db file
            conn = new SQLiteConnection(_dbPath);
            //Create Table if not already existed
            conn.CreateTable<Todo>();
        }

        //constructor to set our properties
        public TodoRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        //CREATE a new task
        public void CreateNewTodo(Todo task)
        {
            Console.WriteLine("Add!!!!");
            try
            {
                Init(); //first connect to file

                conn.Insert(task); //insert new user as row
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //READ: Get all the todos from db
        public List<Todo> GetAllTodos()
        {
            try
            {
                Init(); //first connect

                return conn.Table<Todo>().ToList(); //get all todos
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Todo>();
        }

        public bool MarkTodoCompleted(int todoId)
        {
            try
            {
                Init();

                var todoItem = conn.Table<Todo>().Where(x => x.Id == todoId).FirstOrDefault();

                if(todoItem != null)
                {
                    todoItem.IsCompleted = !todoItem.IsCompleted;
                    var i = conn.Update(todoItem);

                    if (i == -1)
                    {
                        Debug.WriteLine("Issue updating");
                    }
                    return true;
                } else { return false; }
                
            } 
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
        }

        public int GetTotalTodos()
        {
            var count = conn.ExecuteScalar<int>("select count(*) from Todo");

            return count;
        }

/*
        public List<Todo> GetAllDisplayTodos()
        {
            try
            {
                Init(); //first connect

                var todos = conn.Table<Todo>().ToList(); //get all todos
                var users = conn.Table<User>().ToList();

                //JOIN THE TWO TABLES
                var data = from t in todos
                           join u in users on t.UserId equals u.Id
                           select new { t.Id, t.Title, t.IsCompleted, u };

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Todo>();
        }
*/


    }
}
