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
using Grl.TokenGeneration;

namespace Grl.TokenGeneration
{
    public class UserAuthenticationHelper
    {
        
        private static System.Timers.Timer aTimer;
        public void Accesstokentimer()
        {
            RegenerateAcc_Token.RegenerateAccessToken(Linksforall.GetUrl);
            string acc_token1 = RegenerateAcc_Token.access_token;
            Console.WriteLine("After returned token from Regenerate acc_token" + acc_token1);
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.AddAuthentication(acc_token1);
            RegenerateAcc_Token.Operations(Linksforall.bugsss, Linksforall.Bugss, acc_token1);
            SetTimer();
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
        }
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(20000);
            //aTimer = new System.Timers.Timer(3600000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        public static void Sleep(int waitTimeMilli)
        {
            if (waitTimeMilli <= 0)
                waitTimeMilli = 1;

            int i = 0;
            System.Timers.Timer delayTimer = new System.Timers.Timer(waitTimeMilli);
            delayTimer.AutoReset = false; //so that it only calls the method once
            delayTimer.Elapsed += (s, args) => i = 1;
            delayTimer.Start();
            while (i == 0) { };
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            while (true)
            {
                RegenerateAcc_Token.RegenerateAccessToken(Linksforall.GetUrl);
                string acc_token1 = RegenerateAcc_Token.access_token;
                Console.WriteLine("After returned token from Regenerate acc_token" + acc_token1);
                ApiHelper apiHelper = new ApiHelper();
                apiHelper.AddAuthentication(acc_token1);
                RegenerateAcc_Token.Operations(Linksforall.bugsss, Linksforall.Bugss, acc_token1);
                Sleep(5000);
            }
            //Console.WriteLine("{0}, {1}, {2}, {3}", access_token, api_domain, token_type, expires_in);
        }
        public void WithOutTimer()
        {
            ApiHelper apiHelper = new ApiHelper();
            RegenerateAcc_Token.RegenerateAccessToken(Linksforall.GetUrl);
            //Console.WriteLine(RegenerateAcc_Token.access_token);
            RegenerateAcc_Token.Operations(Linksforall.AllProjects, RegenerateAcc_Token.access_token, EnumClass.METHOD.GET.ToString());
            //apiHelper.AddAuthentication()
        }

        
        
    }
}