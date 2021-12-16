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

        /// <summary>
        /// This Method is used to generate Access Token
        /// </summary>
        /// <param name="link">The link contains of client id and redirect uri</param>
        /// <param name="METHOD">Method contains with Get and post</param>
        /// <returns>It Returns the Generated Access token</returns>
        public static string RegenerateAccessToken(string link, string METHOD)
        {
            HttpClient client = new HttpClient();
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
            client.Dispose();
            return access_token;
        }

        /// <summary>
        /// This method acts like skeleton for all the other Operations
        /// </summary>
        /// <param name="Link">The correct link to get the data</param>
        /// <param name="Token">Access token generated from the above method</param>
        /// <param name="METHOD">get and Post methods are available</param>
        public static void Operations(string Link, string Token, string METHOD)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            if ("GET".Equals(METHOD))
            {
                response = client.GetAsync(Link).GetAwaiter().GetResult();
            }
            else if ("POST".Equals(METHOD))
            {
                client.BaseAddress = new Uri(Link);
                var requestParameters = new Dictionary<string, string>();
                //requestParameters.Add("title", "Bug tig Title");
                //requestParameters.Add("assignee_name", "Marksteev");
                var reqParams = new FormUrlEncodedContent(requestParameters);
                response = client.PostAsync(Link, reqParams).GetAwaiter().GetResult();
            }
            // Response HTTP Status Code
            Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);
            // Response Body
            string Output = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            jstring = " " + Output;
            //Console.WriteLine(jstring);
            //Creates a text file and stores the output(It acts as a temporary file)
            //string filep = Directory.GetCurrentDirectory();
            //System.IO.File.WriteAllText(filep + @"\Appdata\Projects.txt", jstring);
            client.Dispose();
        }
    }
}