using System.Net.Http.Headers;

namespace Grl.Api
{
    public class ApiHelper
    {
        readonly HttpClient client = new();
        public string AddAuthentication(string Token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Token;
        }
    }
}