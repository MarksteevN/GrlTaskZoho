using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Grl.Api
{
    public class ApiHelper
    {
        HttpClient client = new HttpClient();
        /*











        public Task<HttpResponseMessage> GetAsync(string url)
        {
            //ApiHelper apiHelper = new ApiHelper();
            //var os = client.GetAsync(url);
            
            try
            {
                ApiHelper apiHelper = new ApiHelper();
                apiHelper = client.GetAsync(url);
                return os1;
            }
            catch
            {
                // TODO:
            }
            //var os = os1;

        }
        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            try
            {
                client.PostAsync(url, content);
            }
            catch
            {
                // TODO:
            }
            return;
        }
        public Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            try
            {
                client.PutAsync(url, content);

            }
            catch
            {
                // TODO
            }
            return;
        }*/
        

        public void AddAuthentication(string Token)
        {
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
    
}
