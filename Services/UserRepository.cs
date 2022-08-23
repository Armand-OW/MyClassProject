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
    public class UserRepository
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
            conn.CreateTable<User>();
        }

        //constructor to set our properties
        public UserRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        //CREATE a new user
        public void CreateNewUser(User person)
        {
            try
            {
                Init(); //first connect to file
                //OPTIONAL: Encrypt password property
                int v = conn.Insert(person); //insert new user as row
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //READ: Get all the users from db
        public List<User> GetAllUsers()
        {
            try
            {
                Init(); //first connect
                return conn.Table<User>().ToList(); //get all users
            }
            catch(SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<User>();
        }

        //DELETE: Remove user from database
        public void DeleteUser(int id)
        {
            Debug.WriteLine("DB Id: " + id.ToString());

            try
            {
                conn.Delete<User>(id);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        //TODO: Update


        //Check authentication
        public bool UserLoginAuth(string username, string password)
        {
            try
            {
                Init();
                var data = conn.Table<User>();
                //OPTIONAL: Encrypt password
                var successFind = data.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                
                if(successFind != null) //if we find a user
                {
                    //setting the logged on user id in preference (local storage)
                    Preferences.Set("currentUser", successFind.Id);
                    return true;
                } 
                else
                {
                    Debug.WriteLine("User NOT found!");
                    return false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
