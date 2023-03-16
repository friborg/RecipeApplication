using MongoDB.Driver;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    class MainPageViewModel
    {
        public static void DeleteOldData() 
        {
            Connections.Databases.RelationsCollection().DeleteMany(r => r.CurrentDate < DateOnly.FromDateTime(DateTime.Now));
        }
    }
}
