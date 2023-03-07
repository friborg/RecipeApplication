using Microsoft.EntityFrameworkCore;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    [Index(nameof(UserName), IsUnique = true)]

    public class Customer
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
        public int PeopeInHousehold { get; set; }
        public ObservableCollection<string> Allergies { get; set; }
        public ObservableCollection<string> DietRestrictions { get; set; }
    }
}
