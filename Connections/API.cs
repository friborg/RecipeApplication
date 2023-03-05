using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeApp.Connections
{
    internal class API
    {
        // hämta specifikt recept, ta endast in recept-id =  /api/recipes/recipe/XXXXXX
        public static async Task<Rootobject> GetRecipes()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/random?numberofrecipes=1");
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba362624e4d5bce8ed3266987104f76e20c57644ad871c62105c53c6cd7a62e5bf427a44436100b4fcf0bd72d0e0c9063de");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync(); 
                var recipe = JsonSerializer.Deserialize<Rootobject>(body); 
                return recipe;
            }
        }
        //public static async Task<ObservableCollection<CategoriesRoot>> GetCategory() // måltid, allergier, tid, mm
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/search/filters");
        //    request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba362624e4d5bce8ed3266987104f76e20c57644ad871c62105c53c6cd7a62e5bf427a44436100b4fcf0bd72d0e0c9063de");

        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        var recipe = JsonSerializer.Deserialize<ObservableCollection<CategoriesRoot>>(body);
        //        return recipe;
        //    }
        //}
        public static async Task<CategoriesRoot> GetCategory() // måltid, allergier, tid, mm
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/search/filters");
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba362624e4d5bce8ed3266987104f76e20c57644ad871c62105c53c6cd7a62e5bf427a44436100b4fcf0bd72d0e0c9063de");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var recipe = JsonSerializer.Deserialize<CategoriesRoot>(body);
                return recipe;
            }
        }
    }
}
