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
        readonly Interface.ILoginFacade _loginFacade = new LoginFacade();

        [ObservableProperty]
        string userNameInput;
        [ObservableProperty]
        string passwordInput;
        [ObservableProperty]
        string logInStatus;

        [RelayCommand]
        public Task<bool> TryLogIn()
        {
            // här använder jag Facade för att kolla om användaren finns, och att lösenord och användarnamn stämmer
            // anledningen till att jag valde detta mönster, var för att stora delar av appens funktionalitet och fördelar utgår från användarens individuella konto. 
            // genom att säkra inlogget så garanterar jag att appen kommer att fungera som den ska. 

            // om vi ex jämför med design-mönstret "Composite", som baseras på en hierarki-struktur, som utgår från en gren-struktur av klasser, med en stor användning av bland annat arv, så är det mönstret svårt att implementera
            // samt underlättar inte denna app lika mycket som Facade. Jag gjorde bedömningen genom effektivitet, hur enkelt det var att implementera samt vad jag ansåg var viktigast i min kod, vilket var ett säkert inlogg
            // Facade ger mig även möjlighet att lägga till yttligare funktionalitet, ex. om jag lägger till en prenumerations-kostnad, och behöver då lägga till en koll av att kunden betalat

            if (_loginFacade.LoginSuccess(UserNameInput, PasswordInput))
            {
                LogInStatus = "Inloggningen lyckades!";
                LoggedInUser.Username = UserNameInput;
                return Task.FromResult(true);
            }
            else
            {
                LogInStatus = "Fel användarnamn eller lösenord, vänligen försök igen.";
                return Task.FromResult(false);
            }
        }
    }
}
