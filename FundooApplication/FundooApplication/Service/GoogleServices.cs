
namespace FundooApplication.Service
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using FundooApplication.Model;
    using FundooApplication.Pages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Doc: "https://developers.google.com/identity/protocols/OAuth2InstalledApp"
    /// </summary>
    public class GoogleServices
    {
        /// <summary>
        /// Create a new app and get new credentials: 
        /// https://console.developers.google.com/apis/
        /// </summary>
        public static readonly string ClientId = "924767128788-70rn2bndgb1el223hj2s146pm8vb5t36.apps.googleusercontent.com";

        /// <summary>
        /// The client secret
        /// </summary>
        public static readonly string ClientSecret = "AIzaSyBnoSMp9yNUfO1eI6MxI6vJNK0gYkNPQi8";

        /// <summary>
        /// The redirect URI
        /// </summary>
        public static readonly string RedirectUri = "https://www.youtube.com/";

        /// <summary>
        /// Gets the access token asynchronous.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>return token</returns>
        public async Task<string> GetAccessTokenAsync(string code)
        {
            var requestUrl =
                "https://www.googleapis.com/oauth2/v4/token"
                + "?code=" + code
                + "&client_id=" + ClientId
                + "&client_secret=" + ClientSecret
                + "&redirect_uri=" + RedirectUri
                + "&grant_type=authorization_code";

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(requestUrl, null);

            var json = await response.Content.ReadAsStringAsync();

            var accessToken = JsonConvert.DeserializeObject<JObject>(json).Value<string>("access_token");

            return accessToken;
        }

        /// <summary>
        /// Gets the google user profile asynchronous.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>return google profile of user </returns>
        public async Task<GoogleProfile> GetGoogleUserProfileAsync(string accessToken)
        {
            var requestUrl = "https://www.googleapis.com/plus/v1/people/me"
                             + "?access_token=" + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var googleProfile = JsonConvert.DeserializeObject<GoogleProfile>(userJson);

            return googleProfile;
        }
    }
}
