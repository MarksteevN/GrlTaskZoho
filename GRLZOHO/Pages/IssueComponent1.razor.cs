using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;

namespace GRLZOHO.Pages
{
    public partial class IssueComponent1
    {
        #region Properties
        public string Bug_Title { get; set; }
        public string Assin_Name { get; set; }
        public string Bug_No { get; set; }
        public string No_of_Comments { get; set; }
        public string Updated_time { get; set; }
        public string Report_Person { get; set; }
        public string Status_I { get; set; }
        public string I_Web { get; set; }
        public string Description { get; set; }
        public string decsripwithimage { get; set; }
        public static int GetIssueIndexNo { get; set; }
        public static List<string> listOfImgdata { get; set; } = new List<string>();
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        //private static string htmlBody;
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            if (File.Exists(Index.File_Path_Issue))
            {
                Bug_Details(Index.File_Path_Issue);
            }
            else
            {
                Bug_Details(Index.DefaultIssueFilepath);
                Console.WriteLine("Error Occured While printing");
            }
        }

        /// <summary>
        /// the function Makes sure of updated data
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSelectedIssue()
        {
            UserAuthenticationHelper.PrintDataToFile(Index.File_Path_Issue, Index.I_ILink[GetIssueIndexNo], _Get, _Null, false);
            Bug_Details(Index.File_Path_Issue);
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            await module.InvokeVoidAsync("displayAlert", "Issues have been refreshed");
        }

        /// <summary>
        /// Fetching the data from the txt file
        /// </summary>
        /// <param name="FilePath">Filepath for the txt file</param>
        public void Bug_Details(string FilePath)
        {
            int indNo = 0;

            var myJsonString = File.ReadAllText(FilePath);
            var myJsonObject = JsonConvert.DeserializeObject<IssueDetail>(myJsonString);

            Bug_Title = myJsonObject.bugs[indNo].title;
            Assin_Name = myJsonObject.bugs[indNo].assignee_name;
            Bug_No = myJsonObject.bugs[indNo].bug_number;
            No_of_Comments = myJsonObject.bugs[indNo].comment_count;
            Updated_time = myJsonObject.bugs[indNo].updated_time;
            Report_Person = myJsonObject.bugs[indNo].reported_person;
            Status_I = myJsonObject.bugs[indNo].status.type;
            I_Web = myJsonObject.bugs[indNo].link.web.url;
            Description = myJsonObject.bugs[indNo].description;
            
           //FetchImgsFromSource(Description);


            //foreach (var item in listOfImgdata)
            //{
            //    RegenerateAcc_Token.ViewImage(item, RegenerateAcc_Token.access_token, _Get);
            //}
            
            //module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            //await module.InvokeVoidAsync("DisplayImage", $"{Description}");

        }

        /// <summary>
        /// Navigates to the actual webpage of zoho
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToNewTab()
        {
            var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", "Do you Want to See Issues In Detail ?");
            if (confirmed)
            {
                string url = I_Web;
                await jsRuntime.InvokeAsync<object>("open", url, "_blank");
            }
        }

        //public List<string> FetchImgsFromSource(string htmlSource)
        //{
        //    listOfImgdata = new List<string>();
        //    string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        //    MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //    foreach (Match m in matchesImgSrc)
        //    {
        //        string href = m.Groups[1].Value;
        //        //RegenerateAcc_Token.ViewImage(href, RegenerateAcc_Token.access_token, _Get);
        //        listOfImgdata.Add(href);

        //    }
        //    //foreach (var item in listOfImgdata)
        //    //{
            
        //    //    var imageData = Convert.FromBase64String(item);
        //    //    var contentId = Guid.NewGuid().ToString();
        //    //    LinkedResource inline = new LinkedResource(new MemoryStream(imageData), "image/jpeg");
        //    //    inline.ContentId = contentId;
        //    //    inline.TransferEncoding = TransferEncoding.Base64;
        //    //    //Replace all img tags with the new img tag 
        //    //    htmlBody = Regex.Replace(htmlBody, "<img.+?src=[\"'](.+?)[\"'].*?>", @"<img src='cid:" + inline.ContentId + @"'/>");
        //    //}
        //    return listOfImgdata;
        //}
        //public async Task St_Url(string Downloadlink)
        //{
        //    string url = Downloadlink;
        //    await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        //}


        /// <summary>
        /// Makes the selected Issue index no as static so that it can be used in other places too
        /// </summary>
        /// <param name="indNO">Index number of the selected Issue</param>
        /// <returns></returns>
        public static int GetIssueIndex(int indNO)
    {
        GetIssueIndexNo = indNO;
        return indNO;
    }
}
}