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
    public class UserAuthenticationHelper
    {
        private static System.Timers.Timer aTimer;
        //private const string Url = "https://accounts.zoho.com/oauth/v2/token";
        private const string GetUrl = "https://accounts.zoho.com/oauth/v2/token?refresh_token=1000.5e47238715f68c6ef78372fb2cd682c1.a8c0f4710ee2b80b24899f396857d8a2&client_id=1000.M12AC09IJDX3X5TA3KOTHT09XEOYAG&client_secret=2cf6a821d8705edd87568faca15c9a459edf3befb4&grant_type=refresh_token";
        //static string AccessToken = "";
        
        public void Accesstokentimer()
        {            
            SetTimer();
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            //return string.Empty;
        }
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(6000);
            //aTimer = new System.Timers.Timer(3600000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //ApiHelper apiHelper = new ApiHelper();
            HttpClient client = new HttpClient();
            //TokenGeneration tokenGeneration = new TokenGeneration();
            bool flag = true;
            //string AccessToken = tokenGeneration.Zoho_oauthtoken1;
            //apiHelper.AddAuthentication(AccessToken);

            if (flag == true)
            {                
                //Console.WriteLine(sd);
                string METHOD = "POST";
                HttpResponseMessage response = null;

                //if ("GET".Equals(METHOD))
                //{
                //    response = apiHelper.GetAsync(Url).GetAwaiter().GetResult();
                //}
                if ("POST".Equals(METHOD))
                {
                    client.BaseAddress = new Uri(GetUrl);
                    var requestParameters = new Dictionary<string, string>();
                    var reqParams = new FormUrlEncodedContent(requestParameters);
                    response = client.PostAsync(GetUrl, reqParams).GetAwaiter().GetResult();
                }

                Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);

                string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                //Console.WriteLine("Response Body : " + result);

                string jsonString = " " + result;
                JObject jObject = JObject.Parse(jsonString);

                string access_token = (string)jObject.SelectToken("access_token");
                //Uri api_domain = (Uri)jObject.SelectToken("api_domain");
                //string token_type = (string)jObject.SelectToken("token_type");
                //int expires_in = (int)jObject.SelectToken("expires_in");
                Console.WriteLine("Regenerated Access Token : " + access_token);

                //AccessToken = access_token;
                flag = true;
                //string sd = AccessToken;
                //apiHelper.AddAuthentication(sd);
                //Console.WriteLine(sd);
                client.Dispose();
                //return sd;
            }

            
            //Console.WriteLine("{0}, {1}, {2}, {3}", access_token, api_domain, token_type, expires_in);

            
        }

    }


}
