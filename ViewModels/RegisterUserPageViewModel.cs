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
        int peopleInHouseholdInput;
        [ObservableProperty]
        string itemStatusText;

        [ObservableProperty]
        ObservableCollection<string> cAllergies;

        [ObservableProperty]
        ObservableCollection<string> cDietRestrictions;

        [ObservableProperty]
        ObservableCollection<string> allergies; // glöm inte att använda dessa som binding sen i xaml 

        [ObservableProperty]
        ObservableCollection<string> dietRestrictions;

        public RegisterUserPageViewModel()
        {
            Allergies = new ObservableCollection<string>
            {
                "Lactose", "Gluten", "Egg", "Seafood", "Nuts"
            };
            DietRestrictions = new ObservableCollection<string>()
            {
                "Vegan", "Vegetarian","Kosher","Pescetarian"
            };

            CAllergies = new ObservableCollection<string>();
            CDietRestrictions = new ObservableCollection<string>();

            ItemStatusText = string.Empty;
        }

        [RelayCommand]
        public void AddAllergy(string allergy)
        {
            if (!CAllergies.Contains(allergy) || CAllergies == null)
            {
                CAllergies.Add(allergy); 
                ItemStatusText = allergy + " has been added!"; 
            }
            else
            {
                ItemStatusText = allergy + " has already been added!";
            }
        }
        [RelayCommand]
        public void RemoveAllergy(string allergy)
        {
            if(CAllergies.Contains(allergy) && CAllergies != null)
            {
                CAllergies.Remove(allergy);
                ItemStatusText = allergy + " has been deleted!";
            }
            else
            {
                ItemStatusText = allergy + " has already been deleted!";
            }
        }
        [RelayCommand]
        public void AddDietRestr(string dietRestriction)
        {
            if (!CDietRestrictions.Contains(dietRestriction) || CDietRestrictions == null)
            {
                CDietRestrictions.Add(dietRestriction);
                ItemStatusText = dietRestriction + " has been added!";
            }
            else
            {
                ItemStatusText = dietRestriction + " has already been added!";
            }
        }
        [RelayCommand]
        public void RemoveDietRestr(string dietRestriction)
        {
            if(CDietRestrictions.Contains(dietRestriction) && CDietRestrictions != null)
            {
                CDietRestrictions.Remove(dietRestriction);
                ItemStatusText = dietRestriction + " has been deleted!";
            }
            else
            {
                ItemStatusText = dietRestriction + " has already been deleted!";
            }
        }

        [RelayCommand]
        public async void CreateNewUser()
        {
            Customer customer = new Customer()
            {
                Id = Guid.NewGuid(),
                UserName = UserNameInput,
                Password = PasswordInput,
                PeopeInHousehold = PeopleInHouseholdInput,
                Allergies = CAllergies,
                DietRestrictions = CDietRestrictions
            };

            // kolla så att användarnamnet inte redan finns
            await Databases.CustomerCollection().InsertOneAsync(customer);
        }
    }
}
