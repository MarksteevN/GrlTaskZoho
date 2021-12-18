using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grl.Api;
using System.Timers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Grl.TokenGeneration
{
    public class RegenerateAcc_Token
    {
        public static string access_token { get; set; }
        public static string jstring { get; set; }

        public static string RegenerateAccessToken(string link)
        {
            HttpClient client = new HttpClient();
            string METHOD = "POST";
            HttpResponseMessage response = null;

            if ("POST".Equals(METHOD))
            {
                client.BaseAddress = new Uri(link);
                var requestParameters = new Dictionary<string, string>();
                var reqParams = new FormUrlEncodedContent(requestParameters);
                response = client.PostAsync(link, reqParams).GetAwaiter().GetResult();
            }

            Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);

            string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            string jsonString = " " + result;
            JObject jObject = JObject.Parse(jsonString);

            access_token = (string)jObject.SelectToken("access_token");

            //Uri api_domain = (Uri)jObject.SelectToken("api_domain");
            //string token_type = (string)jObject.SelectToken("token_type");
            //int expires_in = (int)jObject.SelectToken("expires_in");

            //Console.WriteLine("Regenerated Access Token : " + access_token);

            client.Dispose();
            return access_token;
        }
        public static void Operations(string Link, string Token, string METHOD)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //string METHOD = "POST";
            HttpResponseMessage response = null;
            if ("GET".Equals(METHOD))
            {
                response = client.GetAsync(Link).GetAwaiter().GetResult();

                /*Add params if need in any API
                private string urlParameters = "?param1=yourparamvalue¶m2=yourparamvalue";
                response = client.GetAsync(urlParameters).Result;
                */
            }
            else if ("POST".Equals(METHOD))
            {
                client.BaseAddress = new Uri(Link);
                var requestParameters = new Dictionary<string, string>();
                requestParameters.Add("title", "Bug tig Title");
                requestParameters.Add("assignee_name", "Marksteev");
                var reqParams = new FormUrlEncodedContent(requestParameters);
                response = client.PostAsync(Link, reqParams).GetAwaiter().GetResult();
            }
            // Response HTTP Status Code
            Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);
            // Response Body
            string Output = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine("Response Body : " + Output);

            jstring = " " + Output;
            System.IO.File.WriteAllText(@"E:\Marksteev\Github_Files\GRLZOHO\GRLZOHO\wwwroot\Textfiles\Project.txt", jstring);

            client.Dispose();
        }

        public static void Operation(string mainlink, string Token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string METHOD = "GET";
            HttpResponseMessage response = null;
            if ("GET".Equals(METHOD))
            {
                response = client.GetAsync(mainlink).GetAwaiter().GetResult();

                /*Add params if need in any API
                private string urlParameters = "?param1=yourparamvalue¶m2=yourparamvalue";
                response = client.GetAsync(urlParameters).Result;
                */
            }
            else if ("POST".Equals(METHOD))
            {
                client.BaseAddress = new Uri(mainlink);
                var requestParameters = new Dictionary<string, string>();
                requestParameters.Add("title", "Bug tig Title");
                requestParameters.Add("assignee_name", "Marksteev");
                var reqParams = new FormUrlEncodedContent(requestParameters);
                response = client.PostAsync(mainlink, reqParams).GetAwaiter().GetResult();
            }
            // Response HTTP Status Code
            Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);
            // Response Body
            Console.WriteLine("Response Body : " + response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            client.Dispose();
        }
    }
}
