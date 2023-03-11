using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using RecipeApp.Connections;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    internal partial class RegisterUserPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string userNameInput;
        [ObservableProperty]
        string passwordInput;
        [ObservableProperty]
        string status;

        public async void CreateNewUser()
        {
            bool registerSuccess = true; // om listan skulle vara tom, och den hoppar över foreachen, så skapar den fortfarande en användare
            List<Customer> customerList = Databases.CustomerCollection().AsQueryable().ToList();
            foreach (var c in customerList)
            {
                if (c.UserName == UserNameInput)
                {
                    Status = "Detta användarnamn används redan, vänligen försök igen.";
                    registerSuccess = false;
                    break;
                }
                else
                {
                    registerSuccess = true;
                }
            }
            if (registerSuccess && UserNameInput != "" && PasswordInput != "")
            {
                Customer customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    UserName = UserNameInput,
                    Password = PasswordInput,
                };
                await Databases.CustomerCollection().InsertOneAsync(customer);
                Status = "Registrering lyckades!";
            }
        }
    }
}
