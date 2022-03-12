namespace Grl.TokenGeneration
{
    public class RegenerateAcc_Token
    {
        #region Properties
        public static string Access_Token { get; set; }
        public static string QueryResponse_Json { get; set; }
        public static string Ststuscode { get; set; }
        public static string StatusOperation { get; set; }
        #endregion

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
            Access_Token = (string)jObject.SelectToken("access_token");
            string getDirectory = Directory.GetCurrentDirectory();
            string Folder = $@"{getDirectory}\Appdata\Access_Token_Log";
            string path = $@"{getDirectory}\Appdata\Access_Token_Log\DebugLogger.txt";
            string timedate;
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            if (!File.Exists(path))
            {
                using StreamWriter sw = File.CreateText(path);
                DateTime now = DateTime.Now;
                timedate = now.ToString("F");
                sw.WriteLine("Access Token " + Access_Token + " " + timedate);
            }
            else
            {
                using StreamWriter sw = File.AppendText(path);
                DateTime now = DateTime.Now;
                timedate = now.ToString("F");
                sw.WriteLine("Access Token " + Access_Token + " " + timedate);
            }
            client.Dispose();
            return Access_Token;
        }

        /// <summary>
        /// This method acts like skeleton for all the other Operations_View
        /// </summary>
        /// <param name="Link">The correct link to get the data</param>
        /// <param name="Token">Access token generated from the above method</param>
        /// <param name="METHOD">get and Post methods are available</param>
        public static void Operations_View(string Link, string Token, string METHOD)
        {
            try
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
                    var reqParams = new FormUrlEncodedContent(requestParameters);
                    response = client.PostAsync(Link, reqParams).GetAwaiter().GetResult();
                }
                // Response HTTP Status Code
                StatusOperation = $"{response.StatusCode}";
                Console.WriteLine("Response HTTP Status Code : " + StatusOperation);
                // Response Body
                string Output = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                QueryResponse_Json = " " + Output;
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// This method acts like skeleton along with the parameters passed during the process
        /// </summary>
        /// <param name="Link">The correct link to get the data</param>
        /// <param name="Token">Access token generated from the above method</param>
        /// <param name="METHOD">get and Post methods are available</param>
        /// <param name="urlParameters">The parameters are converted in the form of string to process</param>
        public static void MT_MileTasklist(string Link, string Token, string METHOD, string urlParameters)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                if ("GET".Equals(METHOD))
                {
                    string Complete_Url = $"{Link}{urlParameters}";
                    response = client.GetAsync(Complete_Url).Result;
                }
                else if ("POST".Equals(METHOD))
                {
                    string Complete_Link = $"{Link}{urlParameters}";
                    client.BaseAddress = new Uri(Complete_Link);
                    var requestParameters = new Dictionary<string, string>();
                    var reqParams = new FormUrlEncodedContent(requestParameters);
                    response = client.PostAsync(Complete_Link, reqParams).GetAwaiter().GetResult();
                }
                Ststuscode = $"{response.StatusCode}";
                Console.WriteLine("Response HTTP Status Code : " + Ststuscode);
                string Output = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                QueryResponse_Json = " " + Output;
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void ViewImage(string link, string Token, string METHOD)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            if ("GET".Equals(METHOD))
            {
                response = client.GetAsync(link).GetAwaiter().GetResult();
                /*Add params if need in any API
                private string urlParameters = "?param1=yourparamvalue¶m2=yourparamvalue";
                response = client.GetAsync(urlParameters).Result;
                */
            }
            //else if ("POST".Equals(METHOD))
            //{
            //    client.BaseAddress = new Uri(URL);
            //    var requestParameters = new Dictionary();
            //    requestParameters.Add("title", "Bug Title");
            //    var reqParams = new FormUrlEncodedContent(requestParameters);
            //    response = client.PostAsync(URL, reqParams).GetAwaiter().GetResult();
            //}
            // Response HTTP Status Code
            Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);
            // Response Body
            Console.WriteLine("Response Body : " + response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            client.Dispose();
        }

    }
}