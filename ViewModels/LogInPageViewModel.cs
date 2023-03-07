using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MongoDB.Driver;
using RecipeApp.Connections;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    internal partial class LogInPageViewModel : ObservableObject 
    {
        [ObservableProperty]
        string userNameInput;
        [ObservableProperty]
        string passwordInput;
        [ObservableProperty]
        string logInStatus;

        public LogInPageViewModel()
        {
           
        }
        [RelayCommand]
        public async Task<bool> TryLogInAsync()
        {
            List<Customer> customerList = await GetUsersFromDb();
            bool succesfulLogin = false;
            foreach (var c in customerList)
            {
                if (c.UserName == UserNameInput && c.Password == PasswordInput)
                {
                    LogInStatus = "Login successful!";
                    LoggedInUser.Username = UserNameInput;
                    succesfulLogin = true;
                    break;
                }
                else
                {
                    LogInStatus = "Wrong username or password, please try again";
                }
            }
            return succesfulLogin;
        }
        public async Task<List<Customer>> GetUsersFromDb()
        {
            List<Customer> usersFromDb = await Databases.CustomerCollection().AsQueryable().ToListAsync();
            return usersFromDb;
        }
    }
}
