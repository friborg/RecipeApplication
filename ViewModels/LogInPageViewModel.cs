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

        //hämta collection med customers under tiden man skriver i uppgifterna och sen använd den i metoden nedan? 
        [RelayCommand]
        public async void TryLogInAsync()
        {
            List<Customer> customerList = await GetUsersFromDb();
            foreach (var c in customerList)
            {
                if (c.UserName == UserNameInput && c.Password == PasswordInput)
                {
                    // loggedInCustomer = c.UserName; //statisk grabb
                    // här går det inte att använda Navigation, why? 
                    LogInStatus = "Login successful, press the button below to continue";
                    break;
                }
                else
                {
                    LogInStatus = "Wrong username or password, please try again";
                }
            }
        }
        public async Task<List<Customer>> GetUsersFromDb()
        {
            List<Customer> usersFromDb = await Databases.CustomerCollection().AsQueryable().ToListAsync();
            return usersFromDb;
        }
    }
}
