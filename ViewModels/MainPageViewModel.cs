using MongoDB.Driver;

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
