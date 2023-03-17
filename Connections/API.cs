using System.Text.Json;
using RecipeApp.Models;

namespace RecipeApp.Connections
{
    internal class API
    {
        public static async Task<Rootobject> GetRecipeFromId(string recipeId)
        {
            string stringRequest = "https://handla.api.ica.se/api/recipes/recipe/" + recipeId;
            var body = await APIFetch(stringRequest);
            var recipe = JsonSerializer.Deserialize<Rootobject>(body);
            return recipe;
        }
        public static async Task<RecipeFromSearch> GetRndRecipe(string keyword, string pageNumber)
        {
            string stringRequest = "https://handla.api.ica.se/api/recipes/searchwithfilters?phrase=" + keyword + "&recordsPerPage=1&pageNumber=" + pageNumber + "&sorting=0";
            var body = await APIFetch(stringRequest);
            var recipe = JsonSerializer.Deserialize<RecipeFromSearch>(body);
            return recipe;
        }
        public static async Task<string> APIFetch(string stringRequest) // DRY, kan användas till alla anrop mot ICA API 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, stringRequest);
            request.Headers.Add("AuthenticationTicket", "CF42E0E7C4873A2C210DE7C7E3EB928BA259CCBA96C9D5D7DE1929DB0D7E98B5DC903B67973C0ED2717EF879055C6CCE947361A0A9E0EADA9A0E1FD2ABFF6D01BFFAD7BEDF2404883A7EC0F1E3D6FCF555BC13652956AA67A845C61542CF523E04C78E75F688B4EC0B36398065EC5595628D618EF3031938E0F26CED80C7FDCECFBDD05F168E03BB269076BEAC44A7808F14F9C081A1A301A8BCAF3BA6D0C510B48674FA34BFB88FDD8040B29440AABC7D107571E10DAC332CB967BDA67E0F2BB8987AE9DCCB1EDD437D8794C18EE8534D7264902A9E9142E40EB7FC1735219EADE18926147C7D0537F9D48AEA117EC38DDBD7AEFFF7DF20B7618DA505D39BFF25BFD78FD8DE3EF349E4D361939C87FE5C26B3C888A57F5B93F83D4C9F2D7D5C2CED6B79C4F3386CA8D48FF59EE47A457BF1F9F81A9307C8604C5A586FD0E25D28F7CA91819423F6CD13B76917C9E09F53EAFA9365609254A5453FB13416A23F095B612E18EEB91FB294A68A654FBACAC9A38A749E1A9AD56018C8D6F6E57F1599C75943F423808809A4162C17F4C5AE836D87650537AD6F074A48DA7039029DC6F786A0CFC2CB0E4B44DCED2C7A272F8CC68BE71A5083F55BF48B417F6AB4398A05BD62C50167246523B38B842E23B6BB4E0A850995602925529B30787B973665F48783AA3B02938E919BE530F1B07EE22496CCB32673D28757FF483F1B1ED94A0FCC6C");
            request.Headers.Add("Authorization", "Basic 200008086647:072641");
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba362624e4d5bce8ed3266987104f76e20c57644ad871c62105c53c6cd7a62e5bf427a44436100b4fcf0bd72d0e0c9063de");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                body = ReplaceStringFromApi(body);
                return body;
            }
        }
        private static string ReplaceStringFromApi(string body)
        {
            body = body.Replace("&aring;", "å");
            body = body.Replace("&auml;", "ä");
            body = body.Replace("&ouml;", "ö");
            body = body.Replace("&eacute;", "é");
            body = body.Replace("&deg;", " grader ");
            body = body.Replace("<strong>", "");
            body = body.Replace("</strong>", "");
            body = body.Replace("&nbsp;", "");
            return body;
        }
    }
}
