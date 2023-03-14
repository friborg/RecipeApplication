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
        Interface.ILoginFacade _loginFacade = new LoginFacade();

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
        public Task<bool> TryLogIn()
        {
            // här använder jag Facade för att kolla om användaren finns, och att lösenord och användarnamn stämmer
            // 
            if (_loginFacade.LoginSuccess(UserNameInput, PasswordInput))
            {
                LogInStatus = "Login successful!";
                LoggedInUser.Username = UserNameInput;
                return Task.FromResult(true);
            }
            else
            {
                LogInStatus = "Wrong username or password, please try again";
                return Task.FromResult(false);
            }
        }
    }
}
