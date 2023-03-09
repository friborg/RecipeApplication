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
    internal partial class MyPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string oldPassword;
        [ObservableProperty]
        string newPassword;
        [ObservableProperty]
        string status;

        [RelayCommand]
        public async void ChangePassword()
        {
            List<Customer> customerList = await Databases.CustomerCollection().AsQueryable().ToListAsync();
            foreach (var c in customerList.Where(c => c.UserName == LoggedInUser.Username))
            {
                if(OldPassword ==  c.Password && NewPassword != c.Password)
                {
                    c.Password = NewPassword;
                    await Databases.CustomerCollection().UpdateOneAsync(c => c.Password == OldPassword, Builders<Customer>.Update.Set(c => c.Password, NewPassword));
                    Status = "Ditt lösenord är nu uppdaterat!";
                }
                else if(NewPassword == c.Password)
                {
                    Status = "Det nya lösenordet kan ej vara samma som föregående lösenord, vänligen försök igen.";
                }
            }
        }
    }
}
