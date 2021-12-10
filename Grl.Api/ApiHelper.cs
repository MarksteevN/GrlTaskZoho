using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Grl.Api
{
    public class ApiHelper
    {
        HttpClient client = new HttpClient();
        public void AddAuthentication(string Token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }

}